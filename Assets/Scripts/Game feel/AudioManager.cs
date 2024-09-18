using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Responsible for handling audio play/stop
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip cardDealAudio;
    [SerializeField] AudioClip cardPlayAudio;
    [SerializeField] AudioClip cardWinAudio;
    [SerializeField] AudioClip playerWinAudio;

    /// <summary>
    /// cards dealing audio
    /// </summary>
    public void PlayDealingAudio()
    {
        PlayAudio(cardDealAudio);
    }

    /// <summary>
    /// card play audio
    /// </summary>
    public void PlayCardAudio()
    {
        PlayAudio(cardPlayAudio);
    }

    /// <summary>
    /// stop audio :)
    /// </summary>
    public void StopAudio()
    {
        AudioSource.Stop();
    }

    /// <summary>
    /// celebration audio
    /// </summary>
    /// <param name="celebrationState">whether a player win(level end) or a card win</param>
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

    /// <summary>
    /// Play audio
    /// </summary>
    /// <param name="audioClip">the audio to be played</param>
    private void PlayAudio(AudioClip audioClip)
    {
        AudioSource.Stop();
        AudioSource.clip = audioClip;
        AudioSource.Play();
    }
}
