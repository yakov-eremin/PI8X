#include "game.h"

Game::Game(QWidget *parent)
    : QWidget(parent)
{
}

Game::~Game()
{
}

uint Game::move() {

}

uint Game::direction(uint x, uint y) {
    if (x < 3 && !grid.itemAtPosition(x+1,y)) return 3;
    if (y > 0 && !grid.itemAtPosition(x,y-1)) return 2;
    if (x > 0 && !grid.itemAtPosition(x-1,y)) return 1;
    if (y < 3 && !grid.itemAtPosition(x,y+1)) return 4;
    return 0;
}

