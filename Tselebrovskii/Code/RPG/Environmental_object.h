#pragma once
#include <string>
#include <iostream>

class Environmental_object
{
protected:
	std::string sprite; //название файла со спрайтом
public:
	Environmental_object();
	Environmental_object(std::string);
	virtual void react();
};

