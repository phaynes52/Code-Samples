"""
Name:   Peter Haynes
Userid: prh7yc

Pledge: On my honor as a student, I have neither given nor received id on this exam. - Peter Haynes
"""
from __future__ import print_function # make python2 print like python3


"""
Complete this function so that it
returns the attendee who is the superstar.

Input is a list of attendees at the conference.
The return type is the same as items in the list, so you should return 
   one of the values stored in the list of attendees.

You must use the knows() function below
to check who knows whom.
"""
def findSuperstar(attendees):

    if (len(attendees) == 1) :
        return attendees[0]

    if(len(attendees) % 2 == 1) :
        oddmanout = attendees[len(attendees) - 1]

        superstar = findSuperstar(attendees[0:(len(attendees) - 1)])

        if( knows(superstar, oddmanout) == True) :
            return oddmanout

        return superstar

    secondindex = (len(attendees) // 2)

    left = findSuperstar(attendees[:secondindex])
    right = findSuperstar(attendees[secondindex:])


    lknowr = knows(left, right)

    if( lknowr == True) :
        return right

    return left


#####################################
# Under penalty of the Honor Code   #
# Do Not Change Anything Below Here #
# (In your final submission)        #
#####################################


def knows(attendee_a, attendee_b):
    """
    returns true if attendee_a knows attendee_b
    """
    global knows_calls_counter
    knows_calls_counter += 1
    return attendee_b in who_knows_whom[attendee_a]


#########################################
# Under penalty of the Honor Code       #
# Do not use anything initialized below #
# (In your final submission)            #
#########################################


knows_calls_counter = 0
conference_file = open("conference1000.txt", 'r')
who_knows_whom = {}
attendee_list_given = []
for line in conference_file.readlines():
    if len(line.strip()) == 0:
        continue
    line_list = line.split()
    person_at_conference = line_list[0]
    known_by_person = line_list[1:]
    who_knows_whom[person_at_conference] = known_by_person
    attendee_list_given.append(person_at_conference)

# Call the findSuperstar function, print the result and the number of times you called knows
print(findSuperstar(attendee_list_given), knows_calls_counter)
