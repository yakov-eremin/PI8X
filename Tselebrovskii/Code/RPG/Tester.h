#pragma once
#include "World.h"
#include "Player.h"
#include "Class_ability.h"
#include "Saver.h"
#include "Saver_decorator.h"
#include "Save_as.h"
#include "Environmental_object.h"
#include "Compound_object.h"
#include "Primitive_object.h"
#include "Environment.h"
#include "Background_generator.h"
#include "Perlin_noise.h"
#include "Voronoi_diagramm.h"
#include "Loader.h"
#include "Unique_state_env_obj.h"
#include "Player_director.h"
#include "Map_history.h"
#include "Publisher.h"
#include "Abilities.h"
#include "Different_ability_creators.h"
#include <iostream>
#include <stdio.h>

class Tester
{
public:
	void play(); //"потестировать" "игру"
	void move_player(Player*);
	void choose_target(Class_ability*);
	void choose_ability();
	void use_object();
	void main_menu(); //начало "создания игры", "главное меню"
	void work_with_player(); //работа с персонажем игрока
	Player* create_player();
	void edit_player(Player*);
	void work_with_map();
	void edit_map(Map*);
	void work_with_map_env(Map*);
	Unique_state_env_obj* create_env_obj();
	void choose_class(Player*);
	void add_abilities(Player*);
};

