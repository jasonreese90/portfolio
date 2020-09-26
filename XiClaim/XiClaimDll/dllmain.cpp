// dllmain.cpp : Defines the entry point for the DLL application.
#include "framework.h"
#include <stdio.h>
#include <ProcLib.h>
#include "SignatureScan.h"
#include <detours.h>
#include <WinSock2.h>
#include "dinput.h""
#include <vector> 
#include <queue>

#pragma comment(lib, "Ws2_32.lib")

using namespace std;


#define IN_SENDSTRING 0
#define IN_SETTARGET 1
#define IN_ADDTOCHAT 2
#define IN_SETKEY 3
#define IN_BLOCKKB 4

#define OUT_RECV 0

typedef void(__cdecl* SendString_t)(char* text, int code);
typedef void(__fastcall* SetTarget_t)(void* pThis, void* pUnused, void* pEntity, BYTE unk0, BYTE unk1);
typedef void(__fastcall* AddToChat_t)(void* pThis, void* pUnused, char* text, int* color, int indent, int unk0, int unk1);
typedef HRESULT(__stdcall* GetDeviceState_t)(IDirectInputDevice8A* pThis, DWORD cbData, LPVOID lpvData);
typedef HRESULT(__stdcall* SetCooperativeLevel_t)(IDirectInputDevice8A* pThis, HWND hwnd, DWORD dwFlags);
typedef HRESULT(__stdcall* GetDeviceData_t)(IDirectInputDevice8A* pThis, DWORD cbObjectData, LPDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD dwFlags);
typedef unsigned int(__cdecl* DecryptPacket_t) (void* pDecrypted, unsigned int iDecryptedBufferSize, void* pUnknown, void* pUnknown2, void* pRaw, unsigned int iRawPacketSize);
typedef SHORT(WINAPI* GetKeyState_t)(int nVirtKey);
typedef HHOOK(WINAPI* SetWindowsHookExA_t)(int idHook, HOOKPROC  lpfn, HINSTANCE hmod, DWORD  dwThreadId);
typedef LRESULT(CALLBACK* KeyboardProcLowLevel_t)(int code, WPARAM wParam, LPARAM lParam);
typedef BOOL(WINAPI* GetKeyboardState_t)(PBYTE lpKeystate);

SendString_t SendString;
SetTarget_t SetTarget;
AddToChat_t AddToChat;
DecryptPacket_t DecryptPacket;
GetDeviceState_t GetDeviceState_real;
SetCooperativeLevel_t SetCooperativeLevel_real;
GetDeviceData_t GetDeviceData_real;
GetKeyState_t GetKeyState_real;
KeyboardProcLowLevel_t KeyboardProcLowLevel_real;
SetWindowsHookExA_t SetWindowsHookExA_real;
GetKeyboardState_t GetKeyboardState_real;

HWND gameHwnd;

BOOL BlockKB = FALSE;
BOOL* chatInputOpen;

struct OutCommand
{
	BYTE id;
	unsigned int len;
	unsigned char* buffer[10000];
};

SOCKET server;
vector<SOCKET> clients;
queue<OutCommand> commands;

void* addToChatPtr = nullptr;

BYTE m_keys[256];

struct Command
{
	BYTE id;
	BYTE data[256];
};

struct Target
{
	DWORD pThis;
	DWORD pEntity;
	BYTE unk0;
	BYTE unk1;
};

struct Chat
{
	char text[128];
	int color;
	int indent;
	int unk0;
	int unk1;
};

struct SetKey
{
	BYTE key;
	bool state;
};

DWORD controlKeys[16] = { DIK_SPACE, DIK_LCONTROL, DIK_RCONTROL, DIK_LALT, DIK_RALT, DIK_LSHIFT, DIK_RSHIFT, DIK_CAPSLOCK, DIK_TAB, DIK_RETURN, DIK_BACKSPACE, DIK_ESCAPE, DIK_LEFT, DIK_RIGHT, DIK_UP, DIK_DOWN };

#define KEYMAPPING(key1, key2) case key1: return key2;

int VKToDIK(int key)
{
	switch (key)
	{
		KEYMAPPING(VK_RETURN, DIK_RETURN);
		KEYMAPPING(VK_BACK, DIK_BACK)
			KEYMAPPING(VK_TAB, DIK_TAB)
			//KEYMAPPING(VK_CLEAR, DIK_CLEAR)
			KEYMAPPING(VK_SHIFT, DIK_LSHIFT)
			KEYMAPPING(VK_LSHIFT, DIK_LSHIFT)
			KEYMAPPING(VK_RSHIFT, DIK_RSHIFT)
			KEYMAPPING(VK_CONTROL, DIK_LCONTROL)
			KEYMAPPING(VK_MENU, DIK_LALT)
			KEYMAPPING(VK_PAUSE, DIK_PAUSE)
			KEYMAPPING(VK_CAPITAL, DIK_CAPITAL)
			KEYMAPPING(VK_KANA, DIK_KANA)
			//KEYMAPPING(VK_HANGUL, DIK_HANGUL)
			//KEYMAPPING(VK_JUNJA, DIK_JUNJA)
			//KEYMAPPING(VK_FINAL, DIK_FINAL)
			//KEYMAPPING(VK_HANJA, DIK_HANJA)
			KEYMAPPING(VK_ESCAPE, DIK_ESCAPE)
			KEYMAPPING(VK_CONVERT, DIK_CONVERT)
			KEYMAPPING(VK_NONCONVERT, DIK_NOCONVERT)
			//KEYMAPPING(VK_ACCEPT, DIK_ACCEPT)
			//KEYMAPPING(VK_MODECHANGE, DIK_MODECHANGE)
			KEYMAPPING(VK_SPACE, DIK_SPACE)
			KEYMAPPING(VK_PRIOR, DIK_PRIOR)
			KEYMAPPING(VK_NEXT, DIK_NEXT)
			KEYMAPPING(VK_END, DIK_END)
			KEYMAPPING(VK_HOME, DIK_HOME)
			KEYMAPPING(VK_LEFT, DIK_LEFT)
			KEYMAPPING(VK_UP, DIK_UP)
			KEYMAPPING(VK_RIGHT, DIK_RIGHT)
			KEYMAPPING(VK_DOWN, DIK_DOWN)
			//KEYMAPPING(VK_SELECT, DIK_SELECT)
			KEYMAPPING(VK_PRINT, DIK_SYSRQ)
			//KEYMAPPING(VK_EXECUTE, DIK_EXECUTE)
			//KEYMAPPING(VK_SNAPSHOT, DIK_SNAPSHOT)
			KEYMAPPING(VK_INSERT, DIK_INSERT)
			KEYMAPPING(VK_DELETE, DIK_DELETE)
			//KEYMAPPING(VK_HELP, DIK_HELP)
			KEYMAPPING('A', DIK_A)
			KEYMAPPING('B', DIK_B)
			KEYMAPPING('C', DIK_C)
			KEYMAPPING('D', DIK_D)
			KEYMAPPING('E', DIK_E)
			KEYMAPPING('F', DIK_F)
			KEYMAPPING('G', DIK_G)
			KEYMAPPING('H', DIK_H)
			KEYMAPPING('I', DIK_I)
			KEYMAPPING('J', DIK_J)
			KEYMAPPING('K', DIK_K)
			KEYMAPPING('L', DIK_L)
			KEYMAPPING('M', DIK_M)
			KEYMAPPING('N', DIK_N)
			KEYMAPPING('O', DIK_O)
			KEYMAPPING('P', DIK_P)
			KEYMAPPING('Q', DIK_Q)
			KEYMAPPING('R', DIK_R)
			KEYMAPPING('S', DIK_S)
			KEYMAPPING('T', DIK_T)
			KEYMAPPING('U', DIK_U)
			KEYMAPPING('V', DIK_V)
			KEYMAPPING('W', DIK_W)
			KEYMAPPING('X', DIK_X)
			KEYMAPPING('Y', DIK_Y)
			KEYMAPPING('Z', DIK_Z)
			KEYMAPPING('1', DIK_1)
			KEYMAPPING('2', DIK_2)
			KEYMAPPING('3', DIK_3)
			KEYMAPPING('4', DIK_4)
			KEYMAPPING('5', DIK_5)
			KEYMAPPING('6', DIK_6)
			KEYMAPPING('7', DIK_7)
			KEYMAPPING('8', DIK_8)
			KEYMAPPING('9', DIK_9)
			KEYMAPPING('0', DIK_0)
			KEYMAPPING(VK_LWIN, DIK_LWIN)
			KEYMAPPING(VK_RWIN, DIK_RWIN)
			KEYMAPPING(VK_APPS, DIK_APPS)
			KEYMAPPING(VK_SLEEP, DIK_SLEEP)
			KEYMAPPING(VK_NUMPAD0, DIK_NUMPAD0)
			KEYMAPPING(VK_NUMPAD1, DIK_NUMPAD1)
			KEYMAPPING(VK_NUMPAD2, DIK_NUMPAD2)
			KEYMAPPING(VK_NUMPAD3, DIK_NUMPAD3)
			KEYMAPPING(VK_NUMPAD4, DIK_NUMPAD4)
			KEYMAPPING(VK_NUMPAD5, DIK_NUMPAD5)
			KEYMAPPING(VK_NUMPAD6, DIK_NUMPAD6)
			KEYMAPPING(VK_NUMPAD7, DIK_NUMPAD7)
			KEYMAPPING(VK_NUMPAD8, DIK_NUMPAD8)
			KEYMAPPING(VK_NUMPAD9, DIK_NUMPAD9)
			KEYMAPPING(VK_MULTIPLY, DIK_MULTIPLY)
			KEYMAPPING(VK_ADD, DIK_ADD)
			//KEYMAPPING(VK_SEPARATOR, DIK_SEPARATOR)
			KEYMAPPING(VK_SUBTRACT, DIK_SUBTRACT)
			KEYMAPPING(VK_DECIMAL, DIK_DECIMAL)
			KEYMAPPING(VK_DIVIDE, DIK_DIVIDE)
			KEYMAPPING(VK_F1, DIK_F1)
			KEYMAPPING(VK_F2, DIK_F2)
			KEYMAPPING(VK_F3, DIK_F3)
			KEYMAPPING(VK_F4, DIK_F4)
			KEYMAPPING(VK_F5, DIK_F5)
			KEYMAPPING(VK_F6, DIK_F6)
			KEYMAPPING(VK_F7, DIK_F7)
			KEYMAPPING(VK_F8, DIK_F8)
			KEYMAPPING(VK_F9, DIK_F9)
			KEYMAPPING(VK_F10, DIK_F10)
			KEYMAPPING(VK_F11, DIK_F11)
			KEYMAPPING(VK_F12, DIK_F12)
			KEYMAPPING(VK_F13, DIK_F13)
			KEYMAPPING(VK_F14, DIK_F14)
			KEYMAPPING(VK_F15, DIK_F15)
			KEYMAPPING(VK_NUMLOCK, DIK_NUMLOCK)
			KEYMAPPING(VK_SCROLL, DIK_SCROLL)
			KEYMAPPING(VK_LCONTROL, DIK_LCONTROL)
			KEYMAPPING(VK_RCONTROL, DIK_RCONTROL)
			KEYMAPPING(VK_LMENU, DIK_LMENU)
			KEYMAPPING(VK_RMENU, DIK_RMENU)
			KEYMAPPING(VK_OEM_1, DIK_SEMICOLON)
			KEYMAPPING(VK_OEM_PLUS, DIK_EQUALS)
			KEYMAPPING(VK_OEM_COMMA, DIK_COMMA)
			KEYMAPPING(VK_OEM_MINUS, DIK_MINUS)
			KEYMAPPING(VK_OEM_PERIOD, DIK_PERIOD)
			KEYMAPPING(VK_OEM_2, DIK_SLASH)
			KEYMAPPING(VK_OEM_3, DIK_GRAVE)
			KEYMAPPING(VK_OEM_4, DIK_LBRACKET)
			KEYMAPPING(VK_OEM_5, DIK_BACKSLASH)
			KEYMAPPING(VK_OEM_6, DIK_RBRACKET)
			KEYMAPPING(VK_OEM_7, DIK_APOSTROPHE)
	}

	return -1;
}


unsigned int __cdecl DecryptPacket_mine(void* pDecrypted, unsigned int iDecryptedBufferSize, void* pUnknown, void* pUnknown2, void* pRaw, unsigned int iRawPacketSize)
{
	unsigned int len = DecryptPacket(pDecrypted, iDecryptedBufferSize, pUnknown, pUnknown2, pRaw, iRawPacketSize);
	OutCommand oc;
	ZeroMemory(&oc, sizeof(oc));
	oc.id = OUT_RECV;
	memcpy_s(oc.buffer, 10000, pDecrypted, len);
	oc.len = len;
	commands.push(oc);
	return len;
}

void SetKeyState(BYTE key, bool down)
{
	if (down)
		m_keys[key] = 0x80;
	else
		m_keys[key] = 0x90;
}

DWORD WINAPI ThreadProc(LPVOID lpParameter)
{
	char buffer[16384];
	DWORD dwRead;
	char pipeName[256];
	sprintf_s(pipeName, "\\\\.\\pipe\\XiLib_%d", GetCurrentProcessId());

	HANDLE hPipe = CreateNamedPipeA(pipeName, PIPE_ACCESS_INBOUND, PIPE_TYPE_BYTE | PIPE_READMODE_BYTE | PIPE_WAIT, PIPE_UNLIMITED_INSTANCES, 16384, 16384, NMPWAIT_USE_DEFAULT_WAIT, NULL);

	while (hPipe != INVALID_HANDLE_VALUE)
	{
		if (ConnectNamedPipe(hPipe, NULL) != FALSE)
		{
			while (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
			{
				buffer[dwRead] = '\0';

				Command* c = (Command*)& buffer;

				switch (c->id)
				{
				case IN_SENDSTRING:
				{
					char string[256];
					sprintf_s(string, "%s", c->data);
					SendString(string, 1);

					break;
				}
				case IN_SETTARGET:
				{
					Target* t = (Target*)& c->data;
					SetTarget((void*)t->pThis, NULL, (void*)t->pEntity, t->unk0, t->unk1);

					break;
				}
				case IN_ADDTOCHAT:
				{
					Chat* chat = (Chat*)& c->data;
					AddToChat(addToChatPtr, NULL, chat->text, &chat->color, chat->indent, chat->unk0, chat->unk1);
					break;
				}

				case IN_SETKEY:
				{
					SetKey* sk = (SetKey*)& c->data;
					SetKeyState(sk->key, sk->state);

					break;
				}

				case IN_BLOCKKB:
				{

					BlockKB = *(BOOL*)& c->data;
					break;
				}

				}
			}
		}

		DisconnectNamedPipe(hPipe);
	}

	return 0;
}

DWORD WINAPI AcceptProc(LPVOID lpParameter)
{
	while (1)
	{
		SOCKADDR_IN clientAddr;
		SOCKET client;
		int clientAddrSize = sizeof(clientAddr);

		if ((client = accept(server, (SOCKADDR*)& clientAddr, &clientAddrSize)) != INVALID_SOCKET)
		{
			clients.push_back(client);
		}
	}
}

DWORD WINAPI ServerProc(LPVOID lpParameter)
{
	while (1)
	{
		while (!commands.empty())
		{
			OutCommand command = commands.front();
			//int len = strlen(command);

			for (SOCKET& client : clients)
			{
				int ret = send(client, (char*)& command, command.len + 5, 0);
				if (ret == WSAENOTCONN || ret == WSAESHUTDOWN || ret == WSAECONNABORTED || ret == WSAECONNRESET || ret == WSAETIMEDOUT)
				{
					closesocket(client);
					remove(clients.begin(), clients.end(), client);
					//cout << "Client disconnected." << endl;
				}
			}

			commands.pop();
		}
	}
}

BOOL IsControlKey(DWORD key)
{
	for (int i = 0; i < 16; i++)
	{
		if (controlKeys[i] == key)
			return TRUE;
	}

	return FALSE;
}

HRESULT __stdcall GetDeviceData_mine(IDirectInputDevice8A * pThis, DWORD cbObjectData, LPDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD dwFlags)
{
	if (BlockKB)
	{
		//if (*pdwInOut > 0)
		/*{
			for (int i = 0; i < *pdwInOut; i++)
			{
				DWORD key = rgdod[i].dwOfs;

				if(key != DIK_SPACE || key != DIK_ESCAPE || key != DIK_UPARROW || key != DIK_DOWNARROW || !=)


			}
		}*/
		//rgdod = NULL;
		//*pdwInOut = 0;
		return DI_OK;
	}

	return GetDeviceData_real(pThis, cbObjectData, rgdod, pdwInOut, dwFlags);
}

HRESULT __stdcall GetDeviceState_mine(IDirectInputDevice8A * pThis, DWORD cbData, LPVOID lpvData)
{

	HRESULT hres = GetDeviceState_real(pThis, cbData, lpvData);
	BYTE* state = (BYTE*)lpvData;

	if (BlockKB)
	{
		for (DWORD i = 0; i < 256; i++)
		{
			//if(!*chatInputOpen && !IsControlKey(i))
			state[i] = 0;
		}
	}

	bool foreground = (GetForegroundWindow() == gameHwnd);


	if (foreground)
	{
		switch (hres)
		{
		case DIERR_INPUTLOST:
			pThis->Acquire();
			if (hres == DIERR_INVALIDPARAM || hres == DIERR_NOTINITIALIZED)
				return DI_OK;

			hres = GetDeviceState_real(pThis, cbData, lpvData);
			if (hres != DI_OK)
				return DI_OK;

			break;
		case DIERR_NOTACQUIRED:
			pThis->Acquire();
			if (hres == DIERR_INVALIDPARAM || hres == DIERR_NOTINITIALIZED)
				return DI_OK;
			hres = GetDeviceState_real(pThis, cbData, lpvData);
			if (hres != DI_OK)
				return DI_OK;

			break;
		case DIERR_NOTINITIALIZED:
			return hres;
		}
	}

	for (DWORD i = 0; i < 256; i++)
	{
		if (m_keys[i] == 0x80)
		{
			state[i] = 0x80;
		}

		else if (m_keys[i] == 0x90)
		{
			m_keys[i] = state[i] = 0;
		}
	}



	return  DI_OK;
}

HRESULT __stdcall SetCooperativeLevel_mine(IDirectInputDevice8A * pThis, HWND hwnd, DWORD dwFlags)
{
	gameHwnd = hwnd;

	return SetCooperativeLevel_real(pThis, hwnd, dwFlags);
}

SHORT __stdcall GetKeyState_mine(int nVirtKey)
{
	if (BlockKB)
		return 0;

	return GetKeyState_real(nVirtKey);
}

LRESULT CALLBACK KeyboardProcLowLevel_mine(int code, WPARAM wParam, LPARAM lParam)
{
	if (BlockKB)
		return 0;

	return KeyboardProcLowLevel_real(code, wParam, lParam);
}


HHOOK WINAPI SetWindowsHookExA_mine(int idHook, HOOKPROC  lpfn, HINSTANCE hmod, DWORD  dwThreadId)
{
	if (idHook == WH_KEYBOARD_LL || idHook == WH_KEYBOARD)
	{
		KeyboardProcLowLevel_real = lpfn;
		lpfn = KeyboardProcLowLevel_mine;
		return SetWindowsHookExA_real(idHook, lpfn, hmod, dwThreadId);
	}

	return SetWindowsHookExA_real(idHook, lpfn, hmod, dwThreadId);
}


BOOL WINAPI GetKeyboardState_mine(PBYTE lpKeyState)
{
	if (BlockKB)
	{
		ZeroMemory(lpKeyState, 256);
		return TRUE;
	}
	return GetKeyboardState_real(lpKeyState);
}



void SetupServer()
{
	WSADATA WSAData;

	SOCKADDR_IN serverAddr;


	WSAStartup(MAKEWORD(2, 0), &WSAData);
	server = socket(AF_INET, SOCK_STREAM, 0);

	serverAddr.sin_addr.s_addr = INADDR_ANY;
	serverAddr.sin_family = AF_INET;
	serverAddr.sin_port = htons(65535 - GetCurrentProcessId());

	bind(server, (SOCKADDR*)& serverAddr, sizeof(serverAddr));
	listen(server, 0);
}

BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	{
		Process p(GetCurrentProcessId());
		ProcessModuleArray pma;
		ProcessModule procMod;

		p.getModules(&pma);

		for (ProcessModule& pm : pma)
		{
			if (pm.getName() == L"FFXiMain.dll")
			{
				procMod = pm;
			}
		}

		SignatureScan ss(p, procMod);

		//if (ffxiMain == 0)
		//{
		//	MessageBoxA(NULL, "Can't find FFXiMain.", "Error", MB_OK);
		//	return FALSE;
		//}

		SendString = (SendString_t)(ss.FindRelativeSignature("85C0750F8B4424086A0150E8"));
		SetTarget = (SetTarget_t)(ss.FindRelativeSignature("6A006A00578BCEE8"));
		AddToChat = (AddToChat_t)(ss.FindRelativeSignature("52884424198844241AE8"));
		DecryptPacket = (DecryptPacket_t)(ss.FindRelativeSignature("681027000051E8"));
		addToChatPtr = (void*)(*(DWORD*)ss.FindSignature("8D4C240C6A006A016A0050518B0D"));
		chatInputOpen = (BOOL*)(*(DWORD*)ss.FindSignature("83F8FF74148B0D") + 0x10D);
		//ReadProcessMemory(p.getHandle(), ss.FindSignature("8D4C240C6A006A016A0050518B0D"), &addToChatPtr,  sizeof(void*), 0);


		for (ProcessModule& pm : pma)
		{
			std::wstring pmName = pm.getName();
			std::transform(pmName.begin(), pmName.end(), pmName.begin(), towlower);
			if (pmName == L"dinput8.dll")
			{
				procMod = pm;
			}
		}

		ss = SignatureScan(p, procMod);
		void* dVtablePtr = ss.FindSignature("558BEC5151568B7508BA");
		void* pGetState = (void*)(*((DWORD*)dVtablePtr + 0x09));
		void* pSetCoop = (void*)(*((DWORD*)dVtablePtr + 0x0D));
		void* pGetDvcData = (void*)(*((DWORD*)dVtablePtr + 0x0A));

		GetDeviceState_real = (GetDeviceState_t)pGetState;
		SetCooperativeLevel_real = (SetCooperativeLevel_t)pSetCoop;
		GetDeviceData_real = (GetDeviceData_t)pGetDvcData;

		GetKeyState_real = GetKeyState;
		SetWindowsHookExA_real = SetWindowsHookExA;
		GetKeyboardState_real = GetKeyboardState;

		::DetourTransactionBegin();
		::DetourAttach(&(PVOID&)DecryptPacket, DecryptPacket_mine);
		::DetourAttach(&(PVOID&)GetDeviceState_real, GetDeviceState_mine);
		::DetourAttach(&(PVOID&)SetCooperativeLevel_real, SetCooperativeLevel_mine);
		::DetourAttach(&(PVOID&)GetDeviceData_real, GetDeviceData_mine);
		::DetourAttach(&(PVOID&)GetKeyState_real, GetKeyState_mine);
		::DetourAttach(&(PVOID&)SetWindowsHookExA_real, SetWindowsHookExA_mine);
		::DetourAttach(&(PVOID&)GetKeyboardState_real, GetKeyboardState_mine);
		::DetourTransactionCommit();

		SetupServer();
		CreateThread(NULL, NULL, AcceptProc, NULL, NULL, NULL);
		CreateThread(NULL, NULL, ServerProc, NULL, NULL, NULL);
		CreateThread(NULL, NULL, ThreadProc, NULL, NULL, NULL);
	}

	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

