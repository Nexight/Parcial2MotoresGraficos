using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Management : MonoBehaviour
{
   
    public Material baseMaterial;
    public Material newMaterial;

    public GameObject MenuGanaste;

    private bool conBarrera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("barrierBuffer"))
        {
            GetComponent<Renderer>().material = newMaterial;
            conBarrera = true;
        }
        if (other.CompareTag("Portal"))
        {
            MenuGanaste.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("enemigo"))
        {
            if(conBarrera)
            {
                conBarrera = false;
                GetComponent<Renderer>().material = baseMaterial;
                
            }
            else
            {
                Destroy(gameObject);
                
            }
        }
    }

}
