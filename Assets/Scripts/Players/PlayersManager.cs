using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField] List<Player> Players;

    public Player FirstPlayer => Players[startingPlayerId];

    private Player currentPlayer;
    private int currentPlayerId;

    private int startingPlayerId;

    public static PlayersManager Instance;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetFirstPlayer()
    {
        startingPlayerId = Random.Range(0, Players.Count); //exclusive so will be max: count-1
        currentPlayer = Players[startingPlayerId];
    }

    public Player GetPlayerByIndex(int index)
    {
        return Players[(startingPlayerId + index) % Players.Count];
    }

    public void SetCurrentPlayer()
    {
        currentPlayer = Players[currentPlayerId];
    }
    
}
