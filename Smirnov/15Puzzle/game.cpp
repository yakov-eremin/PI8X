#include "game.h"

Game::Game(QWidget *parent)
    : QWidget(parent)
{
    grid = new QGridLayout();
    grid->setHorizontalSpacing(1);
    grid->setVerticalSpacing(1);
    grid->setContentsMargins(2, 2, 2, 2);
    for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 4; j++) {
            QPushButton* push = new QPushButton();
            push->setIcon(QIcon(":/icons/icons/" + QString::number(i*4 + j + 1) + ".png"));
            push->setProperty("number", i*4 + j + 1);
            push->setFixedSize(100,100);
            push->setIconSize(QSize(100,100));
            grid->addWidget(push, i, j);
        }
    }
    setLayout(grid);
}

Game::~Game()
{
}

uint Game::move() {

}

uint Game::direction(uint x, uint y) {
    if (x < 3 && !grid->itemAtPosition(x+1,y)) return 3;
    if (y > 0 && y < 4 && !grid->itemAtPosition(x,y-1)) return 2;
    if (x > 0 && x < 4 && !grid->itemAtPosition(x-1,y)) return 1;
    if (y < 3 && !grid->itemAtPosition(x,y+1)) return 4;
    return 0;
}

bool Game::checkGameOver() {
    for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 4; j++) {
            if (grid->itemAtPosition(i,j) == nullptr) continue;
            if (grid->itemAtPosition(i,j)->widget()->property("number") != i*4 + j + 1) return false;
        }
    }
    return true;
}

