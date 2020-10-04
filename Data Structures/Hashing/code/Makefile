#Peter Haynes
#prh7yc
#10/21/19
#Makefile

CXX=clang
CXXFLAGS=-Wall -O2 -std=c
DEBUG=-Wall -g

OFILES = linkedlist.c

a.out: $(OFILES)
	$(CXX) $(DEBUG) $(OFILES)

linkedlist.o: linkedlist.c

.SUFFIXES: .o 
	
	
clean:
	-rm -f *.o *~ a.out
