using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    public string mainMenu;
    public AudioSource pauseSound;

    public GameObject pauseMenu;
    
    public void PauseGame()
    {
        pauseSound.Play();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void restartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().ResetScene();
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
