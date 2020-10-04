#Peter Haynes
#prh7yc
#10/21/19
#Makefile

CXX=clang++
CXXFLAGS=-Wall -O2 -std=c++11
DEBUG=-Wall -g

OFILES = wordPuzzle.o hashTable.o timer.o

a.out: $(OFILES)
	$(CXX) $(DEBUG) $(OFILES)
	@echo "AVL Tree is Hot and Ready!"

hashTable.o: hashTable.cpp hashTable.h
timer.o: timer.cpp timer.h
timer_test.o: timer_test.cpp timer.h
wordPuzzle.o: wordPuzzle.cpp hashTable.h timer.h
wordSearch.o: wordSearch.cpp

.SUFFIXES: .o 
	
	
clean:
	-rm -f *.o *~ a.out
