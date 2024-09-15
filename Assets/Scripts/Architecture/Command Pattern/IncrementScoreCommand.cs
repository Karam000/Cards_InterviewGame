using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementScoreCommand : IParamCommand<IncrementScoreCommand,int>
{
    public int Score { get; private set; }
    override public void Execute(IncrementScoreCommand t,int score)
    {
        Score = score;
        base.Execute(t,score);
    }
}
