using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour, IObserver<EndTurnCommand>
{
    StartTurnCommand StartTurnCommand = new();
    int turnsCount = 0;

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
        GroundManager.Instance.ResetCards();
        PlayNextTurn();
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
        StartTurnCommand.Execute(StartTurnCommand);
    }

    public void OnNotify(EndTurnCommand endTurnCommand)
    {
        UpdateTurn();
    }
}