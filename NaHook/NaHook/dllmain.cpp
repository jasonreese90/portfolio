// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "dinput.h"
#include "DirectInput8.h"
#include "detours.h"
#include <stdio.h>

#define SENDSTRING 0
#define SETKEY 1
#define BLOCK 2


typedef HRESULT (WINAPI* DirectInput8Create_t)(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPVOID *ppvOut, LPUNKNOWN punkOuter);
typedef HHOOK(WINAPI* SetWindowsHookExA_t)(int idHook, HOOKPROC  lpfn, HINSTANCE hmod, DWORD  dwThreadId);
typedef LRESULT (CALLBACK*KeyboardProcLowLevel_t)(int code,WPARAM wParam,LPARAM lParam);
typedef void(__cdecl* SendString_t)(char* text, int code);

DirectInput8Create_t DirectInput8Create_real;
KeyboardProcLowLevel_t KeyboardProcLowLevel_real;
SetWindowsHookExA_t SetWindowsHookExA_real;
HMODULE handle;
SendString_t SendString;

struct Command
{
	BYTE id;
	BYTE data[256];
};

struct SetKey
{
	BYTE key;
	bool state;
};



DWORD WINAPI ThreadProc(LPVOID lpParameter)
{
	char buffer[16384];
	DWORD dwRead;
	char pipeName[256];
	sprintf_s(pipeName, "\\\\.\\pipe\\NaHook_%d", GetCurrentProcessId());
	
	HANDLE hPipe = CreateNamedPipeA(pipeName, PIPE_ACCESS_INBOUND, PIPE_TYPE_BYTE | PIPE_READMODE_BYTE | PIPE_WAIT, PIPE_UNLIMITED_INSTANCES, 16384, 16384, NMPWAIT_USE_DEFAULT_WAIT, NULL);

	while (hPipe != INVALID_HANDLE_VALUE)
	{
		if (ConnectNamedPipe(hPipe, NULL) != FALSE) 
		{
			while (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
			{
				buffer[dwRead] = '\0';

				Command* c = (Command*)&buffer;

				switch (c->id)
				{
				case SENDSTRING:
				{
					char string[256];
					sprintf_s(string, "%s", c->data);
					SendString(string, 1);
					
					break;
				}
				case SETKEY:
				{
					SetKey* sk = (SetKey*)&c->data;
					keyboard->SetKey(sk->key, sk->state);

					break;
				}
				case BLOCK:
					break;

				}
			}
		}

		DisconnectNamedPipe(hPipe);
	}

	return 0;
}

LRESULT CALLBACK KeyboardProcLowLevel_mine(int code, WPARAM wParam, LPARAM lParam)
{
	return KeyboardProcLowLevel_real(code, wParam, lParam);
}

HHOOK WINAPI SetWindowsHookExA_mine(int idHook, HOOKPROC  lpfn, HINSTANCE hmod, DWORD  dwThreadId)
{
	if (idHook == WH_KEYBOARD_LL)
	{
		KeyboardProcLowLevel_real = lpfn;
		
		return SetWindowsHookExA_real(idHook, KeyboardProcLowLevel_mine, hmod,dwThreadId);
	}
	
	return SetWindowsHookExA_real(idHook, lpfn, hmod, dwThreadId);
}

HRESULT WINAPI DirectInput8Create_mine(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPVOID *ppvOut, LPUNKNOWN punkOuter)
{

	if (riidltf == IID_IDirectInput8A)
	{
		IDirectInput8A* pdi;


		HRESULT res = DirectInput8Create_real(hinst, dwVersion, riidltf,(LPVOID*)&pdi, punkOuter);

		*ppvOut = new DirectInput8A(&pdi);
		return res;

	}
	else if (riidltf == IID_IDirectInput8W)
	{
		IDirectInput8W* pdi;
		

		HRESULT res = DirectInput8Create_real(hinst, dwVersion, riidltf, (LPVOID*)&pdi, punkOuter);

		*ppvOut = new DirectInput8W(&pdi);
		return res;
	}

	return DirectInput8Create_real(hinst, dwVersion, riidltf, ppvOut, punkOuter);
}

DWORD WINAPI AttachProc(LPVOID lpParameter)
{
	//load nasomi registry
	HKEY key;
	if (RegOpenKeyExA(HKEY_LOCAL_MACHINE, "SOFTWARE\\WOW6432Node\\PlayNasomiUS\\InstallFolder", NULL, KEY_READ, &key) != ERROR_SUCCESS)
	{
		MessageBoxA(NULL, "Can't find SOFTWARE\\WOW6432Node\\PlayNasomiUS\\InstallFolder.", "Error", MB_OK);
		return FALSE;
	}

	BYTE val[256];
	char buffer[256];
	DWORD size;
	RegQueryValueExA(key, "0001", NULL, NULL, (LPBYTE)val, &size);

	sprintf_s(buffer, "%s\\FFXiMain.dll", val);

	HANDLE ffxiMain = LoadLibraryA(buffer);
	HANDLE handle = LoadLibraryA("dinput8.dll");

	SendString = (SendString_t)((int)ffxiMain + 0x7F6C0);
	//handle = hModule;
	DirectInput8Create_real = (DirectInput8Create_t)GetProcAddress((HMODULE)handle, "DirectInput8Create");
	//SetWindowsHookExA_real = SetWindowsHookExA;
	::DetourTransactionBegin();
	::DetourAttach(&(PVOID&)DirectInput8Create_real, DirectInput8Create_mine);
	//::DetourAttach(&(PVOID&)SetWindowsHookExA_real, SetWindowsHookExA_mine);
	::DetourTransactionCommit();

	CreateThread(NULL, NULL, ThreadProc, NULL, NULL, NULL);

	return 0;
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
	{
		CreateThread(NULL, NULL, AttachProc, NULL, NULL, NULL);
	}

    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

