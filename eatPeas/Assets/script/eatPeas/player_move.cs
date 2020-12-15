using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public GameObject characterObj;
    public GameObject characterPoint;
    public GameObject controllerObj;
    public float moveSpeed;
    public float JumpSpeed = 10;
    public float vectDown = 0;
    public float goalScore;
    public Animator animator;
    playerStateBase currentState;
    Ray myRay;
    public RaycastHit hit;
    bool isbool = true;

    private void Start()
    {
        animator = characterObj.GetComponent<Animator>();
    }

    public void setState(playerStateBase playerStateBase)
    {
        currentState = playerStateBase;
    }

    //判断人物是否在地面上
    bool IsGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, vectDown);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        //人物转向
        if (Input.GetMouseButton(0))
        {
            float y = 0;
            y += Input.GetAxis("Mouse X");
            transform.Rotate(0, y, 0);
        }
        //移动的状态
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            setState(new characterWalkState());
            currentState._AIBaseState(this);
            if (Input.GetKey(KeyCode.R))
            {
                setState(new characterRunState());
                currentState._AIBaseState(this);
            }
        }
        else
        {
            setState(new characterNomalState());
            currentState._AIBaseState(this);
        }
        //跳跃状态
        if (IsGround())
        {
            if (Input.GetButtonDown("Jump"))
            {
                setState(new characterJumpState());
                currentState._AIBaseState(this);
                GetComponent<Rigidbody>().velocity = transform.up * JumpSpeed;
            }
        }

        myRay = new Ray(transform.position, transform.forward);
        //捡拾豆子的状态
        if (Input.GetKeyDown(KeyCode.J))
        {
            setState(new characterPickUpBase());
            currentState._AIBaseState(this);
            if (Physics.Raycast(myRay, out hit, 15))
            {
                if (hit.transform.tag == "peas")
                {
                    float num = hit.transform.gameObject.GetComponent<PeasBase>().peasHp;
                    UI_controller.instance.i += num;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        //死亡的状态
        if (UI_controller.instance.characterHp == 0)
        {
            if (isbool)
            {
                setState(new characterDeathState());
                currentState._AIBaseState(this);
                transform.GetComponent<CollosionCheck>().enabled = false;

                RankingList.instance.showRank();
                controllerObj.GetComponent<timeController>().enabled = false;
            }
            isbool = false;

            //检测当前动画播放器所播放的动画
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.fullPathHash == Animator.StringToHash("Base Layer.Death"))
            {
                //动画播放完成后
                if (animatorStateInfo.normalizedTime >= 1.0f)
                {
                    UI_controller.instance.gameOver.SetActive(true);
                    transform.GetComponent<player_move>().enabled = false;
                }
            }
        }
        //获胜的状态
        if (timeController.timeCount <= 0)
        {
            timeController.timeCount = 0;
            setState(new characterWinState());
            currentState._AIBaseState(this);

            transform.GetComponent<CollosionCheck>().enabled = false;
            transform.GetComponent<player_move>().enabled = false;

            RankingList.instance.showRank();
        }
    }
}
