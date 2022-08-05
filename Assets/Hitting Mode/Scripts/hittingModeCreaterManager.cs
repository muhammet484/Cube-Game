using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittingModeCreaterManager : MonoBehaviour
{
    [SerializeField] float oluşmaSıklığı = 0.5f;
    [SerializeField] GameObject[] kupler;

    [SerializeField] GameObject solDirek;
    [SerializeField] GameObject sagDirek;
    void Start()
    {
        InvokeRepeating("create", 0.0f, oluşmaSıklığı);
    }
    void create()
    {
        Instantiate(kupler[Random.Range(0, kupler.Length)], new Vector3
            (Random.Range(solDirek.transform.position.x + 1f, sagDirek.transform.position.x - 1f)
            , 7, 0), Quaternion.identity);
    }
}
