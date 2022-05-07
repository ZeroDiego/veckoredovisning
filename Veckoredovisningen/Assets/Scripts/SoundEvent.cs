using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public abstract class Event{}
    public class SoundEvent : Event
    {
        public AudioSource audioSource;
        public AudioClip audioClip;

        public SoundEvent(AudioClip audioClip)
        {
            this.audioClip = audioClip;
        }
    }
}