using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    

    public void Celebrate(CelebrationStates celebrationState)
    {

    }


    private void PlayAudio(AudioClip audioClip)
    {
        AudioSource.Stop();
        AudioSource.clip = audioClip;
        AudioSource.Play();
    }
}
