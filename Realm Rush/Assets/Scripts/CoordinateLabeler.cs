using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways] // makes the script run in edit and play mode
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color default_color = Color.white;
    [SerializeField] Color blocked_color = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();

        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
           DisplayCoordinates();
           UpdateObjectName();
           label.enabled = true;
        }

        SetLabelColor(); // changes coordinate label color
        ToggleLabels(); // for debugging purposes
    }

    void DisplayCoordinates()
    {
        float divider = UnityEditor.EditorSnapSettings.move.x; // value is 10

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/ divider);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/ divider);

        label.text = $"{coordinates.x},{coordinates.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = $"Tile{coordinates.ToString()}";
    }

    void SetLabelColor()
    {
        if (waypoint.IsPlacable)
        {
            label.color = default_color;
        }
        else
        {
            label.color = blocked_color;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
