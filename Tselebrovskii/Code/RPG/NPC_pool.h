#pragma once
#include "NPC.h"

class NPC_pool
{
private:
	std::vector<NPC*> NPC_list;
	std::vector<bool> is_free; //свободен ли определённый NPC
public:
	NPC_pool(int);
	NPC* get_NPC();
	void free_NPC(NPC*);
};

