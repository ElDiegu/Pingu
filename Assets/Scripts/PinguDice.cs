using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinguDice : MonoBehaviour
{
    int[] secuencia = new int[30];
    int ronda = 1;
    int colorTurno = 0;
    float varandom;

    [SerializeField] GameObject[] ColorShine;
    [SerializeField] Button[] Pingus;
    [SerializeField] GameObject GameOverWindow;
    [SerializeField] GameObject SalirWindow;
    void Start()
    {
        ronda = 1;
        colorTurno = 0;
        for (int i = 0; i < 30; i++)
        {
            varandom = Random.Range(0f, 4f);
            secuencia[i] = (int) varandom;
        }
        StartCoroutine(PrintSecuencia());
    }

    // Update is called once per frame
    IEnumerator PrintSecuencia()
    {
        DeactivatePingus();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < ronda; i++)
        {
            yield return new WaitForSeconds(0.5f);
            print(secuencia[i]);
            ColorShine[secuencia[i]].SetActive(true);
            Vibrator.Vibrate(450);
            yield return new WaitForSeconds(0.5f);
            ColorShine[secuencia[i]].SetActive(false);
        }
        for (int i = 0; i < 4; i++)
        {
            Pingus[i].enabled = true;
        }
        ActivatePingus();
        colorTurno = 0;
        yield return null;
    }

    public void Color1Pressed()
    {
        StartCoroutine(ActivateShine(0));
        if (secuencia[colorTurno] == 0)
        {
            colorTurno++;
            print("Correct");
            ComprobateRonda();
        }
        else
        {
            GameOver();
        }
    }
    public void Color2Pressed()
    {
        StartCoroutine(ActivateShine(1));
        if (secuencia[colorTurno] == 1)
        {
            colorTurno++;
            print("Correct");
            ComprobateRonda();
        }
        else
        {
            GameOver();
        }
    }
    public void Color3Pressed()
    {
        StartCoroutine(ActivateShine(2));
        if (secuencia[colorTurno] == 2)
        {
            colorTurno++;
            print("Correct");
            ComprobateRonda();
        }
        else
        {
            GameOver();
        }
    }
    public void Color4Pressed()
    {
        StartCoroutine(ActivateShine(3));
        if (secuencia[colorTurno] == 3)
        {
            colorTurno++;
            print("Correct");
            ComprobateRonda();
        }
        else
        {
            GameOver();
        }
    }
    IEnumerator ActivateShine(int num)
    {
        ColorShine[num].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ColorShine[num].SetActive(false);
    }
    public void ComprobateRonda()
    {
        if(colorTurno >= ronda)
        {
            ronda++;
            StartCoroutine(PrintSecuencia());
        }
    }

    public void GameOver()
    {
        DeactivatePingus();
        Vibrator.Vibrate(700);
        GameOverWindow.SetActive(true);
    }
    public void VolverJugar()
    {
        ActivatePingus();
        GameOverWindow.SetActive(false);
        Start();
    }
    public void Salir()
    {
        DeactivatePingus();
        SalirWindow.SetActive(true);
        Time.timeScale = 0f;
    }
    public void SalirSi()
    {

    }
    public void SalirNo()
    {
        ActivatePingus();
        SalirWindow.SetActive(false);
        Time.timeScale = 1f;
    }
    public void DeactivatePingus()
    {
        for (int i = 0; i < 4; i++)
        {
            Pingus[i].enabled = false;
        }
    }
    public void ActivatePingus()
    {
        for (int i = 0; i < 4; i++)
        {
            Pingus[i].enabled = true;
        }
    }
}
