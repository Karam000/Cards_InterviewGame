using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Dealer Dealer;
    [SerializeField] Deck Deck;
    [SerializeField] List<Player> AllPlayers;

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
        GameFeelManager.Instance.CelebrateCard(maxCardOnGround);
        //maxCardOnGround.transform.DOShakeRotation(0.5f);
        //maxCardOnGround.transform.DOShakeScale(0.5f);

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
        AllPlayers.OrderBy((p) => p.Score);
        //celebrate winner
        GameFeelManager.Instance.CelebratePlayer(AllPlayers[0]);
        //ask for restart from UI manager
    }
    
}
