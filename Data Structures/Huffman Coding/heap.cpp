/* Peter Haynes
 * prh7yc
 * Filename: heap.cpp
 * November 24th, 2019
 */
#include <iostream>
#include <string>
#include "heap.h"
using namespace std;

// default constructor
heap::heap() : heap_size(0) {
    pheap.push_back(0);
}

// builds a heap from an unsorted vector
heap::heap(vector<huffmanNode*> vec) : heap_size(vec.size()) {
    pheap = vec;
    pheap.push_back(pheap[0]);
    pheap[0] = 0;
    for ( int i = heap_size/2; i > 0; i-- )
        percolateDown(i);
}

// the destructor doesn't need to do much
heap::~heap() {
    makeEmpty();
}

void heap::insert(huffmanNode* x) {
    // a vector push_back will resize as necessary
    pheap.push_back(x);
    // move it up into the right position
    percolateUp(++heap_size);
}

void heap::percolateUp(int hole) {
    // get the value just inserted
    huffmanNode* x = pheap[hole];
    // while we haven't run off the top and while the
    // value is less than the parent...
    for ( ; (hole > 1) && (x->freq < pheap[hole/2]->freq); hole /= 2 )
        pheap[hole] = pheap[hole/2]; // move the parent down
    // correct position found!  insert at that spot
    pheap[hole] = x;
}


huffmanNode* heap::deleteMin() {
    // make sure the heap is not empty
    if ( heap_size == 0 )
        throw "deleteMin() called on empty heap";
    // save the value to be returned
    huffmanNode* ret = pheap[1];
    // move the last inserted position into the root
    pheap[1] = pheap[heap_size--];
    // make sure the vector knows that there is one less element
    pheap.pop_back();
    // percolate the root down to the proper position
    percolateDown(1);
    // return the old root node
    return ret;
}

void heap::percolateDown(int hole) {
    // get the value to percolate down
    huffmanNode* x = pheap[hole];
    // while there is a left child...
    while ( hole*2 <= heap_size ) {
        int child = hole*2; // the left child
        // is there a right child?  if so, is it lesser?
        if ( (child+1 <= heap_size) && (pheap[child+1]->freq < pheap[child]->freq) )
            child++;
        // if the child is greater than the node...
        if ( x->freq > pheap[child]->freq ) {
            pheap[hole] = pheap[child]; // move child up
            hole = child;             // move hole down
        } else
            break;
    }
    // correct position found!  insert at that spot
    pheap[hole] = x;
}


huffmanNode* heap::findMin() {
    if ( heap_size == 0 )
        throw "findMin() called on empty heap";
    return pheap[1];
}

unsigned int heap::size() {
    return heap_size;
}

void heap::makeEmpty() {
    heap_size = 0;
    pheap.resize(1);
}

bool heap::isEmpty() {
    return heap_size == 0;
}

void heap::print() {
    cout << "(" << pheap[0] << ") ";
    for ( int i = 1; i <= heap_size; i++ ) {
        cout << "{" << pheap[i]->chr << " : " << pheap[i]->freq << "}" << " ";
        // next line from http://tinyurl.com/mf9tbgm
        bool isPow2 = (((i+1) & ~(i))==(i+1))? i+1 : 0;
        if ( isPow2 )
            cout << endl << "\t";
    }
    cout << endl;
}

string heap::encode(char fn){
    return encodeHelper(pheap[1], fn);
}

string heap::encodeHelper(huffmanNode* base, char fn) {

    if (base->chr == fn ){
        return "";
    }

    if (!base->right && !base->left){
        return "";
    }
    if(find(base->right, fn)){
        return "1" + encodeHelper(base->right, fn);
    }
    
    if(find(base->left, fn)){
        return "0" + encodeHelper(base->left, fn);
    }
    
    return "";
}



bool heap::find(huffmanNode* base, char fnd){

    if( !base){
        return false;
    }

    if( base->chr == fnd){
        return true;
    }

    bool result1 = find(base->right, fnd); 
  
    bool result2 = find(base->left, fnd); 
  
    return (result1 || result2); 

}







