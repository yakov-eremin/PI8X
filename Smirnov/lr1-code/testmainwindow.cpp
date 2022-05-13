#include "testmainwindow.h"

TestMainWindow::TestMainWindow(QObject *parent) : QObject(parent)
{

}

void TestMainWindow::getBrightness() {
    MainWindow w;

    QCOMPARE(w.getBrightness(0xfff3e5ab),226);
    QCOMPARE(w.getBrightness(0xff27261a),366);
    QCOMPARE(w.getBrightness(0xffedff21),224);
    QCOMPARE(w.getBrightness(0xff434750),70);
    QCOMPARE(w.getBrightness(0xff423c63),66);
}
