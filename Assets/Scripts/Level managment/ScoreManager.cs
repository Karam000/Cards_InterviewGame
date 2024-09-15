using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
