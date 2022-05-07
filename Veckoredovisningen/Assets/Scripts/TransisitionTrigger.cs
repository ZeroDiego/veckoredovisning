using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransisitionTrigger : MonoBehaviour
{
    public bool isTriggered;
    private SmoothCameraTransistion smoothCameraTransistion;

	private void Start()
	{
		smoothCameraTransistion = FindObjectOfType<SmoothCameraTransistion>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            smoothCameraTransistion.target = transform.GetComponentInChildren<Transform>();
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }
    */
}
