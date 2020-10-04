#Peter Haynes 
#prh7yc
#November 26th, 2019
#Tuesday 12:30
CXX=clang++
CXXFLAGS=-Wall -O2 -std=c++11
DEBUG=-Wall -g

OFILES = traveling.o middleearth.o

a.out: $(OFILES)
	doxygen Doxyfile
	$(CXX) $(DEBUG) $(OFILES) 
	
.SUFFIXES: .o 
	
	
clean:
	-rm -f *.o *~ a.out