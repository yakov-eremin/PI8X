/**
 * \file
 * \authors Николай
 * \version 1.0
 * \date 13.03.2022
 */

#include <iostream>
#include <conio.h>
using namespace std;

/**
 * Класс Car описывает упрощенную
 * модель автомобиля
 */
class Car{
protected:
    /// текущая скорость автомобиля
    int speed = 0; 
    /// максимальная скорость автомобиля
    int max_speed = 0; 
    /// количество дверей автомобиля
    int number_of_doors = 1; 
    /// проверка пределов изменения скорости
    void normalize_speed(){ 
        if(speed < 0)
            speed = 0;
        else if(speed > max_speed)
            speed = max_speed;
    }
public:
    /**
     * Конструктор с единственным параметром
     * @param max_speed
     * устанавливает максимальную скорость автомобиля
     */
    explicit Car(int max_speed)
    {
        this->max_speed = max_speed;
    }

    /**
     * \brief Звуковой сигнал.
     * Метод, вызывающий звуковой сигнал автомобиля
     */
    void beep()
    {
        cout << "Beeep" << endl;
    }

    /**
     * \brief Максимальная скорость.
     * Получение максимальной скорости автомобиля
     * @return максимальная скорость
     */
    int get_max_speed() const
    {
        return  max_speed;
    }

    /**
     * \brief Текущая скорость.
     * Получение текущей скорости автомобиля
     * @return текущая скорость
     */
    int get_speed()
    {
        return speed;
    }

    /**
     * \brief Количество дверей
     * Получение количества дверей автомобиля
     * @return количество дверей
     */
    int get_number_of_doors() const
    {
        return  number_of_doors;
    }

    /**
     * \brief Ускорение.
     * Метод, вызывающий увеливение скорости движения автомобиля
     */
    virtual void push_gas_pedal()
    {
        speed++;
        normalize_speed();
    }

    /**
     * \brief Торможение.
     * Метод, снижающий скорость движения автомобиля
     */
    virtual void push_break_pedal()
    {
        speed--;
        normalize_speed();
    }
};

/// Автомобиль Volvo
/**
 * Описание класса автомобиля марки Volvo
 * ![Фото автомобиля](volvo.jpg)
 */
class Volvo: public Car{
public:
    /**
     * Конструктор с одним параметром, устанавливает количество дверей,
     * отличное от базового класса.
     * @param max_speed
     */
    explicit Volvo (int max_speed) : Car(max_speed){
        this->number_of_doors = 4;
    }

    /// Ускорение Volvo
    /**
     * Переопределение ускорение для Volvo
     * Volvo разгоняется на 3 километра в час
     */
    void push_gas_pedal() override
    {
        speed+=3;
        normalize_speed();
    }

    /// Торможение Volvo
    /**
     * Переопределение торможения для Volvo
     * Volvo затормаживается на 5 километра в час
     */
    void push_break_pedal() override
    {
        speed -= 5;
        normalize_speed();
    }
};


/*!
    \brief Теорема Пифагора 
    \f[
    x^n + y^n = z^n 
    \f]
 */ 
int main() {

    // создание сущности автомобиля класса Volvo
    Car* my_car = new Volvo(200);

    // подача автомобилем сигнала
    my_car->beep();
    char command; // управляющий символ
    // для завершения программы необходимо нажать 'q'
    while( (command = getch()) != 'q'){
        switch (command) {
            case 'g': // нажатие педали газа
                my_car->push_gas_pedal();
                break;
            case 'b': // нажатие педали тормоза
                my_car->push_break_pedal();
                break;
            case '\r': // пропуск введенного символа возврата каретки
                continue;
            default: // вызов сигнала автомобиля
                my_car->beep();
                break;
        }
        cout << "My speed is " << my_car->get_speed() << "kmph." << endl;
    }
    return 0;
}

