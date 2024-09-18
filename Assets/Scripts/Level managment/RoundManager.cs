using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for handling the round being played
/// </summary>
public class RoundManager : MonoBehaviour, IObserver<EndTurnCommand>
{
    StartTurnCommand StartTurnCommand = new(); //invokes each time a playser starts playing
    public int RoundCount {  get; private set; } //keep track of the current round count in the game
    public bool IsUserTurn { get; private set; } //is it the user player turn

    private int turnsCount; //current turns count of this round (0 - 3) >> max 4 turns

    public static RoundManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartTurnCommand.AddObserver(PlayersManager.Instance);
    }

    /// <summary>
    /// set parameters for the round start and start the first turn
    /// </summary>
    public void StartRound()
    {
        turnsCount = 0;
        IsUserTurn = false;
        GroundManager.Instance.ResetCards();
        PlayNextTurn();
    }

    /// <summary>
    /// called when all rounds (13) have been played to reset everything
    /// </summary>
    public void EndGame()
    {
        turnsCount = 0;
        RoundCount = 0;
    }

    /// <summary>
    /// set IsUserTurn
    /// </summary>
    /// <param name="isUserTurn"></param>
    public void SetIsUserTurn(bool isUserTurn)
    {
        IsUserTurn=isUserTurn;
    }

    /// <summary>
    /// called when an EndTurnCommand has been invoked
    /// </summary>
    private void UpdateTurn()
    {
        turnsCount++;
        if (turnsCount > 3)
        {
            EndRound();
        }
        else
        {
            PlayNextTurn();
        }
    }

    /// <summary>
    /// called when 4 turns have been played. calls levelManager to determine the winner (Card or player)
    /// </summary>
    private void EndRound()
    {
        LevelManager.Instance.EndRound();
    }

    /// <summary>
    /// excute a StartTurnCommand
    /// </summary>
    private void PlayNextTurn()
    {
        RoundCount++;
        StartTurnCommand.Execute(StartTurnCommand);
    }

    public void OnNotify(EndTurnCommand endTurnCommand)
    {
        UpdateTurn();
    }
}