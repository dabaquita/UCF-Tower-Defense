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
        public PathCreator pathCreator;

        [SetUp]
        public void SetUp()
        {
            en = obj.AddComponent<Enemy>();
            pathCreator = GameObject.Find("EnemyPath").GetComponent<PathCreator>();
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

        [Test]
        public void TestHasReachedTheEndOfTheMap()
        {
            // arbitrary number for "has traversed the entire map"
            en.transform.position = pathCreator.path.GetPointAtDistance(10000000000, EndOfPathInstruction.Stop);
            // stop instruction locks position it after it completes the whole thing
            Assert.AreEqual(en.transform.position, pathCreator.path.GetPointAtTime(1.0f, EndOfPathInstruction.Stop));
        }
    }
}
