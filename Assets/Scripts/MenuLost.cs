using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuLost : MonoBehaviour
{
    public GameObject MenuLostUI;
    public void Perdiste()
    {
        MenuLostUI.SetActive(true);
        Time.timeScale = 0f;       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CargarLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
