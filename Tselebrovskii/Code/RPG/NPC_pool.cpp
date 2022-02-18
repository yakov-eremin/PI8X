#include "NPC_pool.h"

NPC_pool::NPC_pool(int amount)
{
	for (int i = 0; i < amount; i++)
	{
		NPC_list.push_back(new NPC("npc" + std::to_string(i), rand() % 50 + 50));
		is_free.push_back(true);
	}
}

NPC* NPC_pool::get_NPC()
{
	for (int i = 0; i < NPC_list.size(); i++)
	{
		if (is_free[i])
		{
			is_free[i] = false;
			return NPC_list[i];
		}
	}
	return nullptr;
}

void NPC_pool::free_NPC(NPC* input)
{
	for (int i = 0; i < NPC_list.size(); i++)
	{
		if (NPC_list[i] == input)
		{
			is_free[i] = true;
		}
	}
}
