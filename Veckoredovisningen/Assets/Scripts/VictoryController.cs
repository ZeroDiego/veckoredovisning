using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EventCallbacks
{
	public class VictoryController : MonoBehaviour
	{
		public static int triggered = 0;
		public AudioClip victorySound;
		public Canvas victoryCanvas;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			triggered++;
			if (triggered == 2)
			{
				SoundEvent soundEvent = new SoundEvent(victorySound);
				EventHandler.Current.FireEvent(soundEvent);
				Debug.Log("Victory");
				FindObjectOfType<PlayerController>().gameObject.SetActive(false);
				victoryCanvas.gameObject.SetActive(true);
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			triggered--;
		}
	}
}
