using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private Tile[] tiles;

    private void Awake()
    {
        tiles = GameObject.FindObjectsOfType<Tile>();
    }

    public void FlipTheColors()
    {
        foreach (Tile tile in tiles)
        {
            Debug.Log(tile.spr.color.ToString());

            switch (tile.spr.color.ToString())
            {
                case "RGBA(1.000, 1.000, 1.000, 1.000)":
                    tile.spr.color = Color.black;
                    break;
                case "RGBA(0.000, 0.000, 0.000, 1.000)":
                    tile.spr.color = Color.white;
                    break;
            }
        }
    }
}
