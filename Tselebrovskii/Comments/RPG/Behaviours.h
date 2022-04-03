#pragma once
#include "Behaviour.h"
#include <iostream>

class Active : public Behaviour
{
public:
	void react() override;
};
class Inactive : public Behaviour
{
public:
	void react() override;
};
class Destroyed : public Behaviour
{
public:
	void react() override;
};

