/*
Peter Haynes
prh7yc
stack.cpp
September 17th, 2019
 */
#include <iostream>
#include "stack.h"

using namespace std;

stack::stack() {
	numbers = List();
}

void stack::push(int x) {
		numbers.insertAtTail(x); 
}

int stack::top() {
		ListItr topElement = numbers.last();
		return topElement.retrieve();
}

void stack::pop() {
		numbers.removeLast();
}

bool stack::empty() {
		return numbers.isEmpty(); 
}