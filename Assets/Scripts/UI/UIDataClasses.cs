using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

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