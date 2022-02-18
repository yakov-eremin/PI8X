#pragma once
#include "Saver.h"
#include <string>

class Saver_decorator : public Saver
{
protected:
	Saver* wrapee;
public:
	Saver_decorator();
	Saver_decorator(Saver*);
	virtual void save_world(std::string filename) override;
};

