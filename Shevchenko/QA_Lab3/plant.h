#ifndef PLANT_H
#define PLANT_H

#include<ctime>
#include <QString>
#include <QGraphicsPixmapItem>
#include <QObject>

/*!
    \brief Базовый класс для растений на карте

    Представляет собой модель растения, включает в себя логику отрисовки
*/

class Plant : public QObject, public QGraphicsPixmapItem
{
    Q_OBJECT
public:
    /// Идентификатор типа растения
    int type;   
    /// Время создания растения        
    time_t birthTime;
    /// Время жизни растения
    time_t lifespan;
    /// Уровень роста растения    
    int growthLevel;
    /// Максимальное здоровье растения
    int maxHealth;      
    /// Текущее здоровье растения
    int currentHealth;
    /// Название растения
    QString name;
    /// Уровень агрессивности растения
    int agressivness;
    /// Требуемый уровень освещённости клетки для роста 
    int reqLightLevel;
    /// Требуемый уровень влажности клетки для роста
    int reqHumLevel;    
    /*!
        \brief Метод получения требуемого плодородия почвы для более высокого уровня растения
        \param[in] additionalGrowthLevel Повышение уровня для рассчёта
        \return Требуемое плодородие почвы для растения
    */
    virtual int getFertilityConsumprion(int additionalGrowthLevel) = 0;
    /*!
        \brief Метод получения требуемого плодородия почвы для текущего уровня растения
        \return Требуемое плодородие почвы для растения
    */
    virtual int getFertilityConsumption() = 0;
    /*!
        \brief Метод увеличения уровня роста растения
        \param[in] additionalGrowthLevel Количество уровней, которое будет добавлено
        \return Изменённое значение уровня растения
    */
    virtual int updateGrowthLevel(int additionalGrowthLevel) = 0;
    /*!
        \brief Метод получения времени жизни растения
        \return Строка формата ЧЧ:ММ:СС, отражающая сколько существует растение
    */
    virtual QString getLifespan() = 0;
    /*!
    * Конструктор
    */
    virtual ~Plant() {};
};

#endif // PLANT_H
