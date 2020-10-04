/* Peter Haynes
 * prh7yc
 * Filename: topological.cpp
 * December 2nd, 2019
 */

// included so we can use cout
#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <unordered_map>
#include <vector>
#include <string>
#include <queue>

using namespace std;

	vector< vector<int> > graph; ///< matrix to store graph
	int indx = 0; ///< keeps track of index when inserting new elements
	int size; ///< tracks how many distinct vertices are in the graph
	unordered_map<string, int> indices; ///< maps desired element to their index in the graph
	unordered_map<int, string> backind; ///< maps the graph index to the corresponding element
	unordered_map<string, int> ndegree; ///< maps elements to their indegree


/**
    * \brief Brief: performs a topological sort
    *
    * Sorts a directed graph into a linear ordering of its vertices such that for every directed edge uv from vertex u to vertex v, u comes before v in the ordering.
    * 
    * \param indices mapping of vertices to their indices in the graph
    * \param backind mapping of map indexes to the values of their vertices
    * \param ndegree tracks the indegree of vertices
    * \param graph graph containing the code marking the eges between vertices
*/
void topologicalSort(unordered_map<string, int> indices, unordered_map<int, string> backind, unordered_map<string, int> ndegree, vector< vector<int> > graph){
	queue<string> topsort;

  	///finds the starting vertices
  	for( auto const& pair : ndegree){
    	if (pair.second == 0){
    		topsort.push(pair.first);
    	}
    }
    /// Sorts subsequent indices based on their indegree values
    while( !topsort.empty()){
    	string clss = topsort.front();
    	topsort.pop();
    	int dex = indices[clss];

    	for(int i = 0; i < size; i++){

    		string cl2 = backind[i];

    		if( graph[dex][i] == 1){

    			if(--ndegree[cl2] == 0){
    				topsort.push(cl2);
    			}
    		}
    	}

    	cout << clss << " ";


    }

    cout << endl;
}

/**
    * \brief Brief: performs topological sort
    *
    * Takes in a set of edges, constructs a graph, and sorts the graph topologically. 
    * 
    * \param argc defines how many arguments to pass the main method
    * \param **argv the arguments actually passed to the main method. argv[1] contains the file full of edges.
*/
int main (int argc, char **argv) {
    // verify the correct number of parameters
    if ( argc != 2 ) {
        cout << "Must supply the input file name as the one and only parameter" << endl;
        exit(1);
    }
    /// attempt to open the supplied file
    ifstream file(argv[1], ifstream::binary);
    // report any problems opening the file and then exit
    if ( !file.is_open() ) {
        cout << "Unable to open file '" << argv[1] << "'." << endl;
        exit(2);
    }

    ///read through the file one edge at a time
    while(!file.eof()){
    	string s1, s2;
    	file >> s1;
    	file >> s2;

    	if( s1 == "0" ){
    		if( s2 == "0"){
    			break;
    		}
    	}

    	///check if the vertices listed in the edge are in the file, if not assign them indices and insert them
    	if(indices.find(s1) == indices.end()){
    		indices[s1] = indx;
    		backind[indx] = s1;
    		///increment the index for the next insertion
    		indx++;
    	}
    	if(indices.find(s2) == indices.end()){
    		indices[s2] = indx;
    		backind[indx] = s2;
    		indx++;
    	}

    	///add starting vertices by checking for elements that have nothing that map to them an thus have indegree values of 0. Add them to the ndegree map.
    	if(ndegree.find(s1) == ndegree.end()){
    		ndegree[s1] = 0;
    	}
    	ndegree[s2]++;
    }

    ///close the file
    file.close();

    ///open the file a second time to create the graph
    ifstream file2(argv[1], ifstream::binary);


    size = indices.size();

	///resize the graph to the correct number of rows and columns given the data
    graph.resize(size);
    for (int i = 0; i < size; ++i){
    	graph[i].resize(size);
    }


    ///insert the edges into the graph by changing the value at the row and column corresponding to the beginning and ending vertex respectively.
    while(!file2.eof()){
    	string s1, s2;
    	file2 >> s1;
    	file2 >> s2;

    	if( (s1 == "0") && (s2 == "0")){
    		break;
    	}

    	graph[indices[s1]][indices[s2]] = 1;

    }

    ///close the file again
    file2.close();

    ///run topologicalSort with the given graph and data.
    topologicalSort(indices, backind, ndegree, graph);


	}

