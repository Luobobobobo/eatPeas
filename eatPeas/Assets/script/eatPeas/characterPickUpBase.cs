using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterPickUpBase : playerStateBase
{
    public override void _AIBaseState(player_move player)
    {
        //人物捡拾状态
        player.animator.SetTrigger("pickup");
    }
}
