using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PathCreation;

namespace Tests
{
    public class TestEnemy
    {
        Enemy en;
        GameObject obj = new GameObject();

        [SetUp]
        public void SetUp()
        {
            en = obj.AddComponent<Enemy>();
        }

        [Test]
        public void TestEnemyDamagesPlayer()
        {
            Player.setHealth(100);

            en.DamagePlayer();

            Assert.AreEqual(Player.getHealth(), 90);
        }

        [Test]
        public void TestEnemyIsDead()
        {
            var testEnemy = new GameObject();
            var enemy = testEnemy.AddComponent<Enemy>();
            enemy.SetEnemyHealth(-10);

            Assert.IsTrue(enemy.IsDead());
        }

        [Test]
        public void TestGetEnemyHealth()
        {
            var testEnemy = new GameObject();
            var enemy = testEnemy.AddComponent<Enemy>();

            int foo = enemy.GetEnemyHealth();
            Assert.AreEqual(0, foo);
        }

        [Test]
        public void TestSetEnemyHealth()
        {
            var testEnemy = new GameObject();
            var enemy = testEnemy.AddComponent<Enemy>();

            enemy.SetEnemyHealth(100);
            Assert.AreEqual(100, enemy.GetEnemyHealth());
        }
    }
}
