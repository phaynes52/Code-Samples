/*
Peter Haynes
prh7yc
postfixCalculator.cpp
September 9th, 2019
 */

#include <iostream>
#include <cstdlib>
#include "postfixCalculator.h"

using namespace std;


postfixCalculator::postfixCalculator() {
	numbers = stack();
}

postfixCalculator::postfixCalculator(const postfixCalculator& source) {
	numbers = source.numbers;
}

void postfixCalculator::push(int x) {
	numbers.push(x);
}

int postfixCalculator::top() {
	if (empty() == true) {
		exit(-1);
	}
	return numbers.top();
}
void postfixCalculator::pop() {
	if (empty() == true) {
		exit(-1);
	}
	numbers.pop();
}

bool postfixCalculator::empty() {
	return numbers.empty();
}

void postfixCalculator::add() {
	int result;
	int x = top();
	pop();
	int y = top();
	pop();
	result = x + y;
	push(result);
}

 void postfixCalculator::subtract() {
	int result;
	int x = top();
	pop();
	int y = top();
	pop();
	result = y - x;
	push(result);
}

 void postfixCalculator::multiply() {
	int result;
	int x = top();
	pop();
	int y = top();
	pop();
	result = y * x;
	push(result);
}

void postfixCalculator::divide() {
	int result;
	int x = top();
	pop();
	int y = top();
	pop();
	result = y / x;
	push(result);
}

void postfixCalculator::negate() {
	int result;
	int x = top();
	pop();
	result = x * (-1);
	push(result);
}







