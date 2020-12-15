using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingList : MonoBehaviour
{
    public static RankingList instance;
    float[] score = new float[5];
    float[] arrScore;
    public GameObject rankPanel;
    public GameObject rankPanel_all;
    int num;
    private void Awake()
    {
        instance = this;
        //PlayerPrefs.DeleteAll();
    }
    private void Start()
    {
        num = PlayerPrefs.GetInt("num");
        num += 1;
        PlayerPrefs.SetInt("num", num);
        arrScore = new float[num];
    }
    //数据排序
    public void rankScore()
    {
        saveMessage();
        for (int i = 0; i < num; i++)
        {
            arrScore[i] = PlayerPrefs.GetFloat("score" + (i + 1));
        }

        //选择排序法排序排行榜数据
        for (int i = 0; i < arrScore.Length - 1; i++)
        {
            int maxNum = i;
            for (int j = i + 1; j < arrScore.Length; j++)
            {
                if (arrScore[maxNum] < arrScore[j])
                {
                    maxNum = j;
                }
            }
            if (i != maxNum)
            {
                float temp = arrScore[i];
                arrScore[i] = arrScore[maxNum];
                arrScore[maxNum] = temp;
            }
        }
        //for(int i = 0; i < arrScore.Length; i++)
        //{
        //    Debug.Log(arrScore[i]);
        //}
    }
    //存储数据
    public void saveMessage()
    {
        PlayerPrefs.SetFloat("score" + num, UI_controller.instance.i);
    }
    //在排行榜上展示
    public void showRank()
    {
        rankScore();
        for (int i = 0; i < score.Length; i++)
        {
            if (i<arrScore.Length)
            {
                score[i] = arrScore[i];
                GameObject game = Instantiate(Resources.Load<GameObject>("rank/go"));
                game.transform.SetParent(rankPanel.transform);
                game.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                game.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                game.transform.GetChild(1).GetComponent<Text>().text = "得分：" + score[i];
            }
        }
    }
    public void Update()
    {
        if (rankPanel_all.GetComponent<RectTransform>().position==new Vector3(960,540,0))
        {
            if (Input.GetMouseButton(0))
            {
                UI_controller.instance.Close_ranking();
            }
        }
    }
}
