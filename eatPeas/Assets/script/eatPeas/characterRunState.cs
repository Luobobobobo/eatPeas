using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRunState : playerStateBase
{
    public override void _AIBaseState(player_move player)
    {
        //敌人跑步状态
        player.animator.SetInteger("state", 2);
        player.moveSpeed = 10;
    }
}
