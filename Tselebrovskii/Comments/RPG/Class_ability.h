#pragma once
#include <string>
#include "Ability_visitor.h"

class Character;

class Class_ability
{
private:
	std::string desc;
	float cast_range;
public:
	Class_ability();
	Class_ability(float, std::string);
	virtual void cast(Character*);
	virtual std::string get_description();
	virtual void accept_visitor(Ability_visitor*);
};

