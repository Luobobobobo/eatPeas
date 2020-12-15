using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerPrefs : MonoBehaviour
{
    public int i = 10;
    int m;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input .GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.SetInt("num", i);
        }
        if(Input.GetKeyDown (KeyCode.W))
        {
            m = PlayerPrefs.GetInt("num", i);
            Debug.Log(m);
        }
    }
}
