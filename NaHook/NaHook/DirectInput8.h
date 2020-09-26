#pragma once
#include "dinput.h"
#include "DirectInputDevice8.h"

extern DirectInputDevice8A* keyboard;

class DirectInput8A : public IDirectInput8A
{
private:
	LPDIRECTINPUT8A lpDi;
public:

	DirectInput8A(LPDIRECTINPUT8A* lplpDi)
	{
		this->lpDi = *lplpDi;
	}


	HRESULT __stdcall QueryInterface(REFIID riid, LPVOID * ppvObj);
	ULONG __stdcall AddRef();
	ULONG __stdcall Release();

	/*** IDirectInput8A methods ***/
	HRESULT __stdcall CreateDevice(REFGUID rguid, LPDIRECTINPUTDEVICE8A * lplpDirectInputDevice, LPUNKNOWN pUnkOuter);
	HRESULT __stdcall EnumDevices(DWORD dwDevType, LPDIENUMDEVICESCALLBACKA lpCallback, LPVOID pvRef, DWORD dwFlags);
	HRESULT __stdcall GetDeviceStatus(REFGUID rguid);
	HRESULT __stdcall RunControlPanel(HWND hwndOwner, DWORD dwFlags);
	HRESULT __stdcall Initialize(HINSTANCE hinst, DWORD dwVersion);
	HRESULT __stdcall FindDevice(REFGUID rguid, LPCSTR ptszName, LPGUID pguidInstance);
	HRESULT __stdcall EnumDevicesBySemantics(LPCSTR ptszUserName, LPDIACTIONFORMATA lpdiActionFormat, LPDIENUMDEVICESBYSEMANTICSCBA lpCallback, LPVOID pvRef, DWORD dwFlags);
	HRESULT __stdcall ConfigureDevices(LPDICONFIGUREDEVICESCALLBACK lpdiCallback, LPDICONFIGUREDEVICESPARAMSA lpdiCDParams, DWORD dwFlags, LPVOID pvRefData);
};

class DirectInput8W : public IDirectInput8W
{
private:
	LPDIRECTINPUT8W lpDi;
public:

	DirectInput8W(LPDIRECTINPUT8W* lplpDi)
	{
		this->lpDi = *lplpDi;
	}

	HRESULT __stdcall QueryInterface(REFIID riid, LPVOID * ppvObj);
	ULONG __stdcall AddRef();
	ULONG __stdcall Release();

	/*** IDirectInput8A methods ***/
	HRESULT __stdcall CreateDevice(REFGUID rguid, LPDIRECTINPUTDEVICE8W * lplpDirectInputDevice, LPUNKNOWN pUnkOuter);
	HRESULT __stdcall EnumDevices(DWORD dwDevType, LPDIENUMDEVICESCALLBACKW lpCallback, LPVOID pvRef, DWORD dwFlags);
	HRESULT __stdcall GetDeviceStatus(REFGUID rguid);
	HRESULT __stdcall RunControlPanel(HWND hwndOwner, DWORD dwFlags);
	HRESULT __stdcall Initialize(HINSTANCE hinst, DWORD dwVersion);
	HRESULT __stdcall FindDevice(REFGUID rguid, LPCWSTR ptszName, LPGUID pguidInstance);
	HRESULT __stdcall EnumDevicesBySemantics(LPCWSTR ptszUserName, LPDIACTIONFORMATW lpdiActionFormat, LPDIENUMDEVICESBYSEMANTICSCBW lpCallback, LPVOID pvRef, DWORD dwFlags);
	HRESULT __stdcall ConfigureDevices(LPDICONFIGUREDEVICESCALLBACK lpdiCallback, LPDICONFIGUREDEVICESPARAMSW lpdiCDParams, DWORD dwFlags, LPVOID pvRefData);
};