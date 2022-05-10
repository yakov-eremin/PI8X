#include "mafia.h"

mafia::mafia()
{

}

mafia::mafia(const player &player)
{
    Name = player.Name;
    Gender = player.Gender;
    Age = player.Age;
    Mental = player.Mental;
    image = ":/resource/img/mafia.png";
}

mafia::mafia(quint8 id, QString name, QString gender, quint8 age, quint8 elo, quint8 inc, quint8 pas, quint8 det) : player (id,name,gender,age,elo,inc,(pas > 6)? 9 : pas + 2,det) {
    image = ":/resource/img/mafia.png";
}

quint8 mafia::Action(quint16 time, std::vector<player*> p_list, quint8 *votes) {
    if (!is_life) return p_list.size() + 1;
    srand(std::time(0));
    if (time < rand() % 20) return 0;
    std::vector<quint8> possibly;
    for (unsigned int i = 0; i < p_list.size(); i++) {
        if (p_list[i]->is_life) {
            bool f = true;
            for (unsigned int j = 0; j < Allies.size(); j++) {
                if (Allies[j] == (i + 1)) {
                    f = false;
                    break;
                }
            }
            if (f) possibly.push_back(i+1);
        }
    }
    quint8 result = 0;
    if (enemies.empty()) {
        if (accident(Mental.Determination)) {
            result = possibly[rand() % possibly.size()];
        } else {
            auto it = std::max_element(votes, votes + p_list.size());
            result = *std::max_element(votes, votes + p_list.size());
            if (*it == 0) {
               result = possibly[rand() % possibly.size()];
            } else {
               result = std::distance( votes,it) + 1;
            }
        }
    }
    else {
        if (accident(Mental.Determination)) {
            std::sort(enemies.begin(), enemies.end(), comp);
            result = enemies[0].id;
        } else {
            auto it = std::max_element(votes, votes + p_list.size());
            result = *std::max_element(votes, votes + p_list.size());
            if (*it == 0) {
               result = possibly[rand() % possibly.size()];
            } else {
               result = std::distance( votes,it) + 1;
            }
        }
    }
    return result;
}

quint8 mafia::Discussion(quint16 time, std::vector<player*> p_list) {
    if (!is_life) return p_list.size() + 1;
    srand(std::time(0));
    if (time < rand() % 39) return 0;
    std::vector<quint8> possibly;
    for (unsigned int i = 0; i < p_list.size(); i++) {
        if (p_list[i]->is_life) {
            bool f = true;
            for (unsigned int j = 0; j < Allies.size(); j++) {
                if (Allies[j] == (i + 1)) {
                    f = false;
                    break;
                }
            }
            if (f) possibly.push_back(i+1);
        }
    }
    bool good = false;
    quint8 result = 0;
    if (enemies.empty()) {
        result = possibly[rand() % possibly.size()];
        for (unsigned int i = 0; i < Allies.size(); i++) {
            if (Allies[i] == result) {
                good = true;
                break;
            }
        }
        for (unsigned int i = 0; i < p_list.size(); i++) {
            p_list[i]->Listen(this, result, good);
        }
    }
    else {
        std::sort(enemies.begin(), enemies.end(), comp);
        if (accident(Mental.Determination)) {
            result = enemies[0].id;
            good = false;
        } else {
            result = Allies[rand() % Allies.size()];
            good = true;
        }
        for (unsigned int i = 0; i < p_list.size(); i++) {
            p_list[i]->Listen(this, result, good);
        }
    }
    return result;
}

void mafia::Listen(player* a, quint8 b, bool is_good) {
    if (!is_life) return;
    if (b == ID) {
        addEnemy(a->ID, 2);
        return;
    }
    for (unsigned int i = 0; i < Allies.size(); i++) {
        if (b == Allies[i]) {
            if (is_good) {
                for (unsigned int i = 0; i < Allies.size(); i++) {
                    if (a->ID == Allies[i]) {
                        return;
                    }
                }
                addEnemy(a->ID, -1);
            }
            else addEnemy(a->ID, 1);
            return;
        }
    }
    addEnemy(b, 1);
}

void mafia::addAllies(std::vector<quint8> *a) {
    Allies = *a;
}
