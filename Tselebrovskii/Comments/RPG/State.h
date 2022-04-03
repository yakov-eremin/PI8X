#pragma once

class Character;

class State
{
private:
	Character* cur_char;
public:
	virtual void interact();
};

