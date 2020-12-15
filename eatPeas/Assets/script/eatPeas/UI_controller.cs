using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UI_controller : MonoBehaviour
{
    public static UI_controller instance;
    public Text fenshu;
    public Text hp;
    public Text jieguo;
    public Text _time;
    public float i;
    public float characterHp = 100;
    public GameObject gameOver;
    public GameObject gameWin;
    public Image rankPanel;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        jieguo.text = "得分：" + i;
        fenshu.text = "分数：" + i;

        if (characterHp <= 0)
        {
            characterHp = 0;
        }
        hp.text = "生命：" + characterHp;
    }
    //重新游戏
    public void reGame()
    {
        SceneManager.LoadScene(0);
        timeController.timeCount = 50;
    }
    //排行榜移动到场景中
    public void ranking()
    {
        rankPanel.rectTransform.DOMove(new Vector2(960, 540), 1);
    }
    //排行榜回到初始位置
    public void Close_ranking()
    {
        rankPanel.rectTransform.DOMove(new Vector2(2360, 540), 1);
    }
}
