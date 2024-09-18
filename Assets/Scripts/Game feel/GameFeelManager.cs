using System;
using System.Collections.Generic;
using UnityEngine;

public class GameFeelManager : MonoBehaviour
{
    [SerializeField] private VisualManager VisualManager;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] private float NPCEmojiPercentage;

    public static GameFeelManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayDealingAudio()
    {
        AudioManager.PlayDealingAudio();
    }

    public void StopAudio()
    { 
        AudioManager.StopAudio();
    }

    public void PlayCardAudio()
    {
        AudioManager.PlayCardAudio();
    }
    public void CelebrateCard(Card card)
    {
        VisualManager.PlayCelebrationParticle(CelebrationStates.MaxCard, card.transform.position);
        AudioManager.Celebrate(CelebrationStates.MaxCard);
    }

    public void CelebratePlayer(Player player)
    {
        VisualManager.PlayCelebrationParticle(CelebrationStates.PlayerWin, player.transform.position);
        AudioManager.Celebrate(CelebrationStates.PlayerWin);
    }

    public float SimulateNPCThinking(Player npcPlayer)
    {
        float thinkingTime = UnityEngine.Random.Range(0.2f, 0.8f);

        PlayRandomEmoji(thinkingTime, npcPlayer);

        return thinkingTime;
    }

    //private void SetNPCEmotion(Player npcPlayer)
    //{
    //    Card maxPlayedCard = GroundManager.Instance.GetMaxPlayedCard();
    //}
    private void PlayRandomEmoji(float thinkingTime, Player npcPlayer)
    {
        VisualManager.PlayEmoji_Random(thinkingTime, npcPlayer, NPCEmojiPercentage);
    }
}

[Serializable]
public class NPCEmotion
{
    public Emotions emotion;
    public float thinkingTime;
    public List<GameObject> EmotionSprites;
}

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