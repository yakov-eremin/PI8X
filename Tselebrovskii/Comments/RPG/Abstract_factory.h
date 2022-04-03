#pragma once
#include "Class.h"

class Abstract_factory
{
public:
	virtual Class* create_physical();
	virtual Class* create_magical();
};
