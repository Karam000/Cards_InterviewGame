using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip cardDealAudio;
    [SerializeField] AudioClip cardPlayAudio;
    [SerializeField] AudioClip cardWinAudio;
    [SerializeField] AudioClip playerWinAudio;

    public void PlayDealingAudio()
    {
        PlayAudio(cardDealAudio);
    }
    public void PlayCardAudio()
    {
        PlayAudio(cardPlayAudio);
    }
    public void StopAudio()
    {
        AudioSource.Stop();
    }
    public void Celebrate(CelebrationStates celebrationState)
    {
        switch (celebrationState)
        {
            case CelebrationStates.PlayerWin:
                PlayAudio(playerWinAudio);
                break;
            case CelebrationStates.MaxCard:
                PlayAudio(cardWinAudio);
                break;
            default:
                break;
        }
    }


    private void PlayAudio(AudioClip audioClip)
    {
        AudioSource.Stop();
        AudioSource.clip = audioClip;
        AudioSource.Play();
    }
}
