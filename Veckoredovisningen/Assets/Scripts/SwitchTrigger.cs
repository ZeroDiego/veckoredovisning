using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public bool isTriggered;

    public SwitchController switchController;

    private void Awake()
    {
        switchController = GetComponent<SwitchController>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isTriggered = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTriggered = false;
    }
}
