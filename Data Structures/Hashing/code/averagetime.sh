#!/bin/bash

#Peter Haybes
#prh7yc
#10/20/1998
#averagetime.sh

#prompt the user to enter a dictionary file
echo "Enter dictionary filename:"
#set the dictionary filename equal to a variable called dictionary
read dictionary
#prompt the user to enter a grid file
echo "Enter grid filename:"
#set the grid filename equal to a variable called grid.
read grid

#Run the program 5 times using the inputted dictionary and grid files and output the time in milliseconds after each run
RUNNING_TIME1=`./a.out $dictionary $grid | tail -1`
echo $RUNNING_TIME1
RUNNING_TIME2=`./a.out $dictionary $grid | tail -1`
echo $RUNNING_TIME2
RUNNING_TIME3=`./a.out $dictionary $grid | tail -1`
echo $RUNNING_TIME3
RUNNING_TIME4=`./a.out $dictionary $grid | tail -1`
echo $RUNNING_TIME4
RUNNING_TIME5=`./a.out $dictionary $grid | tail -1`
echo $RUNNING_TIME5


#Sum all the times
TOTAL_TIME=$(($RUNNING_TIME1 + $RUNNING_TIME2 + $RUNNING_TIME3 + $RUNNING_TIME4 + $RUNNING_TIME5))
#Find the average time
AVERAGE_TIME=$(($TOTAL_TIME / 5 ))
#print the average time
echo $AVERAGE_TIME