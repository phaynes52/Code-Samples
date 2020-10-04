# CS4102 Spring 2020 -- Homework 5
#################################
# Collaboration Policy: You are encouraged to collaborate with up to 4 other
# students, but all work submitted must be your own independently written
# solution. List the computing ids of all of your collaborators in the comment
# at the top of your java or python file. Do not seek published or online
# solutions for any assignments. If you use any published or online resources
# (which may not include solutions) when completing this assignment, be sure to
# cite them. Do not submit a solution that you are unable to explain orally to a
# member of the course staff.
#################################
# Your Computing ID: prh7yc
# Collaborators: 
# Sources: Introduction to Algorithms, Cormen
#################################

import copy

class RollerCoaster:

    memory = []
    start = [0,0]
    path = []
    longest = 0

    def __init__(self):
        return

    # This method is the one you should implement.  It will be called to find the
    # the roller coaster's path.  You may create any additional data structures as fields
    # in this class or write any additional methods you need.
    # 
    # @return the length of the longest drop of the coaster
    def run(self, terrain):


        longest = 0

        for row in terrain:

            memrow = []

            for column in row :

                memcol = [0]
                memrow.append(memcol)

            self.memory.append(memrow)

        rowIndex = 0

        for row in terrain:

            columnIndex = 0

            for col in row:

                if (self.memory[rowIndex][columnIndex][0] == 0) :

                    self.findLongest(rowIndex, columnIndex, terrain)

                if(self.memory[rowIndex][columnIndex][0] > longest) :

                    longest = float(self.memory[rowIndex][columnIndex][0])

                    self.start = self.memory[rowIndex][columnIndex][1]

                    self.path = self.memory[rowIndex][columnIndex][2:]

                columnIndex = columnIndex + 1

            rowIndex = rowIndex + 1


        return longest

    # Get the terrain values in the coaster's main drop path, in order from highest to lowest elevation
    #
    # @return the ordered list of terrain values in the coaster's main drop
    def getCoasterPath(self):
        return self.path[::-1]


    # Get the row,column starting point for the coaster's main drop path 
    #
    # @return an int[] with the first element being the row and the second being the column
    def getCoasterStart(self):
        return self.start


    def findLongest(self, row, col, terrain):

        adjacent = []
        adjacentlen = []

        rownum = len(terrain)
        colnum = len(terrain[0])

        if (row != 0 ):

            if (terrain[row-1][col] < terrain[row][col]) :

                if (self.memory[row-1][col][0] == 0 ):

                    self.findLongest((row-1), col, terrain)

                adjacent.append(self.memory[row-1][col])
                adjacentlen.append(self.memory[row-1][col][0])

            else :
                adjacentlen.append(0)
                adjacent.append([0])

        else :
            adjacentlen.append(0)
            adjacent.append([0])

        if (row != (rownum - 1)):

            if (terrain[row + 1][col] < terrain[row][col]) :

                if (self.memory[row+1][col][0] == 0 ):

                    self.findLongest((row+1), col, terrain)

                adjacent.append(self.memory[row+1][col])
                adjacentlen.append(self.memory[row+1][col][0])

            else :
                adjacentlen.append(0)
                adjacent.append([0])

        else :

            adjacentlen.append(0)
            adjacent.append([0])

        if (col != 0 ):

            if (terrain[row][col-1] < terrain[row][col]) :

                if (self.memory[row][col-1][0] == 0 ):

                    self.findLongest(row, (col-1), terrain)

                adjacent.append(self.memory[row][col-1])
                adjacentlen.append(self.memory[row][col-1][0])

            else :
                adjacentlen.append(0)
                adjacent.append(0)

        else :

            adjacentlen.append(0)
            adjacent.append(0)

        if (col != (colnum - 1)):

            if (terrain[row][col+1] < terrain[row][col]) :

                if (self.memory[row][col+1][0] == 0 ):

                    self.findLongest(row, (col+1), terrain)


                adjacent.append(self.memory[row][col+1])
                adjacentlen.append(self.memory[row][col+1][0])

            else :
                adjacentlen.append(0)
                adjacent.append(0)

        else :

            adjacentlen.append(0)
            adjacent.append(0)

        maxv = max(adjacentlen)

        maxdex = adjacentlen.index(maxv)

        if (maxv == 0) :
            self.memory[row][col] = [1, [row,col], terrain[row][col]]

        else :

            data = copy.copy(adjacent[maxdex])

            data[0] = data[0] + 1

            data[1] = [row, col]

            data.append(terrain[row][col])

            self.memory[row][col] = data


        return
