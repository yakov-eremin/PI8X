#pragma once
#include "Phys_Mag_Class.h"

class Physical_Melee : public Physical
{
public:
	void use_ability(Character*, int) override;
	Physical_Melee();
};

class Physical_Ranged : public Physical
{
public:
	void use_ability(Character*, int) override;
	Physical_Ranged();
};

class Magical_Melee : public Magical
{
public:
	void use_ability(Character*, int) override;
	Magical_Melee();
};

class Magical_Ranged : public Magical
{
public:
	void use_ability(Character*, int) override;
	Magical_Ranged();
};
