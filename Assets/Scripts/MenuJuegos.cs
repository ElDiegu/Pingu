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
        StartCoroutine(DisminuirEnergia());
    }
    public void BotonJuego1()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("PinguSlide");
        ActualizarSliders();
    }
    public void BotonJuego2()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("PinguDice");
        ActualizarSliders();
    }
    public void ActualizarSliders()
    {
        if(hambre.value >= 0)
        {
            hambre.value--;
        }
        if (energia.value <= 15)
        {
            energia.value++;
        }
    }
    IEnumerator DisminuirEnergia() 
    {
        while (true)
        {
            yield return new WaitForSeconds(300f);
            energia.value--;
        }
    }
}
