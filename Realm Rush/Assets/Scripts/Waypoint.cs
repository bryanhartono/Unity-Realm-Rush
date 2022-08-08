using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower_prefab;
    [SerializeField] bool is_placeable;

    public bool IsPlacable { get { return is_placeable; } }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && is_placeable)
        {
            bool is_placed = tower_prefab.CreateTower(tower_prefab, transform.position);
            is_placeable = !is_placed;  
        }  
    }
}
