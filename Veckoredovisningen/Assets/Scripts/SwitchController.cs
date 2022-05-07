using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private Door[] doors;

    private void Awake()
    {
        doors = FindObjectsOfType<Door>();
    }

    public void FlipTheColors()
    {
        foreach (Door door in doors)
        {
            switch (door.nextColor.ToString())
            {
                case "RGBA(1.000, 1.000, 1.000, 1.000)":
                    door.spr.color = Color.black;
                    break;
                case "RGBA(0.000, 0.000, 0.000, 1.000)":
                    door.spr.color = Color.white;
                    break;
            }
        }
    }
}
