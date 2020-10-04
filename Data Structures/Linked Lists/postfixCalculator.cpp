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
	numbers = new stack();
}

postfixCalculator::postfixCalculator(const postfixCalculator& source) {
	numbers = source.numbers;
}

postfixCalculator::~postfixCalculator() {
	delete numbers;
}

postfixCalculator::push(int x) {
	numbers.push(x);
}

postfixCalculator::top() {
	if (empty() == true) {
		exit(-1);
	}
	return numbers.top();
}
postfixCalculator::pop() {
	if (empty() == true) {
		exit(-1);
	}
	numbers.pop();
}

postfixCalculator::empty() {
	return numbers.empty();
}

postfixCalculator::add() {
	result = new int;
	x = top();
	pop();
	y = top();
	pop();
	result = x + y;
	push(result);
}

postfixCalculator::subtract() {
	result = new int;
	x = top();
	pop();
	y = top();
	pop();
	result = y - x;
	push(result);
}

postfixCalculator::multiply() {
	result = new int;
	x = top();
	pop();
	y = top();
	pop();
	result = y * x;
	push(result);
}

postfixCalculator::divide() {
	result = new int;
	x = top();
	pop();
	y = top();
	pop();
	result = y / x;
	push(result);
}

postfixCalculator::negate() {
	result = new int;
	x = top();
	pop();
	result = x * (-1);
	push(result);
}







