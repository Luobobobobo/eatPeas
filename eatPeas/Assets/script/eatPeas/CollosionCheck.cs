using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollosionCheck : MonoBehaviour
{
    public List<string> taglist;
    public GameObject _gameObject = null;

    private void Start()
    {
        taglist = new List<string>(3);
        taglist.Add("captain");
        taglist.Add("rookie");
        taglist.Add("sergeant");
    }
    private void Update()
    {

    }
    //当人物碰撞到敌人时，根据敌人所挂载的不同脚本，扣除敌人的血量
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == taglist[0])
        {
            float num = collision.gameObject.GetComponent<CaptainBase>().character.maxHp;
            UI_controller.instance.characterHp -= num;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == taglist[1])
        {
            float num = collision.gameObject.GetComponent<RookieBase>().character.maxHp;
            UI_controller.instance.characterHp -= num;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == taglist[2])
        {
            float num = collision.gameObject.GetComponent<SergeantBase>().character.maxHp;
            UI_controller.instance.characterHp -= num;
            Destroy(collision.gameObject);
        }
    }
    //当人物和敌人的顶面触发时，销毁敌人，生成不同的豆子
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "peaspoint")
        {
            Debug.Log("生成豆子");
            if (other.gameObject.transform.parent.tag == taglist[0])
            {
                _gameObject = Instantiate(Resources.Load<GameObject>("peas/cPeas"));
            }
            else if (other.gameObject.transform.parent.tag == taglist[1])
            {
                _gameObject = Instantiate(Resources.Load<GameObject>("peas/rPeas"));
            }
            else if (other.gameObject.transform.parent.tag == taglist[2])
            {
                _gameObject = Instantiate(Resources.Load<GameObject>("peas/sPeas"));
            }
            _gameObject.transform.parent = other.gameObject.transform.parent.parent.transform;
            _gameObject.transform.position = new Vector3(other.transform.position.x, 0.2f, other.transform.position.z + 2);
            _gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
