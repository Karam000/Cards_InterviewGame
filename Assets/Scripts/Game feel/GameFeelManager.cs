using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFeelManager : MonoBehaviour
{
    [SerializeField] VisualManager VisualManager;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] float NPCEmojiPercentage;

    public static GameFeelManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
   
    public void CelebrateCard(Card card)
    {
        VisualManager.PlayCelebrationParticle(CelebrationStates.MaxCard,card.transform.position);
    }
    public void CelebratePlayer(Player player)
    {
        VisualManager.PlayCelebrationParticle(CelebrationStates.PlayerWin, player.transform.position);
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
    private void PlayRandomEmoji(float thinkingTime,Player npcPlayer)
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
