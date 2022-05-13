#include "testmainwindow.h"

TestMainWindow::TestMainWindow(QObject *parent) : QObject(parent)
{

}

void TestMainWindow::getBrightness_data() {
    QTest::addColumn<QRgb>("color");
    QTest::addColumn<int>("brightness");

    QTest::newRow("1") << 0xfff3e5ab << 226;
    QTest::newRow("2") << 0xff27261a << 360;
    QTest::newRow("3") << 0xffedff21 << 224;
    QTest::newRow("4") << 0xff434750 << 70;
    QTest::newRow("5") << 0xff423c63 << 66;
    QTest::newRow("6") << 0xff35682d << 812;
    QTest::newRow("7") << 0xffb27070 << 131;
    QTest::newRow("8") << 0xff20b2aa << 133;
    QTest::newRow("9") << 0xfffadadd << 128;
    QTest::newRow("10") << 0xfffde910 << 214;
}

void TestMainWindow::getBrightness() {
    MainWindow w;
    QFETCH(QRgb, color);
    QFETCH(int, brightness);

    QCOMPARE(w.getBrightness(color),brightness);
}
