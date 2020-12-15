using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterNomalState : playerStateBase
{
    public override void _AIBaseState(player_move player)
    {
        player.animator.SetInteger("state", 0);
    }
}
