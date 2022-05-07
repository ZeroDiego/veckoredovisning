using System.Collections.Generic;
using UnityEngine;

// When this script is attached to an object, an AudioSource is automatically also added, and cannot be removed.
namespace EventCallbacks
{
[RequireComponent(typeof(AudioSource))]
    public class SoundSystem : MonoBehaviour
    {
        private AudioSource audioSource;
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            EventHandler.Current.RegisterListener(typeof(SoundEvent), PlaySound);
        }

        void PlaySound(Event eventInfo)
        {
            SoundEvent soundEvent = (SoundEvent)eventInfo;
            audioSource.clip = soundEvent.audioClip;
            audioSource.Play();
        }
    }
}
