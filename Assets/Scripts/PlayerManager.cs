using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float hiz = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(hiz, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-hiz, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
