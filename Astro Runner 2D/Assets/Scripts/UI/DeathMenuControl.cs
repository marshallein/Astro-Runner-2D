using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuControl: MonoBehaviour
{

    public string mainMenu;

    public void restartGame()
    {
        FindObjectOfType<GameManager>().ResetScene();
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
    }


}
