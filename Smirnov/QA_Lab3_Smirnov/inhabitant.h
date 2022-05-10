#ifndef INHABITANT_H
#define INHABITANT_H
#include "player.h"
/*!
    \brief Дочерний класс от класса Player

    Данный класс представляет собой модель персонажа игры "Мирный житель"
*/
class inhabitant : public player
{
public:
    inhabitant();
    /*!
     * Конструктор копирования
    \param[in] player Объект копирования
    */
    inhabitant(const player &player);
    /*!
    \param[in] id Порядковый номер игрока
    \param[in] name Имя игрока
    \param[in] gender Пол игрока
    \param[in] age Возраст игрока
    \param[in] elo Уровень красноречия
    \param[in] inc Уровень недоверчивости
    \param[in] pas Уровень агрессии
    \param[in] det Уровень решимости
    */
    inhabitant(quint8 id, QString name, QString gender, quint8 age, quint8 elo, quint8 inc, quint8 pas, quint8 det);
    /*!
    Определяет голос игрока в ночном голосовании
    \param[in] time Текущая секунда игры
    \param[in] votes Общая таблица голосов на текущей стадии
    \param[in] p_list Список игроков
    \return Номер игрока, за которого проголосовал текущий игрок
    */
    quint8 Action(quint16 time, std::vector<player*> p_list, quint8 *votes);
    /*!
    Действие игрока в момент обсуждения
    \param[in] time Текущая секунда игры
    \param[in] p_list Список игроков
    \return Номер игрока, о котором хочет высказаться текущий игрок
    */
    quint8 Discussion(quint16 time, std::vector<player*> p_list);
    /*!
    Действие игрока в случае когда ему высказывают своё мнение
    \param[in] a Игрок, который высказывается
    \param[in] b Номер игрока, о котором высказываются
    \param[in] is_good Высказывание положительное?
    */
    void Listen(player* a, quint8 b, bool is_good);
};

#endif // INHABITANT_H
