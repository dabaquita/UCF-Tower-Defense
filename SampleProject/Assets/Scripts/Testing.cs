using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    GridMap grid;
    int value;
    private void Start() {
        grid = new GridMap(82, 42, 1f, new Vector3(-41,-21));
    }
 
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            grid.SetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
        }
 
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log(grid.GetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }
}
