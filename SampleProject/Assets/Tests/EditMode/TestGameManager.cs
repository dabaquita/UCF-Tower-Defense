using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestGameManager
    {
        GameManager gameManager;
        GameObject obj = new GameObject();

        [SetUp]
        public void SetUp()
        {
            gameManager = obj.AddComponent<GameManager>();
        }

        [Test]
        public void TestSetMap()
        {
            string memoryMall = "Memory_Mall";

            gameManager.setMap(memoryMall);
            Assert.AreEqual(memoryMall, gameManager.getMap());
        }

        [Test]
        public void TestResetGame()
        {
            gameManager.resetGame();

      
            Assert.IsNull(gameManager.getMap());
        }

        [Test]
        public void TestStartSpawning()
        {
            gameManager.startSpawning();
            Assert.IsTrue(gameManager.spawnBool);
        }

        [Test]
        public void TestVictoryCondition()
        {
            gameManager.enemiesAlive = 0;
            gameManager.waveNumber = 10;
            Assert.IsTrue(gameManager.victory());
        }
    }
}
