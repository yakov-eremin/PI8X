using System;
using SFML.Graphics;
using SFML.System;

namespace CosmicDefender
{
    /// <summary>
    /// Характеристики Объектов(Entity)
    /// </summary>
    public interface IEntityStats
    {

        /// <summary>
        /// Координаты
        /// </summary>
        public Vector2f Coords { get; set; }
        /// <summary>
        /// Скорость
        /// </summary>
        public Vector2f Speed { get; set; }
        /// <summary>
        /// Поворот
        /// </summary>
        public Vector2f Rotation { get; set; }
        /// <summary>
        ///  Максимальная скорость
        /// </summary>
        public float MaxSpeed { get; set; }
        /// <summary>
        /// Ускорение
        /// </summary>
        public float Acceleration { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Здоровье
        /// </summary>
        public float Health { get; set; }
        /// <summary>
        /// Активен ли
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Урон
        /// </summary>
        public float Dmg { get; set; }
        /// <summary>
        /// Нормализованный вектор направления
        /// </summary>
        public Vector2f Direction { get; }
    }
}