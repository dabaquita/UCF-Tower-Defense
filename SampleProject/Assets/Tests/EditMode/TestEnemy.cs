using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PathCreation;

namespace Tests
{
    [TestFixture]
    public class TestEnemy
    {
        GameObject enemy;
        Enemy en;

        [Test]
        public void TestEnemyDamagesPlayer()
        {
            GameObject enemy = GameObject.Find("hollander");
            en = enemy.GetComponent<Enemy>();
            Player.Health = 100;

            en.DamagePlayer();

            Assert.AreEqual(Player.Health, 90);
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
        public void TestDestroyEnemy()
        {
            var testEnemy = new GameObject();
            var enemy = testEnemy.AddComponent<Enemy>();

            enemy.DestroyEnemy();
            bool isNull = false;
            if (enemy == null)
            {
                isNull = true;
            }
            Assert.IsTrue(isNull);
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
