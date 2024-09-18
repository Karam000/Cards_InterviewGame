using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// excuted everytime a player starts playing
/// <br>Observers: PlayersManager </br> 
/// </summary>
public class StartTurnCommand : ICommand<StartTurnCommand>
{
    public static Card PlayedCard;
    override public void Execute(StartTurnCommand t)
    {
        base.Execute(t);
    }
}
