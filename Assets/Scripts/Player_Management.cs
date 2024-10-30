using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Management : MonoBehaviour
{
   
    public Material baseMaterial;
    public Material newMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("barrierBuffer"))
        {
            GetComponent<Renderer>().material = newMaterial;
        }
    }

    

}
