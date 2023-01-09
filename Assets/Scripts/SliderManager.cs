using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider energy;
    [SerializeField] private Slider hunger;
    [SerializeField] private Slider volume;

    private void Start()
    {
        StartCoroutine(EnergyCountdown());
        volume.value = FindObjectOfType<AudioManager>().GetFloatVolume();
    }
    void Update()
    {
        energy.value = GameManager.energy;
        hunger.value = GameManager.hunger;
    }

    IEnumerator EnergyCountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(300f);
            GameManager.energy = Mathf.Clamp(GameManager.energy - 1, 0, 15);
        }
    }

    public void HungerDown()
    {
        GameManager.hunger = Mathf.Clamp(GameManager.hunger - 1, 0, 15);
    }

    public void EnergyUp()
    {
        GameManager.energy = Mathf.Clamp(GameManager.energy + 1, 0, 15);
    }

    public void HungerUp()
    {
        GameManager.hunger = Mathf.Clamp(GameManager.hunger + 5, 0, 15);
    }

    public void SliderVolumen()
    {
        FindObjectOfType<AudioManager>().UpdateVolume(volume.value);
    }
}
