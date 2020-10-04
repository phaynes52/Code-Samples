// Peter Haynes
// prh7yc
// 10/13/19
// TreeCalc.cpp:  CS 2150 Tree Calculator method implementations

#include "TreeCalc.h"
#include <iostream>

using namespace std;

//Constructor
TreeCalc::TreeCalc() {
}

//Destructor- frees memory
TreeCalc::~TreeCalc() {
    while( mystack.empty() != true ){
        cleanTree(mystack.top());
        mystack.pop();
    }
}

//Deletes tree/frees memory
void TreeCalc::cleanTree(TreeNode* ptr) {
    if (ptr->left != NULL){
    cleanTree(ptr->left);
   }
   if (ptr->right != NULL){
    cleanTree(ptr->right);
   }
   delete ptr;
}

//Gets data from user
void TreeCalc::readInput() {
    string response;
    cout << "Enter elements one by one in postfix notation" << endl
         << "Any non-numeric or non-operator character,"
         << " e.g. #, will terminate input" << endl;
    cout << "Enter first element: ";
    cin >> response;
    //while input is legal
    while (isdigit(response[0]) || response[0]=='/' || response[0]=='*'
            || response[0]=='-' || response[0]=='+' ) {
        insert(response);
        cout << "Enter next element: ";
        cin >> response;
    }
}

//Puts value in tree stack
void TreeCalc::insert(const string& val) {
    if (val == "-" || val == "+"|| val == "/"|| val == "*"){
        TreeNode* oper = new TreeNode(val);
        oper->right = mystack.top();
        mystack.pop();
        oper->left = mystack.top();
        mystack.pop();
        mystack.push(oper);
    }
    else{
        TreeNode* leaf = new TreeNode(val);
        mystack.push(leaf);
    }
}

//Prints data in prefix form
void TreeCalc::printPrefix(TreeNode* ptr) const {
   cout << ptr->value << " ";
   if (ptr->left != NULL){
    printPrefix(ptr->left);
   }
   if (ptr->right != NULL){
    printPrefix(ptr->right);
   }
}

//Prints data in infix form
void TreeCalc::printInfix(TreeNode* ptr) const {
    if (ptr->value == "-" || ptr->value == "+"|| ptr->value == "/"|| ptr->value== "*"){
        cout << "(";
    }

   if (ptr->left != NULL){
    printInfix(ptr->left);
   }

   cout << ptr->value << " ";

   if (ptr->right != NULL){
    printInfix(ptr->right);
   }

   if (ptr->value == "-" || ptr->value == "+"|| ptr->value == "/"|| ptr->value== "*"){
    cout << ")";
    }
}

//Prints data in postfix form
void TreeCalc::printPostfix(TreeNode* ptr) const {
   if (ptr->left != NULL){
    printPostfix(ptr->left);
   }
   if (ptr->right != NULL){
    printPostfix(ptr->right);
   }
   cout << ptr->value << " ";
}

// Prints tree in all 3 (pre,in,post) forms

void TreeCalc::printOutput() const {
    if  (mystack.size()!=0 && mystack.top()!=NULL) {
        cout << "Expression tree in postfix expression: ";
        printPostfix(mystack.top());  // call your implementation of printPostfix()
        cout << endl;
        cout << "Expression tree in infix expression: ";
        printInfix(mystack.top());
        cout << endl;
        cout << "Expression tree in prefix expression: ";
        printPrefix(mystack.top());
        cout << endl;
    } else
        cout<< "Size is 0." << endl;
}

//Evaluates tree, returns value
// private calculate() method
int TreeCalc::calculate(TreeNode* ptr) const {
    if (ptr->value == "+" ) {
        return (calculate(ptr->left) + calculate(ptr->right));
    }
    else if (ptr->value == "-") {
        return (calculate(ptr->left) - calculate(ptr->right));
    } 
    else if (ptr->value == "/") {
        return (calculate(ptr->left) / calculate(ptr->right));
    } 
    else if (ptr->value == "*"){
        return (calculate(ptr->left) * calculate(ptr->right));
    }
    else{
        int val = atoi(ptr->value.c_str());
        return val;
    }
}

//Calls calculate, sets the stack back to a blank stack
// public calculate() method. Hides private data from user
int TreeCalc::calculate() {
    int i = 0;
    i = calculate(mystack.top());
    while( mystack.empty() != true ){
        cleanTree(mystack.top());
        mystack.pop();
    }
    return i;
}
