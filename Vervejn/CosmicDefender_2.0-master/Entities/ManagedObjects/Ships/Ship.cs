using System;
using System.Runtime.InteropServices;
using CosmicDefender.Builders.Interfaces;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CosmicDefender
{
    /// <summary>
    /// Класс Корабля
    /// Корабль - это абстрактный объект который описывает корабль пользователя/ИИ. \n
    /// Этот объект будет относиться к типу Entity и будет иметь здоровье, урон, скорость и др.характеристики. \n
    /// Его основная роль – это предоставить элемент, с помощью которого можно взаимодействовать с другими элементами игры. \n
    /// </summary>
    public abstract class Ship : Entity
    {
        /// <summary>
        /// Таймер для скорострельности
        /// </summary>
        public Clock Timer = new Clock();
        /// <summary>
        /// Скорострельность
        /// </summary>
        public float _firingRate { get; } //5f
        /// <summary>
        /// Пушка
        /// </summary>
        public Gun Weapon { get; set; }
        /// <summary>
        /// Конструктор Ship
        /// </summary>
        /// <param name="sprite">Спрайт</param>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="acceleration">Ускорение</param>
        /// <param name="name">Название</param>
        /// <param name="health">Количество здоровья</param>
        /// <param name="weapon">Пушка</param>
        /// <param name="firingRate">Скорострельность</param>
        protected Ship(Sprite sprite, float maxSpeed, float acceleration, string name, float health, Gun weapon,  float firingRate) 
            : base(sprite, maxSpeed, acceleration, name, health)
        {
            Weapon = weapon;
            weapon.ship = this;
            _firingRate = firingRate;
        }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Ship()
        { }
        public override void Update(float time)
        {
            UpdateRotation();
            Weapon.Update();
            base.Update(time);
        }
        /// <summary>
        /// Проверить, позволяет ли таймер скорострельности выстрелить?
        /// </summary>
        /// <returns>True - можно выстрелить; False - нельзя выстрелить</returns>
        public bool CheckFireRating()
        {
            if (Timer.ElapsedTime.AsSeconds() >= _firingRate) return true;
            return false;

        }
        /// <summary>
        /// Обновить направление корабля
        /// </summary>
        public abstract void UpdateRotation();
    }
}