CC=gcc
CFLAGS=-I.
DEPS = Action.h InputVerifier.h InterimResult.h

%.o: %.c $(DEPS)
	$(CC) -c -o $@ $< $(CFLAGS)

tdstate: ConvertingMachine.o InputVerifier.o Action.o
	gcc -o tdstate ConvertingMachine.o InputVerifier.o Action.o -I.