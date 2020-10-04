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

int main (int argc, char **argv) {

	heap priority = heap();

	unordered_map<char, int> charFreq;

  int len = 0;

	FILE *fp = fopen(argv[1], "r");
    
    if ( fp == NULL ) {
        cout << "File '" << argv[1] << "' does not exist!" << endl;
        exit(2);
    }

    char g;
    while ( (g = fgetc(fp)) != EOF ){
    	if ( iscntrl(g) ){
    		;
    	}
    	else{
        	charFreq[g]++;
          len++;
        }
    }

    

  	for ( auto it = charFreq.begin(); it != charFreq.end(); ++it ){
  		huffmanNode* ins = new huffmanNode(it->first, it->second);
  		priority.insert(ins); 
  	}
    

    while( priority.size() > 1 ) {
      int sum = 0;
      huffmanNode* min1 = priority.deleteMin();
      huffmanNode* min2 = priority.deleteMin();
      sum = min1->freq + min2->freq;
      huffmanNode* tree = new huffmanNode();
      tree->left = min1;
      tree->right = min2;
      tree->freq = sum;
      priority.insert(tree);
    }

    unordered_map<char, string> bitStrings;

    for ( auto it = charFreq.begin(); it != charFreq.end(); ++it ){
        if ( it->first == ' '){
          cout << "space " << priority.encode(it->first) << endl;
        }
        else{
          cout << it->first << " " << priority.encode(it->first) << endl;
        }

        bitStrings[it->first] = priority.encode(it->first);
    }

    cout << "----------------------------------------" <<endl;

    rewind(fp);
    int startBits = 0;
    int compressBits = 0;
    // read the file again, and print to the screen
    while ( (g = fgetc(fp)) != EOF ){
      if ( iscntrl(g) ){
        ;
      }
      else{
        cout << bitStrings.at(g) << " ";
        startBits = startBits + 8;
        compressBits = compressBits + bitStrings.at(g).length();
      }
    }
        
    fclose(fp);

  cout << endl << "----------------------------------------" <<endl;

  float comp_ratio = (float)startBits / (float)compressBits;

  cout << "The Compression ratio is: " << comp_ratio << endl;

  float cost = 0.0;

  for ( auto it = charFreq.begin(); it != charFreq.end(); ++it ){
      float prop = ((float)it->second / (float)(len));
      float add = prop*(float)(bitStrings.at(it->first).length());
      cost = cost + add;
  }

  cout << "The Huffman tree costs " << cost << " bits per character." << endl;



}




