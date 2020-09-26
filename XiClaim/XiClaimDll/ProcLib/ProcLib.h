#pragma once

#include <string>
#include <vector>
#include <Windows.h>
#include <tlhelp32.h>

class Process;
class ProcessModule;

typedef std::vector<Process> ProcessArray;
typedef std::vector<ProcessModule> ProcessModuleArray;
typedef unsigned __int32 uint;
typedef unsigned char byte;

class Process
{
public:
	Process() { }
	Process(uint processId);
	~Process();
	static bool getProcesses(ProcessArray* pProcessArray);
	static bool getProcessesByName(std::wstring name, ProcessArray* pProcessArray);
	
	std::wstring getName();
	uint getId();
	std::wstring getCommandLine();
	uint getParentPid();
	uint getBasePriority();

	void* getHandle();
	//void closeHandle();

	bool getModules(ProcessModuleArray* pProcessModuleArray);

private:
	uint pid;
	void* handle = nullptr;
};

class ProcessModule
{
public:
    ProcessModule() {}
	std::wstring getName();
	void* getBaseAddress();
	uint getHandle();
	std::wstring getExePath();
	uint getSize();
	uint getParentPid();

private:
	MODULEENTRY32W me;
	ProcessModule(MODULEENTRY32W me);

	friend Process;
};