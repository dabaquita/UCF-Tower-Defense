using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField] GameObject towerObject;
    [SerializeField] Sprite dragSprite;
    [SerializeField] int cost;

    public GameObject TowerObject 
    {
        get 
        {
            return towerObject;
        }
    }

    public Sprite DragSprite 
    {
        get 
        {
            return dragSprite;
        }
    }

    public int TowerCost
    {
        get
        {
            return cost;
        }
    }
}
