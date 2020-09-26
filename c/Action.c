/**
* Jason Quedenfeld
* Frank Detweiler
**/
#include "Action.h"

void valueIsDigitAction(InterimResult* x, char c)
{
	x->v = c - '0';
}

void noAction(InterimResult* x, char c)
{

}

void negateAction(InterimResult* x, char c)
{
	x->s = -1;
}

void startFractionAction(InterimResult* x, char c)
{
	x->p = 0.1;
}

void continuingFractionAction(InterimResult* x, char c)
{
	x->v += x->p * (c - '0');
	x->p /= 10;
}

void continuingIntegerAction(InterimResult* x, char c)
{
	x->v = 10 * x->v + c - '0';
}
