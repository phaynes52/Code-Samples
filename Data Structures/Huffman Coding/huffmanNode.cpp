/* Peter Haynes
 * prh7yc
 * Filename: huffmanNode.cpp
 * November 24th, 2019
 */
#include <stdlib.h>
#include "huffmanNode.h"

huffmanNode::huffmanNode(){
	chr = '\0';
	freq = 0;
	left = NULL;
	right = NULL;
}

huffmanNode::huffmanNode(char a, int b){
	chr = a;
	freq = b;
	left = NULL;
	right = NULL;
}

huffmanNode::huffmanNode(char a){
	chr = a;
	freq = 0;
	left = NULL;
	right = NULL;
}

huffmanNode::~huffmanNode(){
	delete left;
	delete right;
	left = NULL;
  	right = NULL;
}