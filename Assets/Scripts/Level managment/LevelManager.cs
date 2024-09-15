using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Dealer Dealer;
    [SerializeField] Deck Deck;

    int roundsMaxCount = 13;
    int currentRoundNumber = 1;
    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    IEnumerator Start()
    {
        Deck.ShuffleCardS();
        yield return StartCoroutine(Dealer.DealCards(Deck));
        RoundManager.Instance.StartRound();
    }
    public void EndRound()
    {
        currentRoundNumber++;
        if (currentRoundNumber > roundsMaxCount) //all 4 rounds played (level is done)
        {
            EndLevel();
        }
        else
        {
            //determine max card
            Card maxCardOnGround = GroundManager.Instance.GetMaxPlayedCard();

            //give point to max card owner

            //re-iterate
            RoundManager.Instance.StartRound();
        }
    }

    private void EndLevel()
    {
    }
    
}
