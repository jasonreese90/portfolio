#include "InputVerifier.h"
#include <ctype.h>

int digitInputVerifier(char c)
{	
	return isdigit(c);
}

int minusInputVerifier(char c)
{
	return c == '-';
}

int plusInputVerifier(char c)
{
	return c == '+';
}

int periodInputVerifier(char c)
{
	return c == '.';
}
