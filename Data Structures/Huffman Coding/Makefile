#Peter Haynes 
#prh7yc
#November 26th, 2019
#Tuesday 12:30
CXX=clang++
CXXFLAGS=-Wall -O2 -std=c++11
DEBUG=-Wall -g

all: encoder decoder

OFILES = huffmanNode.o heap.o

encoder: $(OFILES) huffmanenc.o
	$(CXX) $(DEBUG) $(OFILES) huffmanenc.o -o encoder

decoder: $(OFILES) huffmandec.o
	$(CXX) $(DEBUG) $(OFILES) huffmandec.o -o decoder

huffmandec.o: huffmandec.cpp heap.h huffmanNode.h
huffmanenc.o: huffmanenc.cpp heap.h huffmanNode.h

.SUFFIXES: .o 
	
	
clean:
	-rm -f *.o *~ encoder decoder