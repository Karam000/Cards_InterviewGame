using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsManager : MonoBehaviour
{
    int playsCount = 0;

    public static TurnsManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayTurn(bool isFirstTurn)
    {
        PlayersManager.Instance.OnNewTurn(isFirstTurn); 
    }

    public void EndTurn()
    {
        playsCount++;
        if(playsCount > 3)
        {
            //level manager end round
            playsCount = 0;
            LevelManager.Instance.EndRound();
        }
        else
        {
            PlayTurn(false);
        }

    }
}
