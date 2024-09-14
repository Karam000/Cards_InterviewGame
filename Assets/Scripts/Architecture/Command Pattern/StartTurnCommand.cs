using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTurnCommand : ICommand<StartTurnCommand>
{
    public static Card PlayedCard;
    override public void Execute(StartTurnCommand t)
    {
        base.Execute(t);
    }
}
