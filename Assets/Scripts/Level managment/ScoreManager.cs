using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for handling score operations (simply invokes a command)
/// </summary>
public class ScoreManager : MonoBehaviour
{
    IncrementScoreCommand IncrementScoreCommand = new();

    public static ScoreManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        IncrementScoreCommand.AddObserver(UIManager.Instance);
    }
    public void AddPointToPlayer(Player player)
    {
        player.AddScorePoint();

        IncrementScoreCommand.Execute(IncrementScoreCommand, player);
    }
}
