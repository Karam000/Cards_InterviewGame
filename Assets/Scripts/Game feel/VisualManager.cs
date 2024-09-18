using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// responsible for visual effects required by GameFeelManager
/// </summary>
public class VisualManager : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> WinParticle;
    [SerializeField] private List<ParticleSystem> MaxCardParticle;
    [SerializeField] private NPCEmotionList NPCEmotionList;

    bool isPlayingEmoji = false;

    /// <summary>
    /// Play celebration particle according to state
    /// </summary>
    /// <param name="celebarationState">player win(level end) or card win</param>
    /// <param name="position">where to play the particle (typically the winning card position)</param>
    public void PlayCelebrationParticle(CelebrationStates celebarationState, Vector3 position)
    {
        List<ParticleSystem> particleSystems = DetermineParticleSystem(celebarationState);
        if (particleSystems == null)
            return;

        foreach (var particleSystem in particleSystems)
        {
            if(particleSystems == MaxCardParticle)
            particleSystem.gameObject.transform.position = position;

            particleSystem.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Randomize play an emoji based on thinking time.
    /// <br>it would be better to decide the emoji based on the cards in hand and on the ground but I just</br>
    /// <br>but I just went with this simple approch as a proof of concept.</br>
    /// </summary>
    /// <param name="thinkingTime">The time taken by the NPC to think</param>
    /// <param name="player">the NPC on whick the emoji will be shown</param>
    /// <param name="emojiPlayPercentage">a percentage used to fine tune frequency of showing emojis</param>
    public void PlayEmoji_Random(float thinkingTime, Player player, float emojiPlayPercentage)
    {
        if (isPlayingEmoji) return;


        List<NPCEmotion> validEmotions = NPCEmotionList[thinkingTime];

        if (Random.Range(0, 100) < emojiPlayPercentage)
            return;

        List<GameObject> EmotionSprites;
        try
        {
            EmotionSprites = validEmotions[Random.Range(0, validEmotions.Count)]?.EmotionSprites;
        }
        catch (System.Exception)
        {

            return;
        }

        if(EmotionSprites == null || EmotionSprites.Count == 0) return;
        ShowEmojiSprite(EmotionSprites[Random.Range(0, EmotionSprites.Count)], player);
    }

    /// <summary>
    /// show and animate emoji sprite
    /// </summary>
    /// <param name="emoji">the emoji to be shown</param>
    /// <param name="player">the NPC to show the emoji on</param>
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

    /// <summary>
    /// determine whick particle to be played according to the state
    /// </summary>
    /// <param name="celebarationState">player win(level end) or card win</param>
    /// <returns>particle system to be played in this state</returns>
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