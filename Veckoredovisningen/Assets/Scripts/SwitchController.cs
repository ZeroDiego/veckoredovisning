using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private Door door;

    private void Awake()
    {
        door = GetComponentInChildren<Door>();
    }

    public void FlipTheColor()
    {
        door.spr.color = door.nextColor;

        switch (door.spr.color.ToString())
        {
            case "RGBA(1.000, 1.000, 1.000, 1.000)":
                door.gameObject.layer = LayerMask.NameToLayer("White");
                break;
            case "RGBA(0.000, 0.000, 0.000, 1.000)":
                door.gameObject.layer = LayerMask.NameToLayer("Black");
                break;
        }
    }
}
