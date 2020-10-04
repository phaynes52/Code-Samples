/* Peter Haynes
 * prh7yc
 * Filename: huffmanNode.h
 * November 24th, 2019
 */

#ifndef HUFFMANNODE_H
#define HUFFMANNODE_H

class huffmanNode{
	public:
		huffmanNode();
		huffmanNode(char a, int b);
		huffmanNode(char a);
		~huffmanNode();
		int freq;
		char chr;
		huffmanNode* left;
		huffmanNode* right;

	private:

};

#endif