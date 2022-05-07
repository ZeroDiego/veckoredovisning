using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
	public bool isTriggered;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		isTriggered = true;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		isTriggered = false;
	}
}
