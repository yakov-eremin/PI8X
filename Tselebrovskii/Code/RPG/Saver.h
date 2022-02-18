#pragma once
#include <string>
#include <iostream>

class Saver
{
public:
	Saver() {};
	~Saver() {};
	virtual void save_world(std::string filename);
};

