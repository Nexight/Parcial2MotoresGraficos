using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MenuPausa : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject MenuPausaUI;

    // public Camera camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Reanudar();
            } else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pausar()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void SalirJuego()
    {
        Debug.Log($"Saliste del juego!");
        Application.Quit();
    }

    public void CargarMenu()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    
}
