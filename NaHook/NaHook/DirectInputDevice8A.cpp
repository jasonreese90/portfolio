#include "stdafx.h"
#include "DirectInputDevice8.h"
#include <stdio.h>

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
HRESULT __stdcall DirectInputDevice8A::QueryInterface(REFIID riid, LPVOID * ppvObj)
{
	return this->lpDevice->QueryInterface(riid, ppvObj);
}

ULONG __stdcall DirectInputDevice8A::AddRef()
{
	return this->lpDevice->AddRef();
}

ULONG __stdcall DirectInputDevice8A::Release()
{
	return this->lpDevice->Release();
}

/*** IDirectInputDevice8A methods ***/
HRESULT __stdcall DirectInputDevice8A::GetCapabilities(LPDIDEVCAPS lpDIDevCaps)
{
	return this->lpDevice->GetCapabilities(lpDIDevCaps);
}

HRESULT __stdcall DirectInputDevice8A::EnumObjects(LPDIENUMDEVICEOBJECTSCALLBACKA lpCallback, LPVOID pvRef, DWORD dwFlags)
{
	return this->lpDevice->EnumObjects(lpCallback, pvRef, dwFlags);
}

HRESULT __stdcall DirectInputDevice8A::GetProperty(REFGUID rguid, LPDIPROPHEADER pdiph)
{
	return this->lpDevice->GetProperty(rguid, pdiph);
}

HRESULT __stdcall DirectInputDevice8A::SetProperty(REFGUID rguid, LPCDIPROPHEADER pdiph)
{
	return this->lpDevice->SetProperty(rguid, pdiph);
}

HRESULT __stdcall DirectInputDevice8A::Acquire()
{
	return this->lpDevice->Acquire();
}

HRESULT __stdcall DirectInputDevice8A::Unacquire()
{
	return this->lpDevice->Unacquire();
}

HRESULT __stdcall DirectInputDevice8A::GetDeviceState(DWORD cbData, LPVOID lpvData)
{
	HRESULT hres = this->lpDevice->GetDeviceState(cbData, lpvData);
	BYTE* state = (BYTE*)lpvData;

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
	
	return  hres;

	
}
DIDEVICEOBJECTDATA CreateKeyboardData(DWORD key, bool down)
{
	//	OutputDebugStringA("KeyboardWrapper -> CreateKeyboardData enter\n");
	DIDEVICEOBJECTDATA data;

	data.dwOfs = key;

	if (down == true)
		data.dwData = 0x80;
	else
		data.dwData = 0x00;

	data.dwSequence = 0;
	data.dwTimeStamp = GetTickCount();
	data.uAppData = 0;

	//	OutputDebugStringA("KeyboardWrapper -> CreateKeyboardData exit\n");

	return data;
}

bool down = false;
DWORD  seq = 0;

HRESULT __stdcall DirectInputDevice8A::GetDeviceData(DWORD cbObjectData, LPDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD dwFlags)
{
	//*pdwInOut = 0;
	HRESULT hres = this->lpDevice->GetDeviceData(cbObjectData, rgdod, pdwInOut, dwFlags);

	//if (pdwInOut > 0)
	//{
	//	seq = rgdod[*pdwInOut - 1].dwSequence;
	//}

	////if (*pdwInOut == 0 && !down)
	////{
	////	rgdod[*pdwInOut] = CreateKeyboardData(DIK_UPARROW, true);
	////	rgdod[*pdwInOut].dwSequence = seq++;
	////	down = true;
	////	*pdwInOut = 1;

	////}

	//for (int i = 0; i < *pdwInOut; i++)
	//{
	//	rgdod[i].dwOfs = DIK_UPARROW;
	//}
		/*rgdod[d].dwOfs = DIK_UPARROW;
		rgdod[d].dwData = 0x80;*/
	


	//
	//
	//if (!down)
	//{
	//	rgdod[*pdwInOut] = CreateKeyboardData(DIK_W, true);
	//	rgdod[*pdwInOut].dwSequence = seq + 1;
	//	down = true;
	//	//Sleep(10);
	//}
	//else
	//{
	//	rgdod[*pdwInOut] = CreateKeyboardData(DIK_W, false);
	//	rgdod[*pdwInOut].dwSequence = seq + 1;
	//	down = false;
	//	//Sleep(10);
	//}
	//*pdwInOut++;
	/*if (!down)
	{
		
		rgdod[*pdwInOut-1].dwSequence++;
		down = !down;
	}
	if (down)
	{
		rgdod[*pdwInOut-1] = CreateKeyboardData(DIK_RETURN, false);
		rgdod[*pdwInOut-1].dwSequence++;
		down = !down;
	}*/

	//return this->lpDevice->GetDeviceData(cbObjectData, rgdod, pdwInOut, dwFlags);
	return hres;
}

HRESULT __stdcall DirectInputDevice8A::SetDataFormat(LPCDIDATAFORMAT lpdf)
{
	return this->lpDevice->SetDataFormat(lpdf);
}

HRESULT __stdcall DirectInputDevice8A::SetEventNotification(HANDLE hEvent)
{
	return this->lpDevice->SetEventNotification(hEvent);
}

HRESULT __stdcall DirectInputDevice8A::SetCooperativeLevel(HWND hwnd, DWORD dwFlags)
{
	return this->lpDevice->SetCooperativeLevel(hwnd, dwFlags);
}

HRESULT __stdcall DirectInputDevice8A::GetObjectInfo(LPDIDEVICEOBJECTINSTANCEA pdidoi, DWORD dwObj, DWORD dwHow)
{
	return this->lpDevice->GetObjectInfo(pdidoi, dwObj, dwHow);
}

HRESULT __stdcall DirectInputDevice8A::GetDeviceInfo(LPDIDEVICEINSTANCEA pdidi)
{
	return this->lpDevice->GetDeviceInfo(pdidi);
}

HRESULT __stdcall DirectInputDevice8A::RunControlPanel(HWND hwndOwner, DWORD dwFlags)
{
	return this->lpDevice->RunControlPanel(hwndOwner, dwFlags);
}

HRESULT __stdcall DirectInputDevice8A::Initialize(HINSTANCE hinst, DWORD dwVersion, REFGUID rguid)
{
	return this->lpDevice->Initialize(hinst, dwVersion, rguid);
}

HRESULT __stdcall DirectInputDevice8A::CreateEffect(REFGUID rguid, LPCDIEFFECT lpeff, LPDIRECTINPUTEFFECT * ppdeff, LPUNKNOWN punkOuter)
{
	return this->lpDevice->CreateEffect(rguid, lpeff, ppdeff, punkOuter);
}

HRESULT __stdcall DirectInputDevice8A::EnumEffects(LPDIENUMEFFECTSCALLBACKA lpCallback, LPVOID pvRef, DWORD dwEffType)
{
	return this->lpDevice->EnumEffects(lpCallback, pvRef, dwEffType);
}

HRESULT __stdcall DirectInputDevice8A::GetEffectInfo(LPDIEFFECTINFOA pdei, REFGUID rguid)
{
	return this->lpDevice->GetEffectInfo(pdei, rguid);
}

HRESULT __stdcall DirectInputDevice8A::GetForceFeedbackState(LPDWORD pdwOut)
{
	return this->lpDevice->GetForceFeedbackState(pdwOut);
}

HRESULT __stdcall DirectInputDevice8A::SendForceFeedbackCommand(DWORD dwFlags)
{
	return this->lpDevice->SendForceFeedbackCommand(dwFlags);
}

HRESULT __stdcall DirectInputDevice8A::EnumCreatedEffectObjects(LPDIENUMCREATEDEFFECTOBJECTSCALLBACK lpCallback, LPVOID pvRef, DWORD fl)
{
	return this->lpDevice->EnumCreatedEffectObjects(lpCallback, pvRef, fl);
}

HRESULT __stdcall DirectInputDevice8A::Escape(LPDIEFFESCAPE pesc)
{
	return this->lpDevice->Escape(pesc);
}

HRESULT __stdcall DirectInputDevice8A::Poll()
{
	return this->lpDevice->Poll();
}

HRESULT __stdcall DirectInputDevice8A::SendDeviceData(DWORD cbObjectData, LPCDIDEVICEOBJECTDATA rgdod, LPDWORD pdwInOut, DWORD fl)
{
	return this->lpDevice->SendDeviceData(cbObjectData, rgdod, pdwInOut, fl);
}

HRESULT __stdcall DirectInputDevice8A::EnumEffectsInFile(LPCSTR lpszFileName, LPDIENUMEFFECTSINFILECALLBACK pec, LPVOID pvRef, DWORD dwFlags)
{
	return this->lpDevice->EnumEffectsInFile(lpszFileName, pec, pvRef, dwFlags);
}

HRESULT __stdcall DirectInputDevice8A::WriteEffectToFile(LPCSTR lpszFileName, DWORD dwEntries, LPDIFILEEFFECT rgDiFileEft, DWORD dwFlags)
{
	return this->lpDevice->WriteEffectToFile(lpszFileName, dwEntries, rgDiFileEft, dwFlags);
}

HRESULT __stdcall DirectInputDevice8A::BuildActionMap(LPDIACTIONFORMATA lpdiaf, LPCSTR lpszUserName, DWORD dwFlags)
{
	return this->lpDevice->BuildActionMap(lpdiaf, lpszUserName, dwFlags);
}

HRESULT __stdcall DirectInputDevice8A::SetActionMap(LPDIACTIONFORMATA lpdiActionFormat, LPCSTR lptszUserName, DWORD dwFlags)
{
	return this->lpDevice->SetActionMap(lpdiActionFormat, lptszUserName, dwFlags);
}

HRESULT __stdcall DirectInputDevice8A::GetImageInfo(LPDIDEVICEIMAGEINFOHEADERA ldpiDevImageInfoHeader)
{
	return this->lpDevice->GetImageInfo(ldpiDevImageInfoHeader);
}

void DirectInputDevice8A::SetKey(BYTE key, bool down)
{
	if (down)
		m_keys[VKToDIK(key)] = 0x80;
	else
		m_keys[VKToDIK(key)] = 0x90;
}