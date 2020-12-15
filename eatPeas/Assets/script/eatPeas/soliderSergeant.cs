using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soliderSergeant : ICharacter
{
    public override CaptainBase captainBase(GameObject game)
    {
        throw new System.NotImplementedException();
    }

    public override RookieBase rookieBase(GameObject game)
    {
        throw new System.NotImplementedException();
    }

    public override SergeantBase sergeantBase(GameObject game)
    {
        SergeantBase sergeantBase = game.GetComponent<SergeantBase>();
        return sergeantBase;
    }
}
