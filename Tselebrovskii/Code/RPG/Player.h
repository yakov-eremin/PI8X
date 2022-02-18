#pragma once
#include "Character.h"

class Player :
    public Character
{
private:  
public:
    int karma_points;
    Player(std::string);
    Player();
};

