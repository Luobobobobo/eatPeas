using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCharacter : MonoBehaviour
{
    GameObject PrefabCaptain;
    GameObject PrefabRookie;
    GameObject PrefabSergeant;
    public Dictionary<int, ICharacter> _dicCharacter;
    public GameObject AllPoint;
    public Transform soliderPos;

    private void Start()
    {
        PrefabCaptain = Resources.Load<GameObject>("solider/captain");
        PrefabRookie = Resources.Load<GameObject>("solider/rookie");
        PrefabSergeant = Resources.Load<GameObject>("solider/sergeant");
        _dicCharacter = new Dictionary<int, ICharacter>();
        _dicCharacter.Add(0, new soliderCaptain());
        _dicCharacter.Add(1, new soliderRookie());
        _dicCharacter.Add(2, new soliderSergeant());
    }

    private void Update()
    {
        Vector3 limitPoint = Vector3.zero;
        GameObject soliderObj = null;
        int num = Random.Range(0, _dicCharacter.Count);
        //计算代表范围的物体的长和宽
        float num_x = AllPoint.GetComponent<Renderer>().bounds.size.x;
        float num_y = AllPoint.GetComponent<Renderer>().bounds.size.z;
        if (AllPoint.transform.childCount <= 3)
        {
            _dicCharacter.TryGetValue(num, out ICharacter imcharacter);
            Vector3 PointPos= new Vector3(Random.Range(-num_x / 2, num_x / 2), 0.5f, Random.Range(-num_y / 2, num_y / 2));

            //控制敌人生成的位置之间的距离
            for (int i = 0; i < AllPoint.transform.childCount; i++)
            {
                if (Vector3.Distance(AllPoint.transform.GetChild(i).position, PointPos) < 5)
                {
                    PointPos += new Vector3(5, 0, 5);
                }
            }
            switch (num)
            {
                case 0:
                    soliderObj = Instantiate(PrefabCaptain);
                    imcharacter.captainBase(soliderObj).showMessage();
                    Debug.Log(imcharacter.captainBase(soliderObj).character.ToString());
                    imcharacter.captainBase(soliderObj).getPos(PointPos);
                    break;
                case 1:
                    soliderObj = Instantiate(PrefabRookie);
                    imcharacter.rookieBase(soliderObj).showMessage();
                    Debug.Log(imcharacter.rookieBase(soliderObj).character.ToString());
                    imcharacter.rookieBase(soliderObj).getPos(PointPos);
                    break;
                case 2:
                    soliderObj = Instantiate(PrefabSergeant);
                    imcharacter.sergeantBase(soliderObj).showMessage();
                    Debug.Log(imcharacter.sergeantBase(soliderObj).character.ToString());
                    imcharacter.sergeantBase(soliderObj).getPos(PointPos);
                    break;
            }
            soliderObj.transform.SetParent(AllPoint.transform);
            soliderObj.transform.position = PointPos;
        }
    }
}
