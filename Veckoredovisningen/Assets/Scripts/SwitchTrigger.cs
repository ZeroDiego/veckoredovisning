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

	private void OnTriggerStay2D(Collider2D collision)
	{
        isTriggered = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isTriggered = false;
	}
}
