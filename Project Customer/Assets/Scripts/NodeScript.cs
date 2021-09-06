using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public bool available = true;

    public enum TileType{
        Ocean,
        Desert,
        Plains,
        Hills,
        Forest,
        City
    };

    public TileType type;

    public int id;
}
