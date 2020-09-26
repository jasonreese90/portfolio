#include "stdafx.h"
#include "DirectInput8.h"


DirectInputDevice8A* keyboard = NULL;

HRESULT __stdcall DirectInput8A::QueryInterface(REFIID riid, LPVOID * ppvObj)
{
	return this->lpDi->QueryInterface(riid, ppvObj);
}

ULONG __stdcall DirectInput8A::AddRef()
{
	return this->lpDi->AddRef();
}

ULONG __stdcall DirectInput8A::Release()
{
	return this->lpDi->Release();
}

/*** IDirectInput8A methods ***/
HRESULT __stdcall DirectInput8A::CreateDevice(REFGUID rguid, LPDIRECTINPUTDEVICE8A * lplpDirectInputDevice, LPUNKNOWN pUnkOuter)
{
	if (rguid == GUID_SysKeyboard)
	{
		IDirectInputDevice8A*  lpDevice;

		HRESULT res = this->lpDi->CreateDevice(rguid, &lpDevice, pUnkOuter);

		if (keyboard != NULL)
		{
			delete keyboard;
			keyboard = NULL;
		}

		keyboard = new DirectInputDevice8A(&lpDevice);
		*lplpDirectInputDevice = keyboard;
		return res;
	}

	return this->lpDi->CreateDevice(rguid, lplpDirectInputDevice, pUnkOuter);
}

HRESULT __stdcall DirectInput8A::EnumDevices(DWORD dwDevType, LPDIENUMDEVICESCALLBACKA lpCallback, LPVOID pvRef, DWORD dwFlags)
{
	return this->lpDi->EnumDevices(dwDevType, lpCallback, pvRef, dwFlags);
}

HRESULT __stdcall DirectInput8A::GetDeviceStatus(REFGUID rguid)
{
	return this->lpDi->GetDeviceStatus(rguid);
}

HRESULT __stdcall DirectInput8A::RunControlPanel(HWND hwndOwner, DWORD dwFlags)
{
	return this->lpDi->RunControlPanel(hwndOwner, dwFlags);
}

HRESULT __stdcall DirectInput8A::Initialize(HINSTANCE hinst, DWORD dwVersion)
{
	return this->lpDi->Initialize(hinst, dwVersion);
}

HRESULT __stdcall DirectInput8A::FindDevice(REFGUID rguid, LPCSTR ptszName, LPGUID pguidInstance)
{
	return this->lpDi->FindDevice(rguid, ptszName, pguidInstance);
}

HRESULT __stdcall DirectInput8A::EnumDevicesBySemantics(LPCSTR ptszUserName, LPDIACTIONFORMATA lpdiActionFormat, LPDIENUMDEVICESBYSEMANTICSCBA lpCallback, LPVOID pvRef, DWORD dwFlags)
{
	return this->lpDi->EnumDevicesBySemantics(ptszUserName, lpdiActionFormat, lpCallback, pvRef, dwFlags);
}

HRESULT __stdcall DirectInput8A::ConfigureDevices(LPDICONFIGUREDEVICESCALLBACK lpdiCallback, LPDICONFIGUREDEVICESPARAMSA lpdiCDParams, DWORD dwFlags, LPVOID pvRefData)
{
	return this->lpDi->ConfigureDevices(lpdiCallback, lpdiCDParams, dwFlags, pvRefData);
}
