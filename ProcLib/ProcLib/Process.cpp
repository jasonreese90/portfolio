#include "ProcLib.h"
#include <Psapi.h>


Process::Process(uint processId)
{
	this->pid = processId;
}

Process::~Process()
{
	if (this->handle != nullptr)
	{
		CloseHandle(this->handle);
		this->handle = nullptr;
	}
}

std::wstring Process::getName()
{
	HANDLE handle = OpenProcess(PROCESS_ALL_ACCESS, false, this->pid);
	wchar_t buffer[MAX_PATH];
	wchar_t* str;
	wchar_t* buff;
	wchar_t ret[MAX_PATH];

	ZeroMemory(buffer, MAX_PATH);
	ZeroMemory(ret, MAX_PATH); 

	GetProcessImageFileNameW(handle, buffer, MAX_PATH);
	CloseHandle(handle);

	str = wcstok_s(buffer, TEXT("\\"),&buff);

	while ((str = wcstok_s(NULL, TEXT("\\"), &buff)) != NULL)
	{ 
		wcscpy_s(ret, MAX_PATH, str);
	}

	return std::wstring(ret);
}

uint Process::getId()
{
	return this->pid;
}

std::wstring Process::getCommandLine()
{
	return NULL;
}

bool Process::getModules(ProcessModuleArray* pProcessModuleArray)
{
	HANDLE hSnap = 0;
	MODULEENTRY32W me;

	if (!pProcessModuleArray)
		return false;

	if (pProcessModuleArray->size() > 0)
		pProcessModuleArray->clear();

	hSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32,this->pid);

	if (hSnap == INVALID_HANDLE_VALUE)
	{
		return false;
	}
	
	me.dwSize = sizeof(MODULEENTRY32W);

	if (!Module32FirstW(hSnap, &me))
	{
		CloseHandle(hSnap);
		return false;
	}

	ProcessModule pm(me);
	pProcessModuleArray->push_back(pm);

	while (Module32NextW(hSnap, &me))
	{
		pm = ProcessModule(me);
		pProcessModuleArray->push_back(pm);
	}

	CloseHandle(hSnap);

	return true;
}

void* Process::getHandle()
{
	if (this->handle == nullptr)
	{
		this->handle = OpenProcess(PROCESS_ALL_ACCESS, TRUE, this->pid);
	}

	return this->handle;
}

//void Process::closeHandle()
//{
//	if (this->handle != nullptr)
//	{
//		CloseHandle(this->handle);
//		this->handle = nullptr;
//	}
//}

bool Process::getProcesses(ProcessArray* pProcessArray)
{
	HANDLE hSnap = 0;
	PROCESSENTRY32W pe;

	if (!pProcessArray)
		return false;

	if (pProcessArray->size() > 0)
		pProcessArray->clear();

	hSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

	if (hSnap == INVALID_HANDLE_VALUE)
	{
		return false;
	}

	pe.dwSize = sizeof(PROCESSENTRY32W);
	
	if (!Process32FirstW(hSnap, &pe))
	{
		CloseHandle(hSnap);
		return false;
	}

	Process p(pe.th32ProcessID);
	pProcessArray->push_back(p);

	while (Process32NextW(hSnap, &pe))
	{
		p = Process(pe.th32ProcessID);
		pProcessArray->push_back(p);
	}

	CloseHandle(hSnap);

	return true;

}

bool Process::getProcessesByName(std::wstring name, ProcessArray* pProcessArray)
{
	ProcessArray pp;

	if (!pProcessArray)
		return false;

	if (!Process::getProcesses(&pp))
		return false;

	if (pProcessArray->size() > 0)
		pProcessArray->clear();

	for (Process p : pp)
	{
		if (!p.getName().compare(name))
		{
			pProcessArray->push_back(p);
		}
	}

	return true;
}