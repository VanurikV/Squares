using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace squares
{
    public class SoundFxScript : MonoBehaviour
    {
        public AudioClip[] SoundFxClip;

        private AudioSource audioSource;
        public void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void ButtonClickFxPlay()
        {
            audioSource.PlayOneShot(SoundFxClip[(int)SoundFx.ButtonClick]);
        }

        public void PlayFx(SoundFx Fx)
        {
            audioSource.PlayOneShot(SoundFxClip[(int)Fx]);
        }



    }
}
