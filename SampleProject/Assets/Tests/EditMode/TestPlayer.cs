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
        GameObject obj = new GameObject();
        System.Random rand; // random number used to ensure two results do not match in tests run back-to-back

        [SetUp]
        public void SetUp()
        {
           player = obj.AddComponent<Player>();
           rand = new System.Random();
        }

        [Test]
        public void TestChangeHealth()
        {
            float previousHealth = Player.getHealth();

            Player.setHealth(rand.Next(1, 10000));
            Assert.AreNotEqual(previousHealth, Player.getHealth());
        }

        [Test]
        public void TestChangeLevel()
        {
            float previousLevel = Player.getLevel();

            Player.setLevel(rand.Next(1, 10000));
            Assert.AreNotEqual(previousLevel, Player.getLevel());
        }

        [Test]
        public void TestChangeMoney()
        {
            float previousMoney = Player.getMoney();

            Player.setMoney(rand.Next(1, 10000));
            Assert.AreNotEqual(previousMoney, Player.getMoney());
        }
    }
}
