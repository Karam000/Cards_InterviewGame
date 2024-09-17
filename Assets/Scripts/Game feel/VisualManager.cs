using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> WinParticle;
    [SerializeField] private List<ParticleSystem> MaxCardParticle;
    [SerializeField] private NPCEmotionList NPCEmotionList;

    bool isPlayingEmoji = false;
    public void PlayCelebrationParticle(CelebrationStates celebarationState, Vector3 position)
    {
        List<ParticleSystem> particleSystems = DetermineParticleSystem(celebarationState);
        if (particleSystems == null)
            return;

        foreach (var particleSystem in particleSystems)
        {
            particleSystem.gameObject.transform.position = position;
            particleSystem.gameObject.SetActive(true);
        }
    }

    public void PlayEmoji_Random(float thinkingTime, Player player, float emojiPlayPercentage)
    {
        if (isPlayingEmoji) return;


        List<NPCEmotion> validEmotions = NPCEmotionList[thinkingTime];

        if (Random.Range(0, 100) < emojiPlayPercentage)
            return;

        List<GameObject> EmotionSprites = validEmotions[Random.Range(0, validEmotions.Count)].EmotionSprites;

        ShowEmojiSprite(EmotionSprites[Random.Range(0, EmotionSprites.Count)], player);
    }

    private void ShowEmojiSprite(GameObject emoji, Player player)
    {
        isPlayingEmoji = true;

        emoji.transform.position = player.EmojiPosition.position;
        emoji.SetActive(true);

        Vector3 targetPos = new Vector3(emoji.transform.position.x, emoji.transform.position.y+1,  emoji.transform.position.z);

        emoji.GetComponent<SpriteRenderer>().DOFade(1, 2f);
        emoji.transform.DOMove(targetPos, 2f)
                       .onComplete += () =>
                       {
                           emoji.SetActive(false);
                           isPlayingEmoji = false;
                       };
    }

    private List<ParticleSystem> DetermineParticleSystem(CelebrationStates celebarationState)
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