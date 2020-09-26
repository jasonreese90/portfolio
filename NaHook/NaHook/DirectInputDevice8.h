#pragma once
#include "dinput.h"


class DirectInputDevice8A : public IDirectInputDevice8A
{
private:
	LPDIRECTINPUTDEVICE8A lpDevice;
	BYTE m_keys[256];

public:

	DirectInputDevice8A(LPDIRECTINPUTDEVICE8A* lplpDevice)
	{
		this->lpDevice = *lplpDevice;
		for (int i = 0; i < 256; i++)
			this->m_keys[i] = 0;
	}

	HRESULT __stdcall QueryInterface(REFIID riid, LPVOID * ppvObj);
	ULONG __stdcall AddRef();
	ULONG __stdcall Release();

	/*** IDirectInputDevice8A methods ***/
	HRESULT __stdcall GetCapabilities(LPDIDEVCAPS lpDIDevCaps);
	HRESULT __stdcall EnumObjects(LPDIENUMDEVICEOBJECTSCALLBACKA lpCallback, LPVOID pvRef, DWORD dwFlags);
	HRESULT __stdcall GetProperty(REFGUID rguid, LPDIPROPHEADER pdiph);
	HRESULT __stdcall SetProperty(REFGUID rguid, LPCDIPROPHEADER pdiph);
	HRESULT __stdcall Acquire();
	HRESULT __stdcall Unacquire();
	HRESULT __stdcall GetDeviceState(DWORD cbData, LPVOID lpvData);
	HRESULT __stdcall GetDeviceData(DWORD cbObjectData, LPDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD dwFlags);
	HRESULT __stdcall SetDataFormat(LPCDIDATAFORMAT lpdf);
	HRESULT __stdcall SetEventNotification(HANDLE hEvent);
	HRESULT __stdcall SetCooperativeLevel(HWND hwnd, DWORD dwFlags);
	HRESULT __stdcall GetObjectInfo(LPDIDEVICEOBJECTINSTANCEA pdidoi, DWORD dwObj, DWORD dwHow);
	HRESULT __stdcall GetDeviceInfo(LPDIDEVICEINSTANCEA pdidi);
	HRESULT __stdcall RunControlPanel(HWND hwndOwner, DWORD dwFlags);
	HRESULT __stdcall Initialize(HINSTANCE hinst, DWORD dwVersion, REFGUID rguid);
	HRESULT __stdcall CreateEffect(REFGUID rguid, LPCDIEFFECT lpeff, LPDIRECTINPUTEFFECT * ppdeff, LPUNKNOWN punkOuter);
	HRESULT __stdcall EnumEffects(LPDIENUMEFFECTSCALLBACKA lpCallback, LPVOID pvRef, DWORD dwEffType);
	HRESULT __stdcall GetEffectInfo(LPDIEFFECTINFOA pdei, REFGUID rguid);
	HRESULT __stdcall GetForceFeedbackState(LPDWORD pdwOut);
	HRESULT __stdcall SendForceFeedbackCommand(DWORD dwFlags);
	HRESULT __stdcall EnumCreatedEffectObjects(LPDIENUMCREATEDEFFECTOBJECTSCALLBACK lpCallback, LPVOID pvRef, DWORD fl);
	HRESULT __stdcall Escape(LPDIEFFESCAPE pesc);
	HRESULT __stdcall Poll();
	HRESULT __stdcall SendDeviceData(DWORD cbObjectData, LPCDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD fl);
	HRESULT __stdcall EnumEffectsInFile(LPCSTR lpszFileName, LPDIENUMEFFECTSINFILECALLBACK pec, LPVOID pvRef, DWORD dwFlags);
	HRESULT __stdcall WriteEffectToFile(LPCSTR lpszFileName, DWORD dwEntries, LPDIFILEEFFECT rgDiFileEft, DWORD dwFlags);
	HRESULT __stdcall BuildActionMap(LPDIACTIONFORMATA lpdiaf, LPCSTR lpszUserName, DWORD dwFlags);
	HRESULT __stdcall SetActionMap(LPDIACTIONFORMATA lpdiActionFormat, LPCSTR lptszUserName, DWORD dwFlags);
	HRESULT __stdcall GetImageInfo(LPDIDEVICEIMAGEINFOHEADERA ldpiDevImageInfoHeader);

	void SetKey(BYTE key, bool down);
};

class DirectInputDevice8W : public IDirectInputDevice8W
{
private:
	LPDIRECTINPUTDEVICE8W lpDevice;

public:
	DirectInputDevice8W(LPDIRECTINPUTDEVICE8W* lplpDevice)
	{
		this->lpDevice = *lplpDevice;
	}

	HRESULT __stdcall QueryInterface(REFIID riid, LPVOID * ppvObj);
	ULONG __stdcall AddRef();
	ULONG __stdcall Release();

	/*** IDirectInputDevice8A methods ***/
	HRESULT __stdcall GetCapabilities(LPDIDEVCAPS lpDIDevCaps);
	HRESULT __stdcall EnumObjects(LPDIENUMDEVICEOBJECTSCALLBACKW lpCallback, LPVOID pvRef, DWORD dwFlags);
	HRESULT __stdcall GetProperty(REFGUID rguid, LPDIPROPHEADER pdiph);
	HRESULT __stdcall SetProperty(REFGUID rguid, LPCDIPROPHEADER pdiph);
	HRESULT __stdcall Acquire();
	HRESULT __stdcall Unacquire();
	HRESULT __stdcall GetDeviceState(DWORD cbData, LPVOID lpvData);
	HRESULT __stdcall GetDeviceData(DWORD cbObjectData, LPDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD dwFlags);
	HRESULT __stdcall SetDataFormat(LPCDIDATAFORMAT lpdf);
	HRESULT __stdcall SetEventNotification(HANDLE hEvent);
	HRESULT __stdcall SetCooperativeLevel(HWND hwnd, DWORD dwFlags);
	HRESULT __stdcall GetObjectInfo(LPDIDEVICEOBJECTINSTANCEW pdidoi, DWORD dwObj, DWORD dwHow);
	HRESULT __stdcall GetDeviceInfo(LPDIDEVICEINSTANCEW pdidi);
	HRESULT __stdcall RunControlPanel(HWND hwndOwner, DWORD dwFlags);
	HRESULT __stdcall Initialize(HINSTANCE hinst, DWORD dwVersion, REFGUID rguid);
	HRESULT __stdcall CreateEffect(REFGUID rguid, LPCDIEFFECT lpeff, LPDIRECTINPUTEFFECT * ppdeff, LPUNKNOWN punkOuter);
	HRESULT __stdcall EnumEffects(LPDIENUMEFFECTSCALLBACKW lpCallback, LPVOID pvRef, DWORD dwEffType);
	HRESULT __stdcall GetEffectInfo(LPDIEFFECTINFOW pdei, REFGUID rguid);
	HRESULT __stdcall GetForceFeedbackState(LPDWORD pdwOut);
	HRESULT __stdcall SendForceFeedbackCommand(DWORD dwFlags);
	HRESULT __stdcall EnumCreatedEffectObjects(LPDIENUMCREATEDEFFECTOBJECTSCALLBACK lpCallback, LPVOID pvRef, DWORD fl);
	HRESULT __stdcall Escape(LPDIEFFESCAPE pesc);
	HRESULT __stdcall Poll();
	HRESULT __stdcall SendDeviceData(DWORD cbObjectData, LPCDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD fl);
	HRESULT __stdcall EnumEffectsInFile(LPCWSTR lpszFileName, LPDIENUMEFFECTSINFILECALLBACK pec, LPVOID pvRef, DWORD dwFlags);
	HRESULT __stdcall WriteEffectToFile(LPCWSTR lpszFileName, DWORD dwEntries, LPDIFILEEFFECT rgDiFileEft, DWORD dwFlags);
	HRESULT __stdcall BuildActionMap(LPDIACTIONFORMATW lpdiaf, LPCWSTR lpszUserName, DWORD dwFlags);
	HRESULT __stdcall SetActionMap(LPDIACTIONFORMATW lpdiActionFormat, LPCWSTR lptszUserName, DWORD dwFlags);
	HRESULT __stdcall GetImageInfo(LPDIDEVICEIMAGEINFOHEADERW ldpiDevImageInfoHeader);
};