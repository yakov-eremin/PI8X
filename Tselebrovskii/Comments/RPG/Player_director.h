#pragma once
#include "Player_builder.h"

class Player_director
{
private:
	Player_builder* builder;
public:
	Player* make_warrior();
	Player* make_mage();
	Player* make_custom();
	Player_director();
};

