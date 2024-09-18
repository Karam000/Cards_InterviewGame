using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;


/// <summary>
/// A simple class representing a player on the UI
/// </summary>
[Serializable]
public class PlayerUIData
{
    public Player Player;
    public Text scoreText;
    public Text nameText;
    public Image avatarImg;
}

/// <summary>
/// List of PlayerUIData
/// </summary>
[Serializable]
public class PlayersUIList //just for indexing using a Player object
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