/* Peter Haynes
 * prh7yc
 * Filename: huffmanenc.cpp
 * November 24th, 2019
 */

// included so we can use cout
#include <iostream>
// stdlib.h is where exit() lives
#include <stdlib.h>

using namespace std;

// include the standard I/O library
#include <stdio.h>
#include "heap.h"
#include "huffmanNode.h"
#include <unordered_map>


int main(){
	cout << sizeof(unordered_map<char, int>) << endl;
	cout << sizeof(huffmanNode) << endl;
	cout << sizeof(huffmanNode*) << endl;
	cout << sizeof(int) << endl;
	cout << sizeof(char) << endl;
	cout << sizeof(string) << endl;
	cout << sizeof(vector<huffmanNode*>) << endl;
	cout << sizeof(unordered_map<char, string>) << endl;
}