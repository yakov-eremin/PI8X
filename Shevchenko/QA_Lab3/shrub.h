#ifndef SHRUB_H
#define SHRUB_H

#include "plant.h"

/*!
    \brief Класс кустика
*/

class Shrub : public Plant
{
    int height;
public:
    /// Конструктор класса по-умолчанию
    Shrub();
    /*!
    \brief Конструктор класса Srub
    \param[in] newLifespan Время жизни растения
    \param[in] newGrowthLevel Текущий уровень роста растения
    \param[in] newCurrentHealth Текущий уровень здоровья растения
    */
    Shrub(time_t newLifespan, int newGrowthLevel, int newCurrentHealth);
    /// Деструктор класса
    ~Shrub();
    /*!
        \brief Метод увеличения уровня роста растения
        \param[in] additionalGrowthLevel Количество уровней, которое будет добавлено
        \return Изменённое значение уровня растения
    */
    int getFertilityConsumprion(int additionalGrowthLevel);
    /*!
        \brief Метод получения требуемого плодородия почвы для текущего уровня растения
        \return Требуемое плодородие почвы для растения
    */
    int getFertilityConsumption();
    /*!
        \brief Метод увеличения уровня роста растения
        \param[in] additionalGrowthLevel Количество уровней, которое будет добавлено
        \return Изменённое значение уровня растения
    */
    int updateGrowthLevel(int additionalGrowthLevel);
    /*!
        \brief Метод получения времени жизни растения
        \return Строка формата ЧЧ:ММ:СС, отражающая сколько существует растение
    */
    QString getLifespan();
};

#endif // SHRUB_H
