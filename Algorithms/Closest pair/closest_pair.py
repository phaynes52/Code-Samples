# CS4102 Spring 2020 - Homework 3
#################################
# Collaboration Policy: You are encouraged to collaborate with up to 4 other
# students, but all work submitted must be your own independently written
# solution. List the computing ids of all of your collaborators in the
# comments at the top of each submitted file. Do not share written notes,
# documents (including Google docs, Overleaf docs, discussion notes, PDFs), or
# code. Do not seek published or online solutions, including pseudocode, for
# this assignment. If you use any published or online resources (which may not
# include solutions) when completing this assignment, be sure to cite them. Do
# not submit a solution that you are unable to explain orally to a member of
# the course staff. Any solutions that share similar text/code will be
# considered in breach of this policy. Please refer to the syllabus for a
# complete description of the collaboration policy.
#################################
# Your Computing ID: prh7yc
# Collaborators: None
# Sources: Introduction to Algorithms, Cormen
#################################

class ClosestPair:

    def __init__(self):
        return

    # This is the method that should set off the computation
    # of closest pair.  It takes as input a list lines of input
    # as strings.  You should parse that input and then call a
    # subroutine that you write to compute the closest pair distance
    # and return that value from this method
    #
    # @return the distance between the closest pair 
    def compute(self, file_data):

        parsed = self.parsedata(file_data)

        closest = self.closestPair(parsed)

        return closest

    def parsedata(self, points) :
        from operator import itemgetter

        parsed_points = []

        for point in points:
            point = point.strip()
            point = point.split(" ")
            pair = [float(point[0]), float(point[1])]
            parsed_points.append(pair)

        return sorted(parsed_points, key=itemgetter(1))

    def distance( self, pair1, pair2 ) :
        from math import sqrt

        x = (pair1[0] - pair2[0])**2
        y = (pair1[1] - pair2[1])**2

        dist = sqrt(x + y)

        return dist


    def closestPair(self, parsed_data) :
        from statistics import median

        if( len(parsed_data) < 2) :
            return float("inf")


        mindist = self.distance(parsed_data[0],parsed_data[1])

        if (len(parsed_data) < 4) :
            for pair1 in parsed_data :
                for pair2 in parsed_data :
                    if( parsed_data.index(pair1) != parsed_data.index(pair2) ) :
                        #print(pair1)
                        #print(pair2)
                        compdist = self.distance(pair1,pair2)
                        #print(compdist)

                        if(compdist < mindist) :
                            mindist = compdist

            return mindist

        xcoordinates = []

        for line in parsed_data :
            xcoordinates.append(line[0])

        median = median(xcoordinates)
        #print(median)

        left = []
        right = []

        for line in parsed_data :
            if (line[0] < median) :
                left.append(line)
            else :
                right.append(line)

        mindist = min(self.closestPair(left), self.closestPair(right))

        #print(mindist)

        leftlimit = median - mindist
        rightlimit = median + mindist

        inthecut = []

        for line in parsed_data :
            if (leftlimit < line[0] and line[0] < rightlimit) :
                inthecut.append(line)

        #print(inthecut)

        index1 = 0
        index2 = 1

        for point in inthecut:

            for i in range(0, 15):

                if( index2 == (len(inthecut))) :
                    break

                compdist = self.distance(inthecut[index1], inthecut[index2])
                #print(inthecut[index1],inthecut[index2])
                #print(compdist)

                if( compdist < mindist ):
                    mindist = compdist

                index2 = index2 + 1


            index1 = index1 + 1
            index2 = index1 + 1

        return mindist



