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
    if (!grid.itemAtPosition(x+1,y)) return 3;
    if (!grid.itemAtPosition(x,y-1)) return 2;
    if (!grid.itemAtPosition(x-1,y)) return 1;
    if (!grid.itemAtPosition(x,y+1)) return 4;
}

