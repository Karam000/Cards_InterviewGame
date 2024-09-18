using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// excuted everytime a player ends playing
/// <br>Observers: PlayersManager, RoundManager </br> 
/// </summary>
public class EndTurnCommand : ICommand<EndTurnCommand>
{
    override public void Execute(EndTurnCommand t)
    {
        base.Execute(t);
    }
}
