using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    [SerializeField] Image relleno;
    [SerializeField] Slider slider;
    public void updateColor()
    {
        if(slider.value < 5)
        {
            relleno.color = new Color32(240, 144, 126, 255);
        }
        else
        {
            relleno.color = new Color(231, 231, 231, 255);
        }
    }
}