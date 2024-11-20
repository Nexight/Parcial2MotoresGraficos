using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Management : MonoBehaviour
{
    private Player_Controller playerController;

    public Material baseMaterial;
    public Material newMaterial;
    public GameObject MenuGanaste;

    public float intervaloDeActivacion = 1f;
    private float ultimaActivacion = 0f;
    private bool conBarrera;
    void Start()
    {
        playerController = GetComponent<Player_Controller>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("barrierBuffer"))
        {
            GetComponent<Renderer>().material = newMaterial;
            conBarrera = true;
        }
        if(other.CompareTag("dashBuff"))
        {
            playerController.DashEnabler();
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
        if (Time.time >= ultimaActivacion + intervaloDeActivacion)
        {
            if (collision.collider.CompareTag("enemigo"))
            {
         
                if (conBarrera)
                {
                    Collider.Destroy(gameObject);

                    conBarrera = false;
                    GetComponent<Renderer>().material = baseMaterial;
                }
                else
                {
                    Destroy(gameObject);

                }
                ultimaActivacion = Time.time;
            }
        }
    }

}
