#pragma once
#include "Class_ability.h"

class Ability_creator
{
public:
	virtual Class_ability* create_ability(float, std::string);
};

