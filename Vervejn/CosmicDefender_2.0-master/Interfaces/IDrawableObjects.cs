using SFML.Graphics;

namespace CosmicDefender
{
    public interface IDrawableObjects
    {
        /// <summary>
        /// Спрайт
        /// </summary>
        public Sprite _sprite { get; set; }
        /// <summary>
        /// Обновление объекта
        /// </summary>
        /// <param name="time">Время(DeltaTime)</param>
        public void Update(float time);
        /// <summary>
        /// Прорисовка объекта
        /// </summary>
        public void Draw();
    }
}