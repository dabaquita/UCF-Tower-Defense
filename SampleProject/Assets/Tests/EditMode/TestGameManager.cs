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

        [SetUp]
        public void SetUp()
        {
            gameManager = new GameManager();
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
    }
}
