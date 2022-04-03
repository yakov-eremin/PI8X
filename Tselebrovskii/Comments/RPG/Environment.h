#pragma once
#include "Unique_state_env_obj.h"
#include "NPC_pool.h"

class Environment
{
private:
public:
	std::vector <std::pair<int, int>> spawn_points; //координаты, может как-то прикреплять их к неписям
	std::vector <Unique_state_env_obj*> env_objects; //потом заменить на Unique state
	std::vector <NPC*> assigned_NPCs;
	NPC_pool* pool;
	void add_NPC();
	void spawn_NPCs();
	void add_env_object(Unique_state_env_obj*);
	void relocate_spawn_point(int, int, int);
	Environment(NPC_pool*); //передаём пул НИП

};

