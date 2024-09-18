using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour, IObserver<EndTurnCommand>
{
    StartTurnCommand StartTurnCommand = new();
    public int RoundCount {  get; private set; }
    public bool IsUserTurn { get; private set; }

    private int turnsCount;

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
    public void StartRound()
    {
        turnsCount = 0;
        IsUserTurn = false;
        GroundManager.Instance.ResetCards();
        PlayNextTurn();
    }
    public void EndGame()
    {
        turnsCount = 0;
        RoundCount = 0;
    }
    public void SetIsUserTurn(bool isUserTurn)
    {
        IsUserTurn=isUserTurn;
    }
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
    private void EndRound()
    {
        LevelManager.Instance.EndRound();
    }
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