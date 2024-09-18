using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour, IObserver<StartTurnCommand>, IObserver<EndTurnCommand>
{
    [SerializeField] List<Player> Players;
    [SerializeField] GameObject Arrow;
    [SerializeField] Material ArrowMaterial;
    [SerializeField] List<Color> ArrowColors;

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

    #region Utility for Dealing
    public void RandomizeFirstPlayer()
    {
        startingPlayerId = 0; //just for testing// Random.Range(0, Players.Count); //exclusive so will be max: count-1
        currentPlayer = Players[startingPlayerId];
    }

    public Player GetPlayerCCW(int index)
    {
        return Players[(startingPlayerId + index) % Players.Count];
    }

    #endregion

    public void OnNotify(StartTurnCommand startTurnCommand)
    {
        PlayCurrentTurn();
    }

    public void OnNotify(EndTurnCommand endTurnCommand)
    {
        UpdateCurrentPlayer();
    }

    private void UpdateCurrentPlayer()
    {
        currentPlayer = Players[(++currentPlayerId) % Players.Count];
        //maybe add visual for current player ??
    }

    private void PlayCurrentTurn()
    {
        if (currentPlayer is NPCPlayer)
        {
            if(!Arrow.activeInHierarchy)
                Arrow.SetActive(true);

            Arrow.transform.position = currentPlayer.transform.position+Vector3.up * 3;
            ArrowMaterial.color = ArrowColors[Players.IndexOf(currentPlayer)];

            StartCoroutine(currentPlayer.PlayTurn());
        }
        else
        {
            Arrow.SetActive(false);
        }

        RoundManager.Instance.SetIsUserTurn(currentPlayer is UserPlayer);
    }


}
