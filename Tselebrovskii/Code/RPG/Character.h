#pragma once
#include <string>
#include <iostream>
#include "States.h"
#include "Abstract_factory.h"
#include "Concrete_factories.h"

class Character
{
protected: 
	std::string name;
	int health;
	int resource;
public:
	Class* game_class;
	Class_ability* selected_ability = nullptr;
	Abstract_factory* factory;
	State* state;
	float x, y;
	Character();
	Character(std::string, int);
	int get_health();
	void set_health(int);
	int get_resource();
	void set_resource(int);
	std::vector<Character*> get_visible_characters();
	void spawn(int, int);
	void set_class(bool);
	void check_health();
	void interact(Character*);
	std::string get_name();
	void set_name(std::string);
	void cast_ability(Character*);
};

 