using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// excuted everytime a player increments in score
/// <br>Observers: UIManager </br> 
/// </summary>
public class IncrementScoreCommand : IParamCommand<IncrementScoreCommand,Player>
{
    override public void Execute(IncrementScoreCommand t, Player score)
    {
        base.Execute(t,score);
    }
}
