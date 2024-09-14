using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnCommand : ICommand<EndTurnCommand>
{
    override public void Execute(EndTurnCommand t)
    {
        base.Execute(t);
    }
}
