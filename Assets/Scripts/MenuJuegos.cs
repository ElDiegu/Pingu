using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJuegos : MonoBehaviour
{
    public void BotonJuego1()
    {

    }
    public void BotonJuego2()
    {
        SceneManager.LoadScene("PinguDice");
    }
}