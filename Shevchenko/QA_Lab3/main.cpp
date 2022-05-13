#include "mainwindow.h"

#include <QApplication>
#include <QMediaPlayer>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();

    // Setting up background music
    QMediaPlayer * musicPlayer = new QMediaPlayer();
    musicPlayer->setMedia(QUrl("qrc:/backgroundMusic/assets/menuBackground.mp3"));
    // musicPlayer->play();
    return a.exec();
}


