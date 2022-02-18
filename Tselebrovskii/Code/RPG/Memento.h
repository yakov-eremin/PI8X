#pragma once
#include <string>
#include "Environment.h"
#include "Background_generator.h"

class Memento
{
public:
	virtual std::string get_name();
	virtual int get_height();
	virtual int get_width();
	virtual Environment* get_environment();
	virtual std::string get_bg_image();
	virtual Background_generator* get_background_generator();
	virtual std::string get_snapshot_date();
	Memento();
};

