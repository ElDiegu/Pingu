using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int gameStartScene;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void playSlider()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
    public void playSoundClick()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}