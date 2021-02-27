using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TowerManager : Loader<TowerManager>
{
    TowerBtn towerBtnPressed;
    SpriteRenderer spriteRenderer;
    GameObject newTower;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if(spriteRenderer.enabled)
        {
            FollowMouse();
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Use Raycasting to check if you can put the tower down or not
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

            if(EventSystem.current.IsPointerOverGameObject())
            {
                PlaceTower(hit);
            }
        }
    }

    // Add a Unit Test
    public void PlaceTower(RaycastHit2D hit)
    {
        if(towerBtnPressed != null && hit.collider != null && hit.collider.tag == "TowerSide")
        {
            // Check if the spot on the map already has a tower on it
            hit.collider.tag = "TowerSideFull";

            // Check if the mouse click was done on an object of type GameObject and a tower was selected
            // Creates a new tower object and position it at the mouse location
            newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            DisableDrag();
        }
    }

    public void SelectTower(TowerBtn towerSelected)
    {
        towerBtnPressed = towerSelected;
        EnableDrag(towerBtnPressed.DragSprite);
        Debug.Log("Pressed" + towerSelected.gameObject);
    }

    public void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void EnableDrag(Sprite sprite)
    {
        
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }

        public void DisableDrag()
    {
        spriteRenderer.enabled = false;
    }

    /* Next methods are for Unit Test purposes*/
    public TowerBtn GetTower()
    {
        return towerBtnPressed;
    }

    public GameObject GetTowerPosition()
    {
        return newTower;
    }

    public void SetTowerSprite(TowerBtn button)
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public SpriteRenderer GetTowerSpriteRenderer()
    {
        return spriteRenderer;
    }
}
