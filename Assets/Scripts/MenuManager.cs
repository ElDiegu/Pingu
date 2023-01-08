using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int gameStartScene;
    [SerializeField] GameObject SalirWindow;
    [SerializeField] GameObject Ajustes;
    [SerializeField] Slider volume;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(gameStartScene);
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SalirWindow.SetActive(true);
    }
    public void BotonSI()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }

    public void BotonNO()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SalirWindow.SetActive(false);
    }
    public void Settings()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Ajustes.SetActive(true);
    }
    public void BotonVolver()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Ajustes.SetActive(false);
    }
    public void SliderVolumen()
    {
        FindObjectOfType<AudioManager>().UpdateVolume(volume.value);
    }
}