#include "Primitive_object.h"

Primitive_object::Primitive_object()
{

}

Primitive_object::Primitive_object(std::string new_sprite)
{
	sprite = new_sprite;
}

void Primitive_object::react()
{
	std::cout << "I'm primitive with sprite " << sprite << std::endl;
}