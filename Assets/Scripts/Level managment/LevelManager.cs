using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This is the whole level manager. Responsible for routing the whole game operation, calling score and UI 
/// <br>operations, starting and ending the level and game feel operations</br>
/// </summary>

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

        //shuffle cards
        Deck.ShuffleCardS();

        //wait for shuffle then start dealing in CCW order
        yield return StartCoroutine(Dealer.DealCards(Deck));

        //start the first round
        RoundManager.Instance.StartRound();
    }

    /// <summary>
    /// end round:
    /// <br>1. get best played card</br>
    /// <br>2. celebrate the best card</br>
    /// <br>3. give point the best card's owner</br>
    /// <br>4. determine next step (another round or level end)</br>
    /// </summary>
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

    /// <summary>
    /// end level:
    /// <br>1. determine winner player</br>
    /// <br>2. celebrate winner</br>
    /// <br>3. show level end UI</br>
    /// </summary>
    private void EndLevel()
    {
        RoundManager.Instance.EndGame();
        //determine winner
        AllPlayers.OrderBy((p) => p.Score);
        //celebrate winner
        GameFeelManager.Instance.CelebratePlayer(AllPlayers[0]);
        //ask for restart from UI manager
        UIManager.Instance.ShowLevelEnd(AllPlayers[0]);
    }
    
}
