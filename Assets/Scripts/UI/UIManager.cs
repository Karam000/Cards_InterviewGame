using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IParamObserver<IncrementScoreCommand, Player>
{
    [SerializeField] PlayersUIList PlayersUIData;
    [SerializeField] LevelEndPanel LevelEndPanel;
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void ShowLevelEnd(Player player)
    {
        LevelEndPanel.Open(player.gameObject.name);
    }

    public void Restart() //called from restart button in inspector (not optimal)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //very basic restart (not optimal)
    }
    public void Quit() //called from quit button in inspector (not optimal)
    {
        Application.Quit();  //very basic quit (not optimal)
    }
    public void OnNotify(IncrementScoreCommand incrementScoreCommand, Player player)
    {
        print("incrementing player: " + player.name + " to be " + player.Score + " points");
        PlayersUIData[player].scoreText.text = player.Score.ToString();
    }
}

