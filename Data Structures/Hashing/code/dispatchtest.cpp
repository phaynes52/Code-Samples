//dispatchtest.cpp

#include <string>
#include <iostream>

using namespace std

class Parent {
	public:

		virtual void print(){
			cout << "Hello World" << endl;
		}

		virtual int pass() {
			return 0;
		}
}

class Child : public Parent {
	public:

		virtual void print(string s){
			cout << "Hello Peter" << endl;
		}

		virtual void pass() {
			;
		}
}

int main() {
	Parent* Cindy = new Parent;
	Child* Peter = new Child;
	Parent* Tony = new Child;

	Cindy.print();
	Peter.print();
	Tony.print();

	Cindy.pass();
	Peter.pass();
	Tony.pass();

}