using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuJuegos : MonoBehaviour
{
    [SerializeField] Slider hambre;
    [SerializeField] Slider energia;
    private void Start()
    {
        
    }
    public void BotonJuego1()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("PinguSlide");
    }
    public void BotonJuego2()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("PinguDice");
    }
}
