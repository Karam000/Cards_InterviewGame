using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField] List<Player> Players;

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

    public void RandomizeFirstPlayer()
    {
        startingPlayerId = Random.Range(0, Players.Count); //exclusive so will be max: count-1
        currentPlayer = Players[startingPlayerId];
    }

    public Player GetPlayerCCW(int index)
    {
        return Players[(startingPlayerId + index) % Players.Count];
    }

    public void OnNewTurn(bool isFirstTurn)
    {
        if(!isFirstTurn) 
            UpdateCurrentPlayer();

        PlayCurrentTurn();
    }
    private void UpdateCurrentPlayer()
    {
        currentPlayer = Players[currentPlayerId++ % Players.Count];
        //visual for current player
    }

    public void PlayCurrentTurn()
    {
        if(currentPlayer is NPCPlayer) 
        currentPlayer.PlayTurn();
    }
}
