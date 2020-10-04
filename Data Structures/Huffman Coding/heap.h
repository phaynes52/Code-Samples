/* Peter Haynes
 * prh7yc
 * Filename: heap.h
 * November 24th, 2019
 */

#ifndef HEAP_H
#define HEAP_H

#include <vector>
#include <string>
#include "huffmanNode.h"
using namespace std;

class heap {
public:
    heap();
    heap(vector<huffmanNode*> vec);
    ~heap();

    void insert(huffmanNode* x);
    huffmanNode* findMin();
    huffmanNode* deleteMin();
    unsigned int size();
    void makeEmpty();
    bool isEmpty();
    void print();
    string encode(char a);

private:
    vector<huffmanNode*> pheap;
    unsigned int heap_size;

    bool find(huffmanNode* base, char a);
    string encodeHelper(huffmanNode* base, char a);
    void percolateUp(int hole);
    void percolateDown(int hole);
};

#endif