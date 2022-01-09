using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
     public GameObject pauseMenu;

    bool isPaused;
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
            
        }
    }


    public void PauseGame() {
        pauseMenu.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
