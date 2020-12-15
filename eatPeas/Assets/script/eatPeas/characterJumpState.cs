using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterJumpState : playerStateBase
{
    public override void _AIBaseState(player_move player)
    {
        //人物跳跃状态
        player.animator.SetTrigger("jump");
    }
}
