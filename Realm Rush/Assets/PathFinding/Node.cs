using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node // THIS IS A PURE C# CLASS!
{
    public Vector2Int coordinates;
    public bool is_walkable;
    public bool is_explored;
    public bool is_path;
    public Node connected_to;

    public Node(Vector2Int coordinates, bool is_walkable) // CONSTRUCTOR
    {
        this.coordinates = coordinates;
        this.is_walkable = is_walkable;
    }
}
