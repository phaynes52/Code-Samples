/*
Peter Haynes
prh7yc
testPostfixCalc.cpp
September 15th, 2019
 */

#include <iostream>
#include <string>
#include <ctype.h>
#include <stdlib.h>
#include <cstdlib>

using namespace std;

#include "postfixCalculator.h"

int main() {
    postfixCalculator p;
    p.push (1);
    p.push (2);
    p.push (3);
    p.push (4);
    p.push(5);
    p.add();
    p.add();
    p.add();
    p.add();
    cout << "Result is: " << p.top() << endl;

    postfixCalculator p1;
    p1.push (20);
    p1.push (10);
    p1.subtract();
    p1.push (-3);
    p1.push (10);
    p1.subtract();
    p1.subtract();
    p1.push(2);
    p1.subtract();
    cout << "Result is: " << p1.top() << endl;

    postfixCalculator p2;
    p2.push (-1);
    p2.push (-2);
    p2.push (-5);
    p2.push (3);
    p2.multiply();
    p2.push(2);
    p2.push(-2);
    p2.multiply();
    p2.multiply();
    p2.multiply();
    p2.multiply();
    cout << "Result is: " << p2.top() << endl;


    postfixCalculator p3;
    p3.push (-1512);
    p3.push (-12);
    p3.push (-2);
    p3.divide();
    p3.divide();
    p3.push (-2);
    p3.divide();
    p3.push(3);
    p3.divide();
    cout << "Result is: " << p3.top() << endl;

    postfixCalculator p4;
    p4.push (-1);
    p4.negate();
    p4.negate();
    p4.negate();
    cout << "Result is: " << p4.top() << endl;

    postfixCalculator p5;

    string s;

    cout << "Enter a string with a space between each element: ";

    while (cin >> s) {
        cout << s << endl;

        
        if(s == "+") {
            p5.add();
        }

        else if(s == "-") {
            p5.subtract();
        }

        else if(s == "/") {
            p5.divide();
        }

        else if(s == "*") {
            p5.multiply();
        }

        else if(s == "~") {
            p5.negate();
        }

        else{
        int i = atoi(s.c_str());

        p5.push(i);

        }

    }

    cout << "Result is: " << p5.top() << endl;


    return 0;
}