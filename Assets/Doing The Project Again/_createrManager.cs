using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *küpleri y=7'de küpSayısı/1 oranla seçilerek x'i -9 ve +9 (float) arasında oluştur.
 *her yeni oluşturulacak küp 0,5 saniye sonra oluşsun.
 */
public class _createrManager : MonoBehaviour
{
    [SerializeField] GameObject[] kupler;

    [SerializeField] float creatingTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("create", 0.0f, creatingTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void create()
    {
        Instantiate(kupler[Random.Range(0, kupler.Length)], new Vector3(Random.Range(-9f, 9f), 7, 0), Quaternion.identity);
    }
    
}
