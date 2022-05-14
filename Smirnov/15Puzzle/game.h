#ifndef GAME_H
#define GAME_H

#include <QWidget>
#include <QPushButton>
#include <QGridLayout>
#include <QList>
#include "testgame.h"
class TestGame;
class Game : public QWidget
{
    Q_OBJECT
private:
    QGridLayout grid;
    QList<QPushButton> buttons;
    void createGrid();
    void mix();
    uint direction(uint x, uint y);
    bool checkGameOver();

private slots:
    uint move();

public:
    Game(QWidget *parent = nullptr);
    ~Game();


friend TestGame;
};
#endif // GAME_H
