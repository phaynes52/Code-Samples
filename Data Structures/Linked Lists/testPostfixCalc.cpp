/*
Peter Haynes
prh7yc
testPostfixCalc.cpp
September 9th, 2019
 */

#include <iostream>
#include <string>
#include <ctype.h>
#include <stdlib.h>

using namespace std;

#include "postfixCalculator.h"

int main() {
    PostfixCalculator p;
    p.push (1);
    p.push (2);
    p.push (3);
    p.push (4);
    p.push(5);
    p.add();
    p.add();
    p.add();
    p.add();
    cout << "Result is: " << p.getTopValue() << endl;
    return 0;
}