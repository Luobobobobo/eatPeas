using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public static float timeCount = 50;
    public GameObject player;
    private void Update()
    {
        //游戏倒计时
        timeCount -= Time.deltaTime;
        UI_controller.instance._time.text = "倒计时：" + (int)timeCount;
    }
}
