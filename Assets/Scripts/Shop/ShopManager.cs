using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [Header("Shop Canvas")]
    [SerializeField] private GameObject _shopCanvas;

    [Header("Shop Displays")]
    [SerializeField] private ChangeColor _changeColor;
    [SerializeField] private GameObject _buyButton;

    [Header("Original Cosmetics")]
    [SerializeField] private Material _color;
    [SerializeField] private Material _eye;
    [SerializeField] private int _hat;

    [Header("Coin Display")]
    [SerializeField] private TextMeshProUGUI _coinCounter;

    public void BuyColor(Material color)
    {
        if (GameManager.coins < 10) return;
        FindObjectOfType<AudioManager>().Play("BuyItem");
        GameManager.bodyColor[color] = true;
        GameManager.coins -= 10;
        _buyButton.SetActive(false);
    }

    public void BuyHat(int hat)
    {
        if (GameManager.coins < 20) return;
        FindObjectOfType<AudioManager>().Play("BuyItem");
        GameManager.hats[hat] = true;
        GameManager.coins -= 20;
        _buyButton.SetActive(false);
    }

    public void BuyEyes(Material material)
    {
        if (GameManager.coins < 5) return;
        FindObjectOfType<AudioManager>().Play("BuyItem");
        GameManager.eyes[material] = true;
        GameManager.coins -= 5;
        _buyButton.SetActive(false);
    }

    public void Buy()
    {
        switch (_changeColor.toggleCase)
        {
            case 0:
                BuyHat(GameManager.equipedHat);
                break;
            case 1:
                BuyColor(GameManager.equipedBody);
                break;
            case 2:
                BuyEyes(GameManager.equipedEyes);
                break;
            default:
                break;
        }

        GameManager.SaveData();
    }

    public void LeaveShop()
    {
        _shopCanvas.SetActive(false);
        SetDefaults();
    }

    public void DefaultColor()
    {
        GameManager.equipedBody = _color;
    }

    public void DefaultEye()
    {
        GameManager.equipedEyes = _eye;
    }

    public void DefaultHat()
    {
        GameManager.equipedHat = _hat;
    }

    public void GetDefaults()
    {
        _color = GameManager.equipedBody;
        _eye = GameManager.equipedEyes;
        _hat = GameManager.equipedHat;
    }

    public void SetDefaults()
    {
        if (GameManager.bodyColor[GameManager.equipedBody] == false) DefaultColor();
        if (GameManager.eyes[GameManager.equipedEyes] == false) DefaultEye();
        if (GameManager.hats[GameManager.equipedHat] == false) DefaultHat();
    }

    private void Update()
    {
        _coinCounter.text = GameManager.coins.ToString();
    }
}
