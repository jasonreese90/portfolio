#include "stdafx.h"
#include "DirectInput8.h"

HRESULT __stdcall DirectInput8W::QueryInterface(REFIID riid, LPVOID * ppvObj)
{
	return this->lpDi->QueryInterface(riid, ppvObj);
}

ULONG __stdcall DirectInput8W::AddRef()
{
	return this->lpDi->AddRef();
}

ULONG __stdcall DirectInput8W::Release()
{
	return this->lpDi->Release();
}

/*** IDirectInput8W methods ***/
HRESULT __stdcall DirectInput8W::CreateDevice(REFGUID rguid, LPDIRECTINPUTDEVICE8W * lplpDirectInputDevice, LPUNKNOWN pUnkOuter)
{
	MessageBoxA(NULL, "CreateW", "", NULL);
	return this->lpDi->CreateDevice(rguid, lplpDirectInputDevice, pUnkOuter);
}

HRESULT __stdcall DirectInput8W::EnumDevices(DWORD dwDevType, LPDIENUMDEVICESCALLBACKW lpCallback, LPVOID pvRef, DWORD dwFlags)
{
	return this->lpDi->EnumDevices(dwDevType, lpCallback, pvRef, dwFlags);
}

HRESULT __stdcall DirectInput8W::GetDeviceStatus(REFGUID rguid)
{
	return this->lpDi->GetDeviceStatus(rguid);
}

HRESULT __stdcall DirectInput8W::RunControlPanel(HWND hwndOwner, DWORD dwFlags)
{
	return this->lpDi->RunControlPanel(hwndOwner, dwFlags);
}

HRESULT __stdcall DirectInput8W::Initialize(HINSTANCE hinst, DWORD dwVersion)
{
	return this->lpDi->Initialize(hinst, dwVersion);
}

HRESULT __stdcall DirectInput8W::FindDevice(REFGUID rguid, LPCWSTR ptszName, LPGUID pguidInstance)
{
	return this->lpDi->FindDevice(rguid, ptszName, pguidInstance);
}

HRESULT __stdcall DirectInput8W::EnumDevicesBySemantics(LPCWSTR ptszUserName, LPDIACTIONFORMATW lpdiActionFormat, LPDIENUMDEVICESBYSEMANTICSCBW lpCallback, LPVOID pvRef, DWORD dwFlags)
{
	return this->lpDi->EnumDevicesBySemantics(ptszUserName, lpdiActionFormat, lpCallback, pvRef, dwFlags);
}

HRESULT __stdcall DirectInput8W::ConfigureDevices(LPDICONFIGUREDEVICESCALLBACK lpdiCallback, LPDICONFIGUREDEVICESPARAMSW lpdiCDParams, DWORD dwFlags, LPVOID pvRefData)
{
	return this->lpDi->ConfigureDevices(lpdiCallback, lpdiCDParams, dwFlags, pvRefData);
}
