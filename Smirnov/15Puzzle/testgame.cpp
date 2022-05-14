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
}
