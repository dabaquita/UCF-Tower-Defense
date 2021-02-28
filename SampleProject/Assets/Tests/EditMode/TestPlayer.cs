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
            float previousHealth = player.getHealth();

            player.setHealth(10);
            Assert.AreNotEqual(previousHealth, player.getHealth());
        }

        [Test]
        public void TestChangeLevel()
        {
            float previousLevel = player.getLevel();

            player.setLevel(10);
            Assert.AreNotEqual(previousLevel, player.getLevel());
        }

        [Test]
        public void TestChangeMoney()
        {
            float previousMoney = player.getMoney();

            player.setMoney(10);
            Assert.AreNotEqual(previousMoney, player.getMoney());
        }
    }
}
