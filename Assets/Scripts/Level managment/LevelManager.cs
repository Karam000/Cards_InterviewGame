using DG.Tweening;
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
        //determine max card
        Card maxCardOnGround = GroundManager.Instance.GetMaxPlayedCard();

        //visual fr max card
        maxCardOnGround.transform.DOShakeRotation(0.5f);
        maxCardOnGround.transform.DOShakeScale(0.5f);

        //give point to max card owner
        ScoreManager.Instance.AddPointToPlayer(maxCardOnGround.Owner);

        currentRoundNumber++;
        if (currentRoundNumber > roundsMaxCount) //all 13 rounds played (level is done)
        {
            //end level
            EndLevel();
        }
        else
        {
            //re-iterate
            RoundManager.Instance.StartRound();
        }
    }

    private void EndLevel()
    {
        //determine winner
        //celebrate winner
        //ask for restart from UI manager
    }
    
}
