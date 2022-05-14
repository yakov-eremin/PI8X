#include "testgame.h"

TestGame::TestGame(QObject *parent) : QObject(parent)
{

}

void TestGame::direction_test() {
    Game g;
    for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 4; j++) {
            g.grid.addWidget(new QPushButton(QString::number(i*4 + j + 1)), i, j);
        }
    }
    g.grid.removeWidget(g.grid.itemAtPosition(1,2)->widget());
    QCOMPARE(g.direction(0,2), 3);
    QCOMPARE(g.direction(1,3), 2);
    QCOMPARE(g.direction(2,2), 1);
    QCOMPARE(g.direction(1,1), 4);
    QCOMPARE(g.direction(2,1), 0);
    QCOMPARE(g.direction(3,3), 0);
    QCOMPARE(g.direction(10,10), 0);
}

void TestGame::checkGameOver_test() {
    Game g;
    for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 4; j++) {
            QPushButton *push = new QPushButton();
            push->setProperty("number", i*4 + j + 1);
            g.grid.addWidget(push, i, j);
        }
    }
    g.grid.removeWidget(g.grid.itemAtPosition(3,3)->widget());
    QCOMPARE(g.checkGameOver(), 1);
}
