#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <algorithm>

using namespace std;

#include "middleearth.h"

float computeDistance (MiddleEarth &me, string start, vector<string> dests);
void printRoute (string start, vector<string> dests);


/**
    * \brief Brief: finds the shortest path
    *
    * Takes in parameters width, height, num_cities, rand_seed, and cities_to_visit to determine the size of the map, 
    * how many cities to put on the map, how many cities to go to on the path, and give a seed to the randomize functions. 
    * Does through every permutation of the route, finds the distance, and tracks the shortest route and its distance.
    * 
    * \param argc defines how many arguments to pass the main method
    * \param **argv the arguments actually passed to the main method. argv[1] contains the file full of edges.
*/
int main (int argc, char **argv) {
    // check the number of parameters
    if ( argc != 6 ) {
        cout << "Usage: " << argv[0] << " <world_height> <world_width> "
             << "<num_cities> <random_seed> <cities_to_visit>" << endl;
        exit(0);
    }
    // we'll assume the parameters are all well-formed
    int width, height, num_cities, rand_seed, cities_to_visit;
    sscanf (argv[1], "%d", &width);
    sscanf (argv[2], "%d", &height);
    sscanf (argv[3], "%d", &num_cities);
    sscanf (argv[4], "%d", &rand_seed);
    sscanf (argv[5], "%d", &cities_to_visit);
    // Create the world, and select your itinerary
    MiddleEarth me(width, height, num_cities, rand_seed);
    vector<string> dests = me.getItinerary(cities_to_visit);

    string start = dests[0];

    dests.erase(dests.begin());
    
    vector<string> path = dests;

    int size = dests.size();

    float mindist = computeDistance( me, start, dests);

    sort(dests.begin(), dests.end());

    do {
        if( computeDistance( me, start, dests) < mindist){
            mindist = computeDistance( me, start, dests);
            path = dests;
        }
    } while(next_permutation(dests.begin(), dests.end())); ///Uses next_permutation to get every permutation of the route

    printRoute(start, path);
    cout << mindist << endl;
    return 0;
}





/**
    * \brief Brief: computes total distance of a route
    *
    * This method will compute the full distance of the cycle that starts
    * at the 'start' parameter, goes to each of the cities in the dests
    * vector IN ORDER, and ends back at the 'start' parameter.
    *
    * \param me the MiddleEarth world to perform the operation at
    * \param start the starting. city for the route
    * \param dests the list of cities to travel to on the route
*/
float computeDistance (MiddleEarth &me, string start, vector<string> dests) {
    float dist = 0;
    int size = dests.size();

    dist = me.getDistance(start, dests[0]);

    for( int i = 1; i < size; i++){
        dist = dist + me.getDistance(dests[i-1], dests[i]);
    }

    dist = dist + me.getDistance(dests[size-1], start);

    return dist;
}

// This method will print the entire route, starting and ending at the
// 'start' 

/**
    * \brief Brief: prints the route
    *
    * This method prints the entire route beginning and ending
    * with the city given in the 'start' string
    *
    * \param start the starting. city for the route
    * \param dests the list of cities to travel to on the route
*/
void printRoute (string start, vector<string> dests) {
    cout << start << " -> ";
    int size = dests.size();

    for( int i = 0; i < size; i++){
        cout << dests[i] << " -> ";
    }
    cout << start << endl;
}
