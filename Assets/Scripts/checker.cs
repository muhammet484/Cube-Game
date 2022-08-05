using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//(Convert.ToInt32(skor.GetComponent<Text>().text) + 1).ToString()
public class checker : MonoBehaviour
{
    public bool iscollided = false;
    public bool iscalled = false;

    [SerializeField] Text skor;

    public void skorArttir()
    {
        skor.text = (Convert.ToInt32(skor.text) + 1).ToString();
    }
}
