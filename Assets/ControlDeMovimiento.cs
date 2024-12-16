using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeMovimiento : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
   

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale += new Vector3(1f, 1f, 0f);
        }
    }
}
