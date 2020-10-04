/*
Peter Haynes
prh7yc
List.cpp
September 9th, 2019
 */
#include <iostream>
#include "List.h"

using namespace std;

List::List() {
	head = new ListNode;
	tail = new ListNode;
	head->next=tail;
	tail->previous=head;
	count=0;
	ListItr iter(head->next);
}

List::~List() {
	makeEmpty();
	delete head;
	delete tail;
}

List::List(const List& source) {      // Copy Constructor
    head=new ListNode;
    tail=new ListNode;
    head->next=tail;
    tail->previous=head;
    count=0;
    ListItr iter(source.head->next);
    while (!iter.isPastEnd()) {       // deep copy of the list
        insertAtTail(iter.retrieve());
        iter.moveForward();
    }
}

List& List::operator=(const List& source) { //Equals operator
    if (this == &source)
        return *this;
    else {
        makeEmpty();
        ListItr iter(source.head->next);
        while (!iter.isPastEnd()) {
            insertAtTail(iter.retrieve());
            iter.moveForward();
        }
    }
    return *this;
}
bool List::isEmpty() const{
	if ( count == 0)
		return true;
	else {
		return false;
	}
}

void List::makeEmpty() {
	ListItr iter(head->next);
    while (!iter.isPastEnd()) {
        delete iter.current;
        iter.moveForward();
        count--;
    }
	head->next = tail;
	tail->previous = head;

}

ListItr List::first() {
	return ListItr(head->next);
}

ListItr List::last() {
	return ListItr(tail->previous);
}

void List::insertAfter( int x, ListItr position) {
	ListNode * in = new ListNode();
	in->value = x;
	position.current->next->previous = in;
	in->next = position.current->next;
	position.current->next = in;
	in->previous = position.current;
	count++;

}

void List::insertBefore(int x, ListItr position) {
	ListNode * in = new ListNode();
	in->value = x;
	position.current->previous->next = in;
	in->previous = position.current->previous;
	position.current->previous = in;
	in->next = position.current;
	count++;


}

void List::insertAtTail(int x) {
	ListNode * in = new ListNode();
	in->value = x;
	tail->previous->next = in;
	in->previous = tail->previous;
	tail->previous = in;
	in->next = tail;
	count++;

}

void List::remove(int x) {
	ListItr position = find(x);
	position.current->previous->next = position.current->next;
	position.current->next->previous = position.current->previous;
	delete position.current;
	count--;

}

ListItr List::find(int x) {
	ListItr iter(head->next);
	while (!iter.isPastEnd()) {
        if( iter.retrieve() == x)
        	return ListItr(iter.current);
        else{
        	iter.moveForward();
        }
	last();
	}
}

int List::size() const{
	return count;
}

void List::removeLast() {
	ListItr last = last();
	last.current->previous->next = last.current->next;
	last.current->next->previous = last.current->previous;
	delete last.current;
}

void printList(List& source, bool direction){
	ListItr first = source.first();
	ListItr last = source.last();
	cout << "[";
	if (direction == true) {
    	while (!first.isPastEnd()) {     
        		cout << first.retrieve() << ", ";
        		first.moveForward();

    	}
    }
    else{
    	while (!last.isPastBeginning()) {       
        	cout << last.retrieve() << ", ";
        	last.moveBackward();
    	}
	}
	cout << "\b\b]";
}
