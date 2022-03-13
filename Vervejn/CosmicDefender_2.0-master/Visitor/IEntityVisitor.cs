namespace CosmicDefender.Visitor
{
    /// <summary>
    /// Интерфейс, который описывает поведение объектов при соприкосновении с другими
    /// </summary>
    public interface IEntityVisitor
    {
        /// <summary>
        /// Метод взаимодействия с объектом Bullet
        /// </summary>
        /// <param name="bullet">Пуля(Bullet)</param>
        public void Visit(Bullet bullet);

        /// <summary>
        /// Метод взаимодействия с объектом EnemyShip
        /// </summary>
        /// <param name="enemyShip">Вражеский Корабль(EnemyShip)</param>
        public void Visit(EnemyShip enemyShip);

        /// <summary>
        /// Метод взаимодействия с объектом PlayerShip
        /// </summary>
        /// <param name="playerShip">Корабль Игрока(PlayerShip)</param>
        public void Visit(PlayerShip playerShip);

        /// <summary>
        /// Метод взаимодействия с объектом Asteroid
        /// </summary>
        /// <param name="asteroid">Астероид(Asteroid)</param>
        public void Visit(Asteroid asteroid);

        /// <summary>
        /// Метод взаимодействия с объектом Entity
        /// </summary>
        /// <param name="entity">Объект(Entity)</param>
        public void Visit(Entity entity);
    }
}