#pragma once
#include "ProcLib.h"


class SignatureScan
{
private:
	Process process;
	void* startAddress;
	int length;
	bool moduleDumped = false;
	unsigned char* dumpBuffer = nullptr;
	int IndexOf(unsigned char* haystack, int haystackSize, unsigned char* needle, int needleSize);
	bool ParseBytes(const char* pattern, unsigned char* buf);
	unsigned char ParseByte(char c1, char c2);
	unsigned char CharToByte(char input);

public:
	SignatureScan(Process process, ProcessModule targetModule);
	SignatureScan(Process process, void* baseAddress, int size);
	~SignatureScan();
	void DumpMemory();
	void* FindSignature(const char* pattern, int offset = 0, bool dereference = true, bool addSigLen = true);
	void* FindRelativeSignature(const char* pattern);
};

SignatureScan::SignatureScan(Process process, ProcessModule targetModule)
{
	this->process = process;
	this->startAddress = targetModule.getBaseAddress();
	this->length = targetModule.getSize();
}

SignatureScan::SignatureScan(Process process, void* baseAddress, int size)
{
	this->process = process;
	this->startAddress = baseAddress;
	this->length = size;
}

SignatureScan::~SignatureScan()
{
	delete[] dumpBuffer;
	dumpBuffer = nullptr;
}


void SignatureScan::DumpMemory()
{
	dumpBuffer = new unsigned char[length];
	ReadProcessMemory(process.getHandle(), startAddress, dumpBuffer, (uint)length, 0);
	moduleDumped = true;
}

void* SignatureScan::FindRelativeSignature(const char* pattern)
{
	void* addr = this->FindSignature(pattern, 0, false, true);
	int offset = 0;

	ReadProcessMemory(process.getHandle(), addr, &offset, 4, 0);

	return (void*)((int)addr + offset + 4);
}

void* SignatureScan::FindSignature(const char* pattern, int offset, bool dereference, bool addSigLen)
{
	int patLen = strlen(pattern);

	if (patLen % 2 != 0 || patLen < 2)
		return nullptr;

	if (!moduleDumped)
		DumpMemory();

	unsigned char* bPattern = new unsigned char[patLen / 2];

	if (!ParseBytes(pattern, bPattern))
	{
		delete[] bPattern;
		return nullptr;
	}

	int index = IndexOf(dumpBuffer, length, bPattern, patLen / 2);

	if (index != -1)
	{
		int len = addSigLen ? patLen / 2 : 0;
		void* addr = (void*)((int)startAddress + index + len);

		if (dereference)
		{
			int buff;
			ReadProcessMemory(process.getHandle(), (void*)((int)addr + offset), &buff, 4, 0);

			delete[] bPattern;

			return (void*)buff;
		}

		delete[] bPattern;

		return addr;
	}

	delete[] bPattern;

	return nullptr;
}

int SignatureScan::IndexOf(unsigned char* haystack, int haystackSize, unsigned char* needle, int needleSize)
{
	int lookup[256];

	for (int i = 0; i < 256; i++) { lookup[i] = needleSize; }

	for (int i = 0; i < needleSize; i++)
	{
		lookup[needle[i]] = needleSize - i - 1;
	}

	int index = needleSize - 1;
	unsigned char lastByte = needle[needleSize - 1];

	while (index < haystackSize)
	{
		unsigned char checkByte = haystack[index];
		if (haystack[index] == lastByte)
		{
			bool found = true;
			for (int j = needleSize - 2; j >= 0; j--)
			{
				if (haystack[index - needleSize + j + 1] != needle[j])
				{
					found = false;
					break;
				}
			}

			if (found)
				return index - needleSize + 1;
			else
				index++;
		}
		else
		{
			index += lookup[checkByte];
		}
	}
	return -1;
}

bool SignatureScan::ParseBytes(const char* pattern, unsigned char* buf)
{
	int patLen = strlen(pattern);

	if (patLen % 2 != 0 || patLen < 2)
	{
		return false;
	}

	for (int i = 0; i < patLen; i += 2)
	{
		buf[i / 2] = ParseByte(pattern[i], pattern[i + 1]);
	}

	return true;
}

unsigned char SignatureScan::CharToByte(char input)
{
	if (input >= '0' && input <= '9')
		return input - '0';
	if (input >= 'A' && input <= 'F')
		return input - 'A' + 10;
	if (input >= 'a' && input <= 'f')
		return input - 'a' + 10;
}

unsigned char SignatureScan::ParseByte(char c1, char c2)
{
	return (CharToByte(c2) | (CharToByte(c1) << 4));
}