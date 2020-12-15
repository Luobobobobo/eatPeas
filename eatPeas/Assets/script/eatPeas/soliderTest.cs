using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class soliderTest : MonoBehaviour
{
    public GameObject playerObj;
    playerBaseState currentBase;
    public NavMeshAgent nav;

    private void Start()
    {
        playerObj = GameObject.Find("player");
        nav = GetComponent<NavMeshAgent>();
    }

    public void _setStae(playerBaseState baseState)
    {
        currentBase = baseState;
    }

    //通过敌人和人物之间相距的距离，决定敌人的状态
    private void Update()
    {
        if (_distance() < 5)
        {
            _setStae(new playerChasingState());
            currentBase._AIbaseState(this);
        }
        else
        {
            _setStae(new playerNormalState());
            currentBase._AIbaseState(this);
        }
    }

    public float _distance()
    {
        float disVector3 = Vector3.Distance(transform.position, playerObj.transform.position);
        return disVector3;
    }
}
