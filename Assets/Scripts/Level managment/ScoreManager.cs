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

    public void AddPointToPlayer(Player player)
    {
        player.AddScorePoint();

        IncrementScoreCommand.Execute(IncrementScoreCommand, player.Score);
    }
}
