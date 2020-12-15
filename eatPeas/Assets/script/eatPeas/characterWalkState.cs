using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterWalkState : playerStateBase
{
    public override void _AIBaseState(player_move player)
    {
        //敌人走路状态
        player.animator.SetInteger("state", 1);
        player.moveSpeed = 5;
    }
}
