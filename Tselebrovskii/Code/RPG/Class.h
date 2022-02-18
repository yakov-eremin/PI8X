#pragma once
#include <vector>
#include "Class_ability.h"
#include "Subscriber.h"
#include "Scaling_visitor.h" //плохо

class Character;

class Class : public Subscriber
{
protected:	
	std::string desc;
public:
	float preferred_range = 1;
	std::vector <Class_ability*> list_of_abilities;
	Class();
	Class(std::string);
	void add_ability(Class_ability*);
	std::string get_description();
	virtual void use_ability(Character*, int);
	void scale_abilities();
};

