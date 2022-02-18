#pragma once
#include "Map_snapshot.h"
#include <vector>

class Map_history
{
private:
	Map* map;
	std::vector<Map_snapshot*> snapshot_history;
public:
	void save_map();
	void restore_snapshot(int);
	void get_history();
	Map_history(Map*);
};

