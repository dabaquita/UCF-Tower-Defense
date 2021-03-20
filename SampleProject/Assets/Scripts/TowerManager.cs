using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class TowerManager : Loader<TowerManager>
{
    TowerBtn towerBtnPressed;
    SpriteRenderer spriteRenderer;
    GameObject newTower;
    GameObject placeableArea;
    GameObject closeButton;
    GameObject towerSelectionMenu;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        placeableArea = GameObject.Find("Placeable Areas");
        closeButton = GameObject.Find("CloseButton");
        towerSelectionMenu = GameObject.Find("TowerSelection");
    }


    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Selection Menu: " + towerSelectionMenu);
        if(towerSelectionMenu.activeSelf)
        {
            placeableArea.SetActive(false);
        }
        else 
        {
            placeableArea.SetActive(true);
        }

        if(spriteRenderer.enabled)
        {
            FollowMouse();
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Use Raycasting to check if you can put the tower down or not
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

            PlaceTower(hit);
        }
        
        // Use the escape key to disable playing an active tower
        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Debug.Log("Escaped pressed");
            DisableDrag();
            towerBtnPressed = null;
        }
    }

    // Add a Unit Test
    public void PlaceTower(RaycastHit2D hit)
    {
        if(towerBtnPressed != null && hit.collider != null && hit.collider.tag == "TowerSide")
        {
            
            if (towerBtnPressed.TowerCost > Player.getMoney())
            {
                print("Player does not have enough money to buy");
                return;
            }

            // Check if the spot on the map already has a tower on it
            hit.collider.tag = "TowerSideFull";

            // Check if the mouse click was done on an object of type GameObject and a tower was selected
            // Creates a new tower object and position it at the mouse location
            newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            

            // Modify player's bank
            Player.setMoney(Player.getMoney() - towerBtnPressed.TowerCost);
        }
    }

    public void SelectTower(TowerBtn towerSelected)
    {
        towerBtnPressed = towerSelected;
        EnableDrag(towerBtnPressed.DragSprite);
        // Disable menu
        
        Button closeMenu = closeButton.GetComponent<Button>(); 
        closeMenu.onClick.Invoke();
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
