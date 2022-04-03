#include "Class.h"

Class::Class()
{
}

Class::Class(std::string base_desc)
{
	desc = base_desc;
}

void Class::add_ability(Class_ability* abil)
{
	//Class_ability* abil = new Class_ability(); //тут надо подумать как сделать добавление нормальных абилок
	this->list_of_abilities.push_back(abil);
}

std::string Class::get_description()
{
	return desc;
}

void Class::use_ability(Character* target, int n)
{
	list_of_abilities[n]->cast(target);
}

void Class::scale_abilities()
{
	Ability_visitor* visitor = new Scaling_visitor(1.5, 1); //вот эти константы "плохие", но их можно и нужно переделать
	for (auto abil : list_of_abilities)
	{
		abil->accept_visitor(visitor);
	}
}


