#pragma once
#include "Map.h"
#include "Memento.h"

class Map_snapshot : public Memento
{
private:
	std::string name;
	int height;
	int width;
	Environment* env;
	std::string bg_image;
	Background_generator* background_generator;
	std::string snapshot_date;
public:
	std::string get_name() override;
	int get_height() override;
	int get_width() override;
	Environment* get_environment() override;
	std::string get_bg_image() override;
	Background_generator* get_background_generator() override;
	std::string get_snapshot_date() override;
	Map_snapshot(Map*);
};

