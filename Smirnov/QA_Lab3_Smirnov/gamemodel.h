#ifndef GAMEMODEL_H
#define GAMEMODEL_H

#include <QWidget>
#include <vector>
#include <QTimer>
#include "player.h"
#include "doctor.h"
#include "inhabitant.h"
#include "mafia.h"

namespace Ui {
class GameModel;
}
/*!
    \brief Класс игровой модели

    Данный класс предназначен для проведения игровых итераций и вывода ннформации о них в окно.
*/
class GameModel : public QWidget
{
    Q_OBJECT

public:
    explicit GameModel(QWidget *parent = nullptr);
    GameModel(QWidget *parent = nullptr, std::vector<player*> *list = nullptr, bool h = false);
    ~GameModel();

private:
    Ui::GameModel *ui;
    std::vector<player*> Players;
    std::vector<player*> Mafia;
    player* Doctor;
    quint8 m_count = 0, c_count = 0;

    bool is_hidden;
    bool *flags, *flags_night;
    quint8 is_wounded, is_healed;
    quint8 *votes;
    QTimer *timer;
    quint16 internalTime = 0;

    void GameOver(bool winner);
private slots:
    void timerInterrupt();
};

#endif // GAMEMODEL_H
