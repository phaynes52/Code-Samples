/*
Peter Haynes
prh7yc
10/20/1998
hashTable.cpp
*/

#include "hashTable.h"


using namespace std;


hashTable::hashTable(){
	for (int i = 0; i < 23; i++){
		powers.push_back(pow(37,i));
	}

}

hashTable::~hashTable(){
}

void hashTable::insert(string s){
	int key = hashFunc(s);
	table[key].push_back(s);

}

bool hashTable::find(string s){
	int key = hashFunc(s);
	int length = table.size();
	for( string word : table[key]){
		if(word == s){
			return true;
		}
	}
	return false;
}

int hashTable::hashFunc(string s){
	int length = s.size();
	int count = 0;

	for( int i = 0; i  < length; i++ ) {
		char temp = s[i];
		int val = int(temp)*powers[i];
		count = count + val;
	}

	count = count % table.size();

	return count;
}

void hashTable::count(string file){
	ifstream dictFile(file);

	if ( !dictFile ) {
        cout << "Error reading in file!" << endl;
        exit(1); // requires the <stdlib.h> #include header!
    }

	int count = 0;
	string line;

	while( getline(dictFile, line)){
		count++;
	}

	dictFile.close();
	
	count = 5 * count;

	count = getNextPrime(count);

	table.resize(count);
}

void hashTable::insertDictionary(string file){
	ifstream dictFile(file);

	if ( !dictFile ) {
        cout << "Error reading in file!" << endl;
        exit(1); // requires the <stdlib.h> #include header!
    }

	string line;

	while( getline(dictFile, line)){
		insert(line);
	}

	dictFile.close();
}

void hashTable::printTable() {

	int length = table.size();

	for( int i = 0; i  < length; i++ ) {
		for( string word : table[i]){
			cout << word << "->";
		}
		cout << endl;
		}
}

bool hashTable::checkPrime(unsigned int p) {
    if ( p <= 1 ) // 0 and 1 are not primes; the are both special cases
        return false;
    if ( p == 2 ) // 2 is prime
        return true;
    if ( p % 2 == 0 ) // even numbers other than 2 are not prime
        return false;
    for ( int i = 3; i*i <= p; i += 2 ) // only go up to the sqrt of p
        if ( p % i == 0 )
            return false;
    return true;
}

int hashTable::getNextPrime (unsigned int n) {
    while ( !checkPrime(++n) );
    return n; // all your primes are belong to us
}


