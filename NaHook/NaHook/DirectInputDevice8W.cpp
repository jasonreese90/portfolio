#include "stdafx.h"
#include "DirectInputDevice8.h"

HRESULT __stdcall DirectInputDevice8W::QueryInterface(REFIID riid, LPVOID * ppvObj)
{
	return this->lpDevice->QueryInterface(riid, ppvObj);
}

ULONG __stdcall DirectInputDevice8W::AddRef()
{
	return this->lpDevice->AddRef();
}

ULONG __stdcall DirectInputDevice8W::Release()
{
	return this->lpDevice->Release();
}

/*** IDirectInputDevice8W methods ***/
HRESULT __stdcall DirectInputDevice8W::GetCapabilities(LPDIDEVCAPS lpDIDevCaps)
{
	return this->lpDevice->GetCapabilities(lpDIDevCaps);
}

HRESULT __stdcall DirectInputDevice8W::EnumObjects(LPDIENUMDEVICEOBJECTSCALLBACKW lpCallback, LPVOID pvRef, DWORD dwFlags)
{
	return this->lpDevice->EnumObjects(lpCallback, pvRef, dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::GetProperty(REFGUID rguid, LPDIPROPHEADER pdiph)
{
	return this->lpDevice->GetProperty(rguid, pdiph);
}

HRESULT __stdcall DirectInputDevice8W::SetProperty(REFGUID rguid, LPCDIPROPHEADER pdiph)
{
	return this->lpDevice->SetProperty(rguid, pdiph);
}

HRESULT __stdcall DirectInputDevice8W::Acquire()
{
	return this->lpDevice->Acquire();
}

HRESULT __stdcall DirectInputDevice8W::Unacquire()
{
	return this->lpDevice->Unacquire();
}

HRESULT __stdcall DirectInputDevice8W::GetDeviceState(DWORD cbData, LPVOID lpvData)
{
	return this->lpDevice->GetDeviceState(cbData, lpvData);
}

HRESULT __stdcall DirectInputDevice8W::GetDeviceData(DWORD cbObjectData, LPDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD dwFlags)
{
	return this->lpDevice->GetDeviceData(cbObjectData, rgdod, pdwInOut, dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::SetDataFormat(LPCDIDATAFORMAT lpdf)
{
	return this->lpDevice->SetDataFormat(lpdf);
}

HRESULT __stdcall DirectInputDevice8W::SetEventNotification(HANDLE hEvent)
{
	return this->lpDevice->SetEventNotification(hEvent);
}

HRESULT __stdcall DirectInputDevice8W::SetCooperativeLevel(HWND hwnd, DWORD dwFlags)
{
	return this->lpDevice->SetCooperativeLevel(hwnd, dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::GetObjectInfo(LPDIDEVICEOBJECTINSTANCEW pdidoi, DWORD dwObj, DWORD dwHow)
{
	return this->lpDevice->GetObjectInfo(pdidoi, dwObj, dwHow);
}

HRESULT __stdcall DirectInputDevice8W::GetDeviceInfo(LPDIDEVICEINSTANCEW pdidi)
{
	return this->lpDevice->GetDeviceInfo(pdidi);
}

HRESULT __stdcall DirectInputDevice8W::RunControlPanel(HWND hwndOwner, DWORD dwFlags)
{
	return this->lpDevice->RunControlPanel(hwndOwner, dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::Initialize(HINSTANCE hinst, DWORD dwVersion, REFGUID rguid)
{
	return this->lpDevice->Initialize(hinst, dwVersion, rguid);
}

HRESULT __stdcall DirectInputDevice8W::CreateEffect(REFGUID rguid, LPCDIEFFECT lpeff, LPDIRECTINPUTEFFECT * ppdeff, LPUNKNOWN punkOuter)
{
	return this->lpDevice->CreateEffect(rguid, lpeff, ppdeff, punkOuter);
}

HRESULT __stdcall DirectInputDevice8W::EnumEffects(LPDIENUMEFFECTSCALLBACKW lpCallback, LPVOID pvRef, DWORD dwEffType)
{
	return this->lpDevice->EnumEffects(lpCallback, pvRef, dwEffType);
}

HRESULT __stdcall DirectInputDevice8W::GetEffectInfo(LPDIEFFECTINFOW pdei, REFGUID rguid)
{
	return this->lpDevice->GetEffectInfo(pdei, rguid);
}

HRESULT __stdcall DirectInputDevice8W::GetForceFeedbackState(LPDWORD pdwOut)
{
	return this->lpDevice->GetForceFeedbackState(pdwOut);
}

HRESULT __stdcall DirectInputDevice8W::SendForceFeedbackCommand(DWORD dwFlags)
{
	return this->lpDevice->SendForceFeedbackCommand(dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::EnumCreatedEffectObjects(LPDIENUMCREATEDEFFECTOBJECTSCALLBACK lpCallback, LPVOID pvRef, DWORD fl)
{
	return this->lpDevice->EnumCreatedEffectObjects(lpCallback, pvRef, fl);
}

HRESULT __stdcall DirectInputDevice8W::Escape(LPDIEFFESCAPE pesc)
{
	return this->lpDevice->Escape(pesc);
}

HRESULT __stdcall DirectInputDevice8W::Poll()
{
	return this->lpDevice->Poll();
}

HRESULT __stdcall DirectInputDevice8W::SendDeviceData(DWORD cbObjectData, LPCDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD fl)
{
	return this->lpDevice->SendDeviceData(cbObjectData, rgdod, pdwInOut, fl);
}

HRESULT __stdcall DirectInputDevice8W::EnumEffectsInFile(LPCWSTR lpszFileName, LPDIENUMEFFECTSINFILECALLBACK pec, LPVOID pvRef, DWORD dwFlags)
{
	return this->lpDevice->EnumEffectsInFile(lpszFileName, pec, pvRef, dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::WriteEffectToFile(LPCWSTR lpszFileName, DWORD dwEntries, LPDIFILEEFFECT rgDiFileEft, DWORD dwFlags)
{
	return this->lpDevice->WriteEffectToFile(lpszFileName, dwEntries, rgDiFileEft, dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::BuildActionMap(LPDIACTIONFORMATW lpdiaf, LPCWSTR lpszUserName, DWORD dwFlags)
{
	return this->lpDevice->BuildActionMap(lpdiaf, lpszUserName, dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::SetActionMap(LPDIACTIONFORMATW lpdiActionFormat, LPCWSTR lptszUserName, DWORD dwFlags)
{
	return this->lpDevice->SetActionMap(lpdiActionFormat, lptszUserName, dwFlags);
}

HRESULT __stdcall DirectInputDevice8W::GetImageInfo(LPDIDEVICEIMAGEINFOHEADERW ldpiDevImageInfoHeader)
{
	return this->lpDevice->GetImageInfo(ldpiDevImageInfoHeader);
}