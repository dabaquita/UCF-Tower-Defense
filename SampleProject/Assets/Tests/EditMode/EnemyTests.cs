using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemyTests
    {
        //Each test name corresponds to the method name of the class to be tested.

        [Test]
        public void DamagePlayer()
        {
            var gameObject = new GameObject();
            var en = gameObject.AddComponent<Enemy>();

            Player.Health = 100;

            en.DamagePlayer();

            Assert.AreEqual(Player.Health, 90);
        }


        [Test]
        public void IsDead()
        {
            var gameObject = new GameObject();
            var en = gameObject.AddComponent<Enemy>();

            en.Health = 10;
            Assert.AreEqual(en.IsDead(), false);

            en.Health = 0;
            Assert.AreEqual(en.IsDead(), true);
        }

        //Complications using MonoBehavior
        // [Test]
        // private void DestroyEnemy()
        // {
        //     var gameObject = new GameObject();
        //     var en = gameObject.AddComponent<Enemy>();


        //     // Assert.
        // }

        // // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // // `yield return null;` to skip a frame.
        // [UnityTest]
        // public IEnumerator EnemyTestWithEnumeratorPasses()
        // {
        //     // Use the Assert class to test conditions.
        //     // Use yield to skip a frame.
        //     yield return null;
        // }
    }
}
