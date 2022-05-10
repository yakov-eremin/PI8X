#include "player.h"
#include <algorithm>
#include <cstdlib>
#include <ctime>
#include <QGraphicsTextItem>

bool player::accident(quint8 p) {
    srand( time(0) );
    if ((rand()%100+1) < (11 * p)) return true;
    return false;
}

player::player()
{

}

player::player(quint8 id, QString name, QString gender, quint8 age, quint8 elo, quint8 inc, quint8 pas, quint8 det) {
    ID = id;
    Name = name;
    if (gender == "male") Gender = male;
    else Gender = female;
    Age = age;
    Mental.Eloquence = elo;
    Mental.Incredulity = inc;
    Mental.Aggression = pas;
    Mental.Determination = det;
}
void player::setGraphicsView(QGraphicsView *b) {
    block = b;
}

void player::addEnemy(quint8 i, qint8 p) {
    auto it = std::find(enemies.begin(), enemies.end(), i);
    if (it != enemies.end()) it->priority += p;
    else enemies.push_back({i, p});
}

void player::delEnemy(quint8 i) {
    auto it = std::find(enemies.begin(), enemies.end(), i);
    if (it != enemies.end()) enemies.erase(it);
}

QGraphicsScene* player::createScene(bool h) {
    QGraphicsScene* s = new QGraphicsScene();
    if (Gender == male)
    s->addPixmap(QPixmap(":/resource/img/male.jpg"));
    else s->addPixmap(QPixmap(":/resource/img/female.jpg"));
    if (h) s->addPixmap(QPixmap(":/resource/img/unknown.png"));
    else s->addPixmap(QPixmap(image));
    QFont font;
    font.setPixelSize(14);
    font.setBold(true);
    s->addText("  " + Name, font)->setDefaultTextColor(QColor(245,245,245));
    return s;
}

void player::Die(bool h) {
    if (h) {
        block->scene()->clear();
        if (Gender == male) block->scene()->addPixmap(QPixmap(":/resource/img/male.jpg"));
        else block->scene()->addPixmap(QPixmap(":/resource/img/female.jpg"));
        block->scene()->addPixmap(QPixmap(image));
        QFont font;
        font.setPixelSize(14);
        font.setBold(true);
        block->scene()->addText("  " + Name, font)->setDefaultTextColor(QColor(245,245,245));
    }
    block->scene()->addPixmap(QPixmap(":/resource/img/death.png"));
    block->update();
    is_life = false;
}

bool player::comp(const player::_vote &a, const player::_vote &b) {
    return (a.priority > b.priority);
};

quint8 player::vote(quint16 time, quint8* votes, quint8 p_count) {
    srand(std::time(0));
    if (rand() % 20 > time) return 0;
    if (!is_life) return p_count + 1;
    if (enemies.empty()) return 0;
    std::sort(enemies.begin(), enemies.end(), comp);
    if (accident(Mental.Determination)) {
        return enemies[0].id;
    } else {
        auto it = std::max_element(votes, votes + p_count);
        if (*it != 0) {
            if ((std::distance(votes,it) + 1) == ID) {
                return enemies[0].id;
            }
            else {
                return std::distance(votes,it) + 1;
            }
        }
    }
    return 0;
}



