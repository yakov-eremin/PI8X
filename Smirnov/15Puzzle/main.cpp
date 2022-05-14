#include "game.h"
#include "testgame.h"

#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    QTest::qExec(new TestGame);
    Game w;
    w.show();
    return a.exec();
}
