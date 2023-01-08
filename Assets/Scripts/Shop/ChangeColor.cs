using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Material [] colores;
    public Material [] ojos;

    public GameObject pinguBody;
    public GameObject pinguFeet;
    public GameObject pinguPelo;
    public GameObject pinguOjos;
    
    public GameObject [] gorros;
    
    public  Toggle sombrero;
    public  Toggle color;

    private int indexColor = 0;
    private int indexOjos = 0;
    private int indexSombreros = 0; //si index == 4 no hay sombrero puesto

    public int toggleCase;

    [Header("Shop Manager")]
    [SerializeField] private ShopManager _shopManager;
    [SerializeField] private GameObject _buyButton;

    // Update is called once per frame
    public void changeColorizq()
    {
        //Comprobamos qué opción está seleccionada
        if(sombrero.isOn)
            toggleCase = 0;
        else if(color.isOn)
            toggleCase = 1;
        else
            toggleCase = 2;

        switch (toggleCase){
            case 0:
                //sombreros
                if(indexSombreros > 0 && indexSombreros <= 4)
                    indexSombreros--;
                else if (indexSombreros == 0)
                    indexSombreros = 4;

                /*
                if(indexSombreros != 4){
                    pinguPelo.SetActive(false);
                    for(int i = 0; i < 4; i++){
                        if(i == indexSombreros){
                            gorros[i].SetActive(true);
                            if(indexSombreros == 2){
                                pinguPelo.SetActive(true);
                            }
                        }else
                            gorros[i].SetActive(false);
                    }
                }else{
                    pinguPelo.SetActive(true);
                    for(int i = 0; i < 4; i++){
                        gorros[i].SetActive(false);
                    }
                }*/

                GameManager.equipedHat = indexSombreros;
                if (GameManager.hats[GameManager.equipedHat] == false) _buyButton.SetActive(true);
                else _buyButton.SetActive(false);

                break;
            case 1:
                //colores
                if(indexColor > 0 && indexColor <= 9)
                    indexColor--;
                else if (indexColor == 0)
                    indexColor = 9;

                /*
                pinguBody.GetComponent<Renderer>().material = colores[indexColor];
                pinguFeet.GetComponent<Renderer>().material = colores[indexColor];
                pinguPelo.GetComponent<Renderer>().material = colores[indexColor];
                */

                GameManager.equipedBody = colores[indexColor];
                if (GameManager.bodyColor[GameManager.equipedBody] == false) _buyButton.SetActive(true);
                else _buyButton.SetActive(false);

                break;
            case 2:
                //ojos
                if(indexOjos > 0 && indexOjos <= 3)
                    indexOjos--;
                else if (indexOjos == 0)
                    indexOjos = 3;

                //pinguOjos.GetComponent<Renderer>().material = ojos[indexOjos];

                GameManager.equipedEyes = ojos[indexOjos];
                if (GameManager.eyes[GameManager.equipedEyes] == false) _buyButton.SetActive(true);
                else _buyButton.SetActive(false);

                break;
        }

    }
    public void changeColordcha()
    {
        //Comprobamos qué opción está seleccionada
        if(sombrero.isOn)
            toggleCase = 0;
        else if(color.isOn)
            toggleCase = 1;
        else
            toggleCase = 2;
        switch (toggleCase){
            case 0:
                //sombreros
                if(indexSombreros >= 0 && indexSombreros < 4)
                    indexSombreros++;
                else if (indexSombreros == 4)
                    indexSombreros = 0;

                /*
                if(indexSombreros != 4){
                    pinguPelo.SetActive(false);
                    for(int i = 0; i < 4; i++){
                        if(i == indexSombreros){
                            gorros[i].SetActive(true);
                            if(indexSombreros == 2){
                                pinguPelo.SetActive(true);
                            }
                        }else
                            gorros[i].SetActive(false);
                    }
                }else{
                    pinguPelo.SetActive(true);
                    for(int i = 0; i < 4; i++){
                        gorros[i].SetActive(false);
                    }
                }*/

                GameManager.equipedHat = indexSombreros;
                if (GameManager.hats[GameManager.equipedHat] == false) _buyButton.SetActive(true);
                else _buyButton.SetActive(false);

                break;
            case 1:
                //colores
                if(indexColor >= 0 && indexColor < 9)
                    indexColor++;
                else if (indexColor == 9)
                    indexColor = 0;

                /*
                pinguBody.GetComponent<Renderer>().material = colores[indexColor];
                pinguFeet.GetComponent<Renderer>().material = colores[indexColor];
                pinguPelo.GetComponent<Renderer>().material = colores[indexColor];
                */

                GameManager.equipedBody = colores[indexColor];
                if (GameManager.bodyColor[GameManager.equipedBody] == false) _buyButton.SetActive(true);
                else _buyButton.SetActive(false);

                break;
            case 2:
                //ojos
                if(indexOjos >= 0 && indexOjos < 3)
                    indexOjos++;
                else if (indexOjos == 3)
                    indexOjos = 0;

                //pinguOjos.GetComponent<Renderer>().material = ojos[indexOjos];

                GameManager.equipedEyes = ojos[indexOjos];
                if (GameManager.eyes[GameManager.equipedEyes] == false) _buyButton.SetActive(true);
                else _buyButton.SetActive(false);

                break;
        }
    }
}
