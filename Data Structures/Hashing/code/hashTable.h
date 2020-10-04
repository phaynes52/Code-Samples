/*
Peter Haynes
prh7yc
10/20/1998
hashTable.h
*/

#ifndef HASHTABLE_H
#define HASHTABLE_H

#include <iostream>
#include <string>
#include <vector>
#include <list>
#include <cmath>
#include <cstring>
#include <sstream>
#include <fstream>
#include <iostream>


using namespace std;

class hashTable{

private:
	vector<list<string> > table;
	vector<int > powers;

public:

	hashTable();
	~hashTable();
	void insert(string s);
	bool find(string s);
	int hashFunc(string s);
	void count(string file);
	void printTable();
	void insertDictionary(string file);
	bool checkPrime(unsigned int p);
	int getNextPrime(unsigned int p);
};

#endif