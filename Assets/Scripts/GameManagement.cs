using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject player;
    public GameObject MenuLost;

    public GameObject[] pisos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Restart();
        CheckOnPlayer();
    }
    private void Restart()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    private void CheckOnPlayer()
    {
        if(player==null)
        {
            MenuLost.SetActive(true);
            Time.timeScale = 0f;           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
