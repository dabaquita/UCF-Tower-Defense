using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestPlayer
    {
        Player player;

        [SetUp]
        public void SetUp()
        {
            player = new Player();
        }

        [Test]
        public void TestChangeHealth()
        {
            float previousHealth = Player.getHealth();

            Player.setHealth(10);
            Assert.AreNotEqual(previousHealth, Player.getHealth());
        }

        [Test]
        public void TestChangeLevel()
        {
            float previousLevel = Player.getLevel();

            Player.setLevel(10);
            Assert.AreNotEqual(previousLevel, Player.getLevel());
        }

        [Test]
        public void TestChangeMoney()
        {
            float previousMoney = Player.getMoney();

            Player.setMoney(10);
            Assert.AreNotEqual(previousMoney, Player.getMoney());
        }
    }
}
