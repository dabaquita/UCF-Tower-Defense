using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class TowerManagerTest
    {
        GameObject gameTowerObject = GameObject.Find("KnightroButton");
        TowerBtn towerButton;
        GameObject gameManagerObject = GameObject.Find("TowerManager");
        TowerManager towerManager;
        Vector2 mousePoint;
        GameObject newTower;
            
        [SetUp]
        public void SetUp() 
        {
            towerButton = gameTowerObject.GetComponent<TowerBtn>();
            towerManager = gameManagerObject.GetComponent<TowerManager>();
            towerManager.SetTowerSprite(towerButton);
        }
        
        [Test]
        public void SelectCorrectTower()
        {

            towerManager.SelectTower(towerButton);
            Assert.AreEqual(towerButton, towerManager.GetTower(), "Check Correct Tower is Selected");
        }

        [Test]
        public void PlaceTowerOnValidSpot()
        {
            towerManager.SelectTower(towerButton);

            mousePoint = GameObject.Find("GreenGrass (6)").transform.position;
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
            towerManager.PlaceTower(hit);
       
            newTower = towerManager.GetTowerPosition();
            Assert.AreEqual(hit.transform.position, newTower.transform.position);
            
        }

        [Test]
        public void PlaceTowerOnUnMarkedSpotDisabled()
        {
            towerManager.SelectTower(towerButton);

            mousePoint = new Vector2((float) 0.6148433, (float) -34.10126);

            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
            towerManager.PlaceTower(hit);
            GameObject newTower = towerManager.GetTowerPosition();

            if(hit.collider == null)
            {
                Assert.IsNull(hit.collider);
            }
            else 
            {
                Assert.AreNotEqual(hit.transform.position, newTower.transform.position);
            }

        }

        [Test]
        public void PlaceTowerOnSameSpotDisabled()
        {

            towerManager.SelectTower(towerButton);

            Vector2 mousePoint = GameObject.Find("GreenGrass (10)").transform.position;

            // Use Raycasting to check if you can put the tower down or not
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
            hit.collider.tag = "TowerSideFull";
            towerManager.PlaceTower(hit);
            GameObject newTower = towerManager.GetTowerPosition();

            Assert.IsNull(newTower);
        }

        [Test]
        public void DragEnabledOnMovingTower()
        {
            towerManager.EnableDrag(towerButton.DragSprite);
            SpriteRenderer spriteRenderer = towerManager.GetTowerSpriteRenderer();
            Assert.IsTrue(spriteRenderer.enabled);
        }

        [Test]
        public void DragDisabledOnPlacedTower()
        {
            towerManager.DisableDrag();
            SpriteRenderer spriteRenderer = towerManager.GetTowerSpriteRenderer();
            Assert.IsFalse(spriteRenderer.enabled);
        }
    }
}
