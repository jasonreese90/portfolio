#ifndef _INPUTVERIFIER_H
#define _INPUTVERIFIER_H

typedef int (*InputVerifier)(char c);

int digitInputVerifier(char c);
int minusInputVerifier(char c);
int plusInputVerifier(char c);
int periodInputVerifier(char c);

#endif