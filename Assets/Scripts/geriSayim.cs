using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class geriSayim : MonoBehaviour
{
    [SerializeField] GameObject creater;
    // Start is called before the first frame update
    private void Awake()
    {
        creater.SetActive(false);
    }
    void Start()
    {
        InvokeRepeating("geriSay", 1f, 1f);
    }
    void geriSay()
    {
        GetComponent<Text>().text = (Convert.ToInt32(GetComponent<Text>().text) - 1).ToString();

        if ((Convert.ToInt32(GetComponent<Text>().text) == 0)){
            creater.SetActive(true);
            Destroy(gameObject);
        }
    }
}
