#Peter Haynes
#prh7yc
#10/16/19
#Makefile

CXX=clang++
CXXFLAGS=-Wall -O2 -std=c++11
DEBUG=-Wall -g

OFILES = AVLTree.o AVLNode.o AVLPathTest.o

a.out: $(OFILES)
	$(CXX) $(DEBUG) $(OFILES)
	@echo "AVL Tree is Hot and Ready!"

.SUFFIXES: .o 
	
	
clean:
	-rm -f *.o *~ a.out
