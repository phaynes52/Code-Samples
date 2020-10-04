/* Peter Haynes
 * prh7yc
 * Filename: huffmandec.cpp
 * November 26th, 2019
 */

#include <iostream>
#include <fstream>
#include <sstream>
#include <stdlib.h>
#include <stdio.h>
#include "heap.h"
#include "huffmanNode.h"
#include <unordered_map>
using namespace std;

huffmanNode* createTree(unordered_map<string,char> bits, string bit){
	huffmanNode* tree = new huffmanNode();
	if (bits.find(bit) != bits.end()){
		tree->chr = bits[bit];
	}
	else{
		string bitr = bit + "1";
		string bitl = bit + "0";
		tree->right = createTree(bits, bitr);
		tree->left = createTree(bits, bitl);
	}
	return tree;
}

// main(): we want to use parameters
int main (int argc, char **argv) {

	unordered_map<string, char> bitStrings;

    // verify the correct number of parameters
    if ( argc != 2 ) {
        cout << "Must supply the input file name as the only parameter" << endl;
        exit(1);
    }
    // attempt to open the supplied file; must be opened in binary
    // mode, as otherwise whitespace is discarded
    ifstream file(argv[1], ifstream::binary);
    // report any problems opening the file and then exit
    if ( !file.is_open() ) {
        cout << "Unable to open file '" << argv[1] << "'." << endl;
        exit(2);
    }
    // read in the first section of the file: the prefix codes
    while ( true ) {
        string character, prefix;
        // read in the first token on the line
        file >> character;
        
        // did we hit the separator?
        if ( (character[0] == '-') && (character.length() > 1) )
            break;
        // check for space
        if ( character == "space" )
            character = " ";
        // read in the prefix code
		char chr = character[0];

        file >> prefix;
     	bitStrings[prefix] = chr;
    }

    huffmanNode* tree = createTree(bitStrings, "");
    huffmanNode* temp = tree;


    // read in the second section of the file: the encoded message
    stringstream sstm;
    while ( true ) {
        string bits;
        // read in the next set of 1's and 0's
        file >> bits;

        char chr = tree->chr;


        // check for the separator
        
        if ( bits[0] == '-'){
            break;
        }

        for( char& c : bits){
        
    		if( c == '1'){
    			chr = temp->right->chr;
    			temp = temp->right;
    		}

    		else if( c == '0'){
    			chr = temp->left->chr;
    			temp = temp->left;
    		}
    		else{
    			;
    		}

    		if( !temp->left && !temp->right){
        		sstm << chr;
        		temp = tree;
        		chr = tree->chr;
        	}	
        }
        
        
    }
    string allbits = sstm.str();
    // at this point, all the bits are in the 'allbits' string
    cout << allbits << endl;
    // close the file before exiting
    file.close();
}
