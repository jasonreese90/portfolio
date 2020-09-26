#include "ProcLib.h"

ProcessModule::ProcessModule(MODULEENTRY32W me)
{
	this->me = me;
}


std::wstring ProcessModule::getName()
{
	return this->me.szModule;
}

void* ProcessModule::getBaseAddress()
{
	return (void*)this->me.modBaseAddr;
}

uint ProcessModule::getHandle()
{
	return (uint)this->me.hModule;
}

uint ProcessModule::getParentPid()
{
	return (uint)this->me.th32ProcessID;
}

uint ProcessModule::getSize()
{
	return this->me.modBaseSize;
}

std::wstring ProcessModule::getExePath()
{
	return this->me.szExePath;
}

