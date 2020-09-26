#ifndef _ACTION_H
#define _ACTION_H

#include "InterimResult.h"

typedef void(*Action)(InterimResult* x, char c);

void valueIsDigitAction(InterimResult* x, char c);
void noAction(InterimResult* x, char c);
void negateAction(InterimResult* x, char c);
void startFractionAction(InterimResult* x, char c);
void continuingFractionAction(InterimResult* x, char c);
void continuingIntegerAction(InterimResult* x, char c);

#endif