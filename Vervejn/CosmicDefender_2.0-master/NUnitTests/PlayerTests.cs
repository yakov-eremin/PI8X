using System;
using System.Linq;
using CosmicDefender;
using CosmicDefender.Controllers;
using CosmicDefender.State;
using NUnit.Framework;
using SFML.Graphics;

namespace NUnitTests
{
    public class Tests
    {
        [Test]
        public void Test_PlayerShot()
        {
            ObjectManager.GetInstance().Clear();
            GameManager gameManager = GameManager.GetInstance();

            PlayerShip playerShip = new PlayerShip(Content.getInstance().GetShip1(), 2f, 0.1f, "EnemyShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(), 2, 1, 10),
                0.1f);

            playerShip.Weapon.Shot();

            int countObjects = ObjectManager.GetInstance().GetEntities().Count;

            Assert.AreEqual(countObjects, 1);
        }

        [Test]
        public void Test_PlayerSpawn()
        {
            ObjectManager.GetInstance().Clear();
            GameManager gameManager = GameManager.GetInstance();

            PlayerShip playerShip = new PlayerShip(Content.getInstance().GetShip1(), 2f, 0.1f, "EnemyShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(), 2, 1, 10),
                0.1f);
            
            ObjectManager.GetInstance().AddEntity(playerShip);

            int countObjects = ObjectManager.GetInstance().GetEntities().Count;

            Assert.AreEqual(countObjects, 1);
        }

        [Test]
        public void Test_PlayerSwitchSimpleToFastState()
        {
            GameManager gameManager = GameManager.GetInstance();

            PlayerShip playerShip = new PlayerShip(Content.getInstance().GetShip1(), 2f, 0.1f, "EnemyShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(), 2, 1, 10),
                0.1f);

            var SpeedBefore = playerShip.MaxSpeed;
            playerShip._stateManager.SwitchState(new PlayerFastState());
            var SpeedAfter = playerShip.MaxSpeed;


            Assert.AreEqual(SpeedBefore * 2, SpeedAfter);
        }

        [Test]
        public void Test_PlayerSwitchFastToSimpleState()
        {
            GameManager gameManager = GameManager.GetInstance();

            PlayerShip playerShip = new PlayerShip(Content.getInstance().GetShip1(), 2f, 0.1f, "EnemyShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(), 2, 1, 10),
                0.1f);
            playerShip._stateManager.SwitchState(new PlayerFastState());

            var SpeedBefore = playerShip.MaxSpeed;
            playerShip._stateManager.SwitchState(new PlayerSimpleState());
            var SpeedAfter = playerShip.MaxSpeed;


            Assert.AreEqual(SpeedBefore / 2, SpeedAfter);
        }

        [Test]
        public void Test_PlayerCheckShotFromClearPool()
        {
            try
            {
                GameManager gameManager = GameManager.GetInstance();

                PlayerShip playerShip = new PlayerShip(Content.getInstance().GetShip1(), 2f, 0.1f, "EnemyShip", 100,
                    new Gun(new SingleShot(), Content.getInstance().GetBullet(), 2, 1, 10),
                    0.1f);
                playerShip.Weapon.BulletsPool._autoExpand = false;
                playerShip.Weapon.Shot();
                playerShip.Weapon.Shot();
                playerShip.Weapon.Shot();
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message == "There is no free elements in pool of type CosmicDefender.Bullet");
            }
        }

    }
}