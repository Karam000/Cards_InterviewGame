using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Dealer Dealer;
    [SerializeField] Deck Deck;

    int roundsMaxCount;
    int currentRoundNumber;
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
        yield return StartCoroutine(Dealer.DealCards(Deck));

        TurnsManager.Instance.PlayTurn(true);
    }
    public void EndRound()
    {
        currentRoundNumber++;
        if (currentRoundNumber > roundsMaxCount)
        {
            EndLevel();
        }
        else
        {
            //determine max card
            Card maxCardOnGround = CardRanker.Instance.GetMaxPlayedCard();

            //give point to max card owner

            //order shuffle deck

            //re-iterate
        }
    }

    private void EndLevel()
    {

    }
    
}
