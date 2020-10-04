# CS4102 Spring 2020 -- Homework 8
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
# Collaborators: None
# Sources: Introduction to Algorithms, Cormen, https://networkx.github.io/documentation
#################################

import networkx as nx

class TilingDino:
    def __init__(self):
        return

    # This is the method that should set off the computation
    # of tiling dino.  It takes as input a list lines of input
    # as strings.  You should parse that input, find a tiling,
    # and return a list of strings representing the tiling
    #
    # @return the list of strings representing the tiling
    def compute(self, lines):
        blacktiles = []
        whitetiles = []

        row = 0

        for line in lines:
            lines[row] = list(line)
            row += 1

        row = 0

        for line in lines:

            col = 0

            for tile in line:

                if tile == "#":

                    if ((row % 2 == 0) and (col % 2 == 0)):
                        lines[row][col] = "B"
                        blacktiles.append(str(row) + "," + str(col))

                    elif ((row % 2 == 1) and (col % 2 == 1)):
                        lines[row][col] = "B"
                        blacktiles.append(str(row) + "," + str(col))

                    else:
                        lines[row][col] = "W"
                        whitetiles.append(str(row) + "," + str(col))


                col = col + 1

            row = row + 1

        totaltiles = len(blacktiles) + len(whitetiles)

        flow = nx.DiGraph()

        flow.add_node("source")
        flow.add_node("sink")

        for tile in blacktiles:
            flow.add_node(tile)
            flow.add_edge("source", tile, capacity=1)

        for tile in whitetiles:
            flow.add_node(tile)
            flow.add_edge(tile, "sink", capacity=1)

        for tile in blacktiles:
            coord = tile.split(",")
            coord = [int(coord[0]),int(coord[1])]

            row = coord[0]
            col = coord[1]

            try:

                if lines[row-1][col] == "W" :
                    white = (str(row-1) + "," + str(col))
                    flow.add_edge(tile,white, capacity=1)

            except IndexError:
                pass

            try:

                if lines[row+1][col] == "W" :
                    white = (str(row+1) + "," + str(col))
                    flow.add_edge(tile,white,capacity=1)

            except IndexError:
                pass

            try:

                if lines[row][col-1] == "W" :
                    white = (str(row) + "," + str(col-1))
                    flow.add_edge(tile,white, capacity=1)

            except IndexError:
                pass

            try:

                if lines[row][col+1] == "W" :
                    white = (str(row) + "," + str(col+1))
                    flow.add_edge(tile,white,capacity=1)

            except IndexError:
                pass

        if( totaltiles == 0) :
            return ["impossible"]


        if( totaltiles % 2 == 1) :
            return ["impossible"]

        if( totaltiles // 2 > nx.maximum_flow(flow,"source", "sink")[0]):
            return ["impossible"]

        if( totaltiles // 2 == nx.maximum_flow(flow,"source", "sink")[0]):
            flowdict = nx.maximum_flow(flow,"source", "sink")[1]

            firstnodes = []

            for term in flowdict["source"]:
                firstnodes.append(term)

            secondnodes = []

            for node in firstnodes :
                seconds = flowdict[node]
                for second in seconds:
                    if (flowdict[node][second] == 1):
                        secondnodes.append(second)

            final = []

            rng = len(firstnodes)

            for i in range(0, rng):
                first = firstnodes[i].split(",")
                second = secondnodes[i].split(",")

                row = str(first[1]) + " " + str(first[0]) + " " + str(second[1]) + " " + str(second[0])

                final.append(row)

            return final



