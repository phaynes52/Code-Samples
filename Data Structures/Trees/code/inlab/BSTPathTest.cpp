#include "BinarySearchTree.h"

#include <iostream>
using namespace std;

int main() {
  BinarySearchTree bst1;
  BinarySearchTree bst2;

  int[] ele = [1,2,3,4,5,6,7,8];

  for( int n : ele ) {
    bst1.insert(n);
    bst2.insert(n);
  }

cout << bst1.isIdentical(bst1.root, bst2.root); <<endl;

}