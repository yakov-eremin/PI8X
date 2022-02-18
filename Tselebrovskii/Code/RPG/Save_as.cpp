#include "Save_as.h"

//TODO: хотя бы файлики открывать

void Save_as_txt::save_world(std::string filename)
{
	std::cout << "World saved as " << filename << ".txt" << std::endl;
	if (this->wrapee != nullptr)
		wrapee->save_world(filename);
}

Save_as_txt::Save_as_txt(Saver * saver)
{
	wrapee = saver;
}

void Save_as_dat::save_world(std::string filename)
{
	std::cout << "World saved as " << filename << ".dat" << std::endl;
	if (this->wrapee != nullptr)
		wrapee->save_world(filename);
}

Save_as_dat::Save_as_dat(Saver* saver)
{
	wrapee = saver;
}

void Save_as_wrld::save_world(std::string filename)
{
	std::cout << "World saved as " << filename << ".wrld" << std::endl;
	if (this->wrapee != nullptr)
		wrapee->save_world(filename);
}

Save_as_wrld::Save_as_wrld(Saver* saver)
{
	wrapee = saver;
}