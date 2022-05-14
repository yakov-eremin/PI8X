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
    if (y > 0 && y < 4 && !grid.itemAtPosition(x,y-1)) return 2;
    if (x > 0 && x < 4 && !grid.itemAtPosition(x-1,y)) return 1;
    if (y < 3 && !grid.itemAtPosition(x,y+1)) return 4;
    return 0;
}

bool Game::checkGameOver() {
    for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 4; j++) {
            if (grid.itemAtPosition(i,j) == nullptr) continue;
            if (grid.itemAtPosition(i,j)->widget()->property("number") != i*4 + j + 1) return false;
        }
    }
    return true;
}

