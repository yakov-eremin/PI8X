#ifndef TESTGAME_H
#define TESTGAME_H

#include <QObject>
#include <QtTest/QtTest>
#include <game.h>

class TestGame : public QObject
{
    Q_OBJECT
public:
    explicit TestGame(QObject *parent = nullptr);

private slots:
    void direction_test();
    void checkGameOver_test();

signals:

};

#endif // TESTGAME_H
