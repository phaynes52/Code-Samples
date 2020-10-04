#include <iostream>
#include <vector>
#include <string>
#include <map>

#ifndef MIDDLEEARTH_H
#define MIDDLEEARTH_H

using namespace std;

class MiddleEarth {
private:
    int num_city_names;     ///< Number of cities
    int xsize;      ///< width of the graph
    int ysize;    ///< height of the graph
    vector<float> xpos, ypos;   ///< store x and y coordinates for cities
    vector<string> cities;      ///< stores list of cities
    float *distances;           ///< stores distances between cities
    map<string, int> indices;   ///< tracks the index location of cities

public:
  
    MiddleEarth (int xsize, int ysize, int numcities, int seed);
    ~MiddleEarth();
    void print();
    void printTable();
    float getDistance (string city1, string city2);
    vector<string> getItinerary(unsigned int length);
};

#endif
