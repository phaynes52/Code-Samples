/* Peter Haynes
 * prh7yc
 * Filename: stack.h
 * September 17th, 2019
 */

#ifndef STACK_H
#define STACK_H

#include<iostream>
#include "List.h"

using namespace std;

class stack;

class stack {
public:
	stack();
	void push(int x);
	int top();
	void pop();
	bool empty();

private:
	List numbers;
};

#endif

