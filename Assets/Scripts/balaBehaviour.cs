using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaBehaviour : MonoBehaviour
{
    private void onColissionEnter(Collision collider)
    {
        if(collider.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
