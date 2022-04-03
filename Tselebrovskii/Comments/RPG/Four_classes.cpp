#include "Four_classes.h"

void Physical_Melee::use_ability(Character* target, int i)
{
	//��������� ��������� ������������ ������������ ���� ����� � ����� ���������.
	list_of_abilities[i]->cast(target);
}

Physical_Melee::Physical_Melee()
{
	preferred_range = 10;
	desc = "���������� ���������� �����";
}

void Physical_Ranged::use_ability(Character* target, int i)
{
	list_of_abilities[i]->cast(target);
}

Physical_Ranged::Physical_Ranged()
{
	preferred_range = 35;
	desc = "���������� ������������ �����";
}

void Magical_Melee::use_ability(Character* target, int i)
{
	list_of_abilities[i]->cast(target);
}

Magical_Melee::Magical_Melee()
{
	preferred_range = 10;
	desc = "���������� ���������� �����";
}

void Magical_Ranged::use_ability(Character* target, int i)
{
	list_of_abilities[i]->cast(target);
}


Magical_Ranged::Magical_Ranged()
{
	preferred_range = 35;
	desc = "���������� ������������ �����";
}
