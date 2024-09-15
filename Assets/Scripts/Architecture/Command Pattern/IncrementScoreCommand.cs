using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementScoreCommand : IParamCommand<IncrementScoreCommand,Player>
{
    override public void Execute(IncrementScoreCommand t, Player score)
    {
        base.Execute(t,score);
    }
}
