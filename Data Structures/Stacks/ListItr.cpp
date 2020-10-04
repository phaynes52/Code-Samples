/*
Peter Haynes
prh7yc
List.cpp
September 9th, 2019
 */
#include <iostream>
#include "ListItr.h"

using namespace std;

ListItr::ListItr() {
	current = new ListNode();
	}

ListItr::ListItr(ListNode* theNode) {
	current = theNode;
	}

bool ListItr::isPastEnd() const{
	if (current->next != NULL)
		return false;
	else{
		return true;
	}
}

bool ListItr::isPastBeginning() const{
	if (current->previous != NULL)
		return false;
	else{
		return true;
	}
}

void ListItr::moveForward() {
	if (current->next != NULL)
		current = current->next;
	else{}

}

void ListItr::moveBackward() {
	if (current->previous != NULL)
		current = current->previous;
	else{}
}

int ListItr::retrieve() const{
	return current->value;
}
/*
void ListItr::remove() {
	current->previous->next = current->next;
	current->next->previous = current->previous;
	delete current;
	moveBackward();
}
*/