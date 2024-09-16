using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour
{
    [SerializeField] ParticleSystem WinParticle;
    [SerializeField] ParticleSystem MaxCardParticle;

    [SerializeField] List<Sprite> ThinkingEmojis;
    [SerializeField] List<Sprite> ConfidentEmojis;
    [SerializeField] List<Sprite> DesperateEmojis;
    [SerializeField] List<Sprite> BoredEmojis;

    public void PlayCelebrationParticle(CelebrationStates celebarationState, Vector3 position)
    {
        ParticleSystem particleSystem = DetermineParticleSystem(celebarationState);
        if (particleSystem == null) 
            return;

        particleSystem.gameObject.transform.position = position;
        particleSystem.gameObject.SetActive(true);
    }

    public void PlayEmoji(Emojis emojiType, Vector3 position)
    {

    }

    private ParticleSystem DetermineParticleSystem(CelebrationStates celebarationState)
    {
        switch (celebarationState)
        {
            case CelebrationStates.PlayerWin:
                return WinParticle;
            case CelebrationStates.MaxCard:
                return MaxCardParticle;
        }
        return null;
    }
}
