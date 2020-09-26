#include "InterimResult.h"
#include "Action.h"
#include "InputVerifier.h"
#include <stdio.h>
#include <string.h>

typedef enum
{
	START,
	INTEGER,
	DECIMAL,
	END
} State;


typedef struct
{
	State currentState;
	InputVerifier inputVerifier;
	Action action;
	State nextState;
} Edge;


const Edge machine[] = 
{
	{ START, digitInputVerifier, valueIsDigitAction, INTEGER },
	{ START, minusInputVerifier, negateAction, INTEGER },
	{ START, plusInputVerifier, noAction, INTEGER },
	{ START, periodInputVerifier, startFractionAction, DECIMAL},
	{ INTEGER, digitInputVerifier, continuingIntegerAction, INTEGER },
	{ INTEGER, periodInputVerifier, startFractionAction, DECIMAL },
	{ DECIMAL, digitInputVerifier, continuingFractionAction, DECIMAL },
};

int parse(char* input, double* value)
{
	InterimResult ir;
	ir.p = 0;
	ir.s = 1;
	ir.v = 0;

	State state = START;

	int inputLen = strlen(input);
	int arraySize = sizeof machine / sizeof machine[0];
	int i = 0;

	for (i = 0; i < inputLen; i++)
	{
		char c = input[i];
		const Edge* edge = 0;
		int x = 0;
		for (x = 0; x < arraySize; x++)
		{
			if (state == machine[x].currentState && machine[x].inputVerifier(c))
			{
				edge = &machine[x];
			}
		}

		if (edge == 0)
		{
			return 0;
		}

		edge->action(&ir, c);
		state = edge->nextState;
	}

	*value = ir.s * ir.v;

	return 1;
}

int main(int argc, const char* argv[])
{
	char* values[10] = { "-42.16", "42.16", "a", "4-", "4.+", "42", "-42", "-.16", ".16", "0" };
	int i = 0;
	for (i = 0; i < 10; i++)
	{
		double value;
		if (!parse(values[i], &value))
		{
			printf("NumberFormatException: %s\n", values[i]);
		}
		else
		{
			printf("%.2f\n", value);
		}
	}

	return 0;
}

	


