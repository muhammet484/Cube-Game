using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *küpleri y=7'de 3/1 oranla seçilerek x'i -9 ve +9 (int) arasında oluştur.
 *yeni oluşturulacak küp 2 saniye sonra oluşsun.
 */

public class CreaterManager : MonoBehaviour
{
    [SerializeField] float oluşmaSıklığı = 2.0f;
    [SerializeField] GameObject[] kupler;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("create", 0.0f, oluşmaSıklığı);
    }
    void create()
    {
        Instantiate(kupler[Random.Range(0,kupler.Length)], new Vector3(Random.Range(-6.5f,6.5f),7,0), Quaternion.identity);
    }
}
