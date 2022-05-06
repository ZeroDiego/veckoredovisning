using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer otherSpr = collision.gameObject.GetComponent<SpriteRenderer>();

            if (spr.color.Equals(otherSpr.color))
            {
                Debug.Log("DaFeet");
            }
        }
    }
}
