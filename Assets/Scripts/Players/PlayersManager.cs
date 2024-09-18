using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reasponsible for handling players operations as a whole
/// </summary>
public class PlayersManager : MonoBehaviour, IObserver<StartTurnCommand>, IObserver<EndTurnCommand>
{
    [SerializeField] List<Player> Players;
    [SerializeField] GameObject Arrow; //visual indicator for current player
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

    /// <summary>
    /// set starting player randomly
    /// </summary>
    public void RandomizeFirstPlayer()
    {
        startingPlayerId = Random.Range(0, Players.Count); //exclusive so will be max: count-1
        currentPlayerId = startingPlayerId;
        currentPlayer = Players[startingPlayerId];
    }

    /// <summary>
    /// get the next player in CCW order
    /// </summary>
    /// <param name="index">index(from a loop) of next player</param>
    /// <returns></returns>
    public Player GetPlayerCCW(int index)
    {
        return Players[(startingPlayerId + index) % Players.Count];
    }

    #endregion

    /// <summary>
    /// called when a turn starts
    /// </summary>
    /// <param name="startTurnCommand"></param>
    public void OnNotify(StartTurnCommand startTurnCommand)
    {
        PlayCurrentTurn();
    }

    /// <summary>
    /// called when a turn ends
    /// </summary>
    /// <param name="endTurnCommand"></param>
    public void OnNotify(EndTurnCommand endTurnCommand)
    {
        UpdateCurrentPlayer();
    }

    /// <summary>
    /// Update the player whose turn is active
    /// </summary>
    private void UpdateCurrentPlayer()
    {
        currentPlayer = Players[(++currentPlayerId) % Players.Count];
        //maybe add visual for current player ?? (done :) )
    }

    /// <summary>
    /// Play current player trun and show arrow indicator
    /// </summary>
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
