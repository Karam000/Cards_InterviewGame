using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IParamObserver<IncrementScoreCommand, Player>
{
    [SerializeField] PlayersUIList PlayersUIData;
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void OnNotify(IncrementScoreCommand incrementScoreCommand, Player player)
    {
        print("incrementing player: " + player.name + " to be " + player.Score + " points");
        PlayersUIData[player].scoreText.text = player.Score.ToString();
    }
}

[Serializable]
public class PlayerUIData
{
    public Player Player;
    public Text scoreText;
    public Text nameText;
    public Image avatarImg;
}

[Serializable]
public class PlayersUIList //just for custom indexing
{
    public List<PlayerUIData> PlayersUIData;
    public PlayerUIData this[Player player]
    {
        get
        {
            return PlayersUIData.Find(x => x.Player == player);
        }
    }
}
