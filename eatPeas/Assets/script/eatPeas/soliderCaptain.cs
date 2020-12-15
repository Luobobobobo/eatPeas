using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soliderCaptain : ICharacter
{
    public override CaptainBase captainBase(GameObject game)
    {
        CaptainBase captainBase = game.GetComponent<CaptainBase>();
        return captainBase;
    }

    public override RookieBase rookieBase(GameObject game)
    {
        throw new System.NotImplementedException();
    }

    public override SergeantBase sergeantBase(GameObject game)
    {
        throw new System.NotImplementedException();
    }
}
