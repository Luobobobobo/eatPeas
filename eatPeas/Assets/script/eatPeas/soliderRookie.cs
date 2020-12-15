using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soliderRookie : ICharacter
{
    public override CaptainBase captainBase(GameObject game)
    {
        throw new System.NotImplementedException();
    }

    public override RookieBase rookieBase(GameObject game)
    {
        RookieBase rookieBase = game.GetComponent<RookieBase>();
        return rookieBase;
    }

    public override SergeantBase sergeantBase(GameObject game)
    {
        throw new System.NotImplementedException();
    }
}
