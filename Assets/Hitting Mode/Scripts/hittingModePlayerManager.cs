using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittingModePlayerManager : MonoBehaviour
{
    [SerializeField] float hiz = 10f;
    KeyCode A = KeyCode.A;
    KeyCode D = KeyCode.D;
    KeyCode W = KeyCode.W;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(D))
        {
            rb.velocity = new Vector3(hiz, 0, 0);
        }

        if (Input.GetKey(A))
        {
            rb.velocity = new Vector3(-hiz, 0, 0);
        }
        if (!Input.GetKey(A) && !Input.GetKey(D))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(W) && transform.position.y <-2)
        {
            rb.velocity = new Vector3(rb.velocity.x, 50, rb.velocity.z);
        }
        if (Input.GetKeyUp(W))
        {
            transform.position = new Vector3 (transform.position.x, -2.5f, transform.position.z);
        }
    }
}
