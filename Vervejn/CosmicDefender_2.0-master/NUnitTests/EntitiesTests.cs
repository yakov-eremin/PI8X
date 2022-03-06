using System;
using System.Collections.Generic;
using System.Text;
using CosmicDefender;
using CosmicDefender.Controllers;
using CosmicDefender.FactoryMethod;
using NUnit.Framework;

namespace NUnitTests
{
    class EntitiesTests
    {
        [Test]
        public void Test_SpawnAsteroid()
        {
            ObjectManager.GetInstance().Clear();
            GameManager gameManager = GameManager.GetInstance();
            AbstractFactory af = new Level1Factory();
            SpawnerEntities spawner = new SpawnerEntities(gameManager);
            spawner.SpawnImplementation = new SpawnAstreroid();
            spawner.Spawn(af);
            int countObjects = ObjectManager.GetInstance().GetEntities().Count;
            Assert.AreEqual(countObjects, 1);
        }
        [Test]
        public void Test_SpawnEnemy()
        {
            ObjectManager.GetInstance().Clear();
            GameManager gameManager = GameManager.GetInstance();
            AbstractFactory af = new Level1Factory();
            SpawnerEntities spawner = new SpawnerEntities(gameManager);
            spawner.SpawnImplementation = new SpawnEnemy();
            spawner.Spawn(af);
            int countObjects = ObjectManager.GetInstance().GetEntities().Count;
            Assert.AreEqual(countObjects, 1);
        }
        [Test]
        public void Test_SpawnBoss()
        {
            ObjectManager.GetInstance().Clear();
            GameManager gameManager = GameManager.GetInstance();
            AbstractFactory af = new Level1Factory();
            SpawnerEntities spawner = new SpawnerEntities(gameManager);
            spawner.SpawnImplementation = new SpawnBoss();
            spawner.Spawn(af);
            int countObjects = ObjectManager.GetInstance().GetEntities().Count;
            Assert.AreEqual(countObjects, 1);
        }
        [Test]
        public void Test_CollideObjects()
        {
            GameManager gameManager = GameManager.GetInstance();
            AbstractFactory af = new Level1Factory();
            SpawnerEntities spawner = new SpawnerEntities(gameManager);

            spawner.SpawnImplementation = new SpawnEnemy();
            spawner.Spawn(af);
            spawner.SpawnImplementation = new SpawnAstreroid();
            spawner.Spawn(af);

            var list = ObjectManager.GetInstance().GetEntities();
            if (list.Count != 2) Assert.Pass();
            var object1 = list[0];
            var object2 = list[1];

            object1.Coords = object2.Coords;

            Assert.True(Collider.IsCollide(object1._sprite, object2._sprite));
        }




    }
}
