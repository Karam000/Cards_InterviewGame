using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// responsible for handling the UI
/// </summary>
public class UIManager : MonoBehaviour, IParamObserver<IncrementScoreCommand, Player>
{
    [SerializeField] PlayersUIList PlayersUIData;
    [SerializeField] LevelEndPanel LevelEndPanel;
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Show level end panel and set the text to the winner name
    /// </summary>
    /// <param name="player">winner player</param>
    public void ShowLevelEnd(Player player)
    {
        LevelEndPanel.Open(player.gameObject.name);
    }

    /// <summary>
    /// Restart the game
    /// </summary>
    public void Restart() //called from restart button in inspector (not optimal)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //very basic restart (not optimal)
    }

    /// <summary>
    /// Exit app
    /// </summary>
    public void Quit() //called from quit button in inspector (not optimal)
    {
        Application.Quit();  //very basic quit (not optimal)
    }

    /// <summary>
    /// called when a player's score is incremented to update the UI
    /// </summary>
    /// <param name="incrementScoreCommand">the command that excuted to notify this function</param>
    /// <param name="player">the player that had his score incremented</param>
    public void OnNotify(IncrementScoreCommand incrementScoreCommand, Player player)
    {
        print("incrementing player: " + player.name + " to be " + player.Score + " points");
        PlayersUIData[player].scoreText.text = player.Score.ToString();
    }
}

