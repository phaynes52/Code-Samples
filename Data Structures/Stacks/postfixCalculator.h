/* Peter Haynes
 * prh7yc
 * Filename: postfixCalculator.h
 * September 15th, 2019
 *
 */

#ifndef POSTFIXCALCULATOR_H
#define POSTFIXCALCULATOR_H

#include "stack.h"
#include <string>

using namespace std;

class postfixCalculator {
public:
    postfixCalculator();				//Constructor
    postfixCalculator(const postfixCalculator& source);	//Copy Constructor
    void push(int x); //adds to the top of the stack
    int top();   //returns the top value
    void pop();  //removes the top valuye
    bool empty(); //returns true if there are no elements left
    void add();	//adds top two numbers in the stack
    void subtract();	//subtracts second to top number from top number
    void multiply();	//multiplies top two numbers in the stack
    void divide();	//divides second to top number in the stack by the top number
  	void negate();	//adds top two numbers in the stack

private:
	stack numbers;
};


#endif
/* end of postfixCalculator.h */
