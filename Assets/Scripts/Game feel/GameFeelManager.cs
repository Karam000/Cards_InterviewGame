using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for the whole game experience feel for the player
/// </summary>
public class GameFeelManager : MonoBehaviour
{
    [SerializeField] private VisualManager VisualManager;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] private float NPCEmojiPercentage; //percentage to finetune the emoji showing frequency

    public static GameFeelManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Play cards dealing audio
    /// </summary>
    public void PlayDealingAudio()
    {
        AudioManager.PlayDealingAudio();
    }

    /// <summary>
    /// stop the current playing audio
    /// </summary>
    public void StopAudio()
    {
        AudioManager.StopAudio();
    }

    /// <summary>
    /// play card audio
    /// </summary>
    public void PlayCardAudio()
    {
        AudioManager.PlayCardAudio();
    }

    /// <summary>
    /// celebrate winning card
    /// </summary>
    /// <param name="card">best card on the ground</param>
    public void CelebrateCard(Card card)
    {
        VisualManager.PlayCelebrationParticle(CelebrationStates.MaxCard, card.transform.position);
        AudioManager.Celebrate(CelebrationStates.MaxCard);
    }

    /// <summary>
    /// celebrate winning player (level end)
    /// </summary>
    /// <param name="player">winning player</param>
    public void CelebratePlayer(Player player)
    {
        VisualManager.PlayCelebrationParticle(CelebrationStates.PlayerWin, player.transform.position);
        AudioManager.Celebrate(CelebrationStates.PlayerWin);
    }

    /// <summary>
    /// generate a random thinking time and pick a random emoji accordingly
    /// </summary>
    /// <param name="npcPlayer">the NPC thinking</param>
    /// <returns></returns>
    public float SimulateNPCThinking(Player npcPlayer)
    {
        float thinkingTime = UnityEngine.Random.Range(0.2f, 0.8f);

        PlayRandomEmoji(thinkingTime, npcPlayer);

        return thinkingTime;
    }

    /// <summary>
    /// play random emoji based on thinkingTime
    /// </summary>
    /// <param name="thinkingTime">the random thinkingTime determining the emoji</param>
    /// <param name="npcPlayer">the NPC thinking</param>
    private void PlayRandomEmoji(float thinkingTime, Player npcPlayer)
    {
        VisualManager.PlayEmoji_Random(thinkingTime, npcPlayer, NPCEmojiPercentage);
    }
}

/// <summary>
/// A simple class representing NPC emotions
/// </summary>
[Serializable]
public class NPCEmotion
{
    public Emotions emotion;
    public float thinkingTime;
    public List<GameObject> EmotionSprites;
}

/// <summary>
/// List of NPCEmotion
/// </summary>
[Serializable]
public class NPCEmotionList
{
    public List<NPCEmotion> NPCEmotions;

    public List<NPCEmotion> this[float thinkingTime]
    {
        get
        {
            return NPCEmotions.FindAll(x => x.thinkingTime <= thinkingTime);
        }
    }
}