using SFML.Graphics;

namespace CosmicDefender
{
    /// <summary>
    /// Абстрактный класс декоратора кораблей
    /// </summary>
    public abstract class ShipDecorator : Ship
    {
        /// <summary>
        /// Корабль, который будет декорирован
        /// </summary>
        protected Ship _ship;
        /// <summary>
        /// Конструктор декорируемого корабля
        /// </summary>
        /// <param name="sprite">Спрайт</param>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="acceleration">Ускорение</param>
        /// <param name="name">Название</param>
        /// <param name="health">Здоровье</param>
        /// <param name="weapon">Пушка</param>
        /// <param name="firingRate">Скорострельность</param>
        protected ShipDecorator(Sprite sprite, float maxSpeed, float acceleration, string name, float health, Gun weapon, float firingRate) :
            base(sprite, maxSpeed, acceleration, name, health, weapon, firingRate)
        {
            
        }
    }
}