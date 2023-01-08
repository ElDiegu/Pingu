using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Player Inventory")]
    public List<Material> auxiliarBodyColor;
    public static Dictionary<Material, bool> bodyColor = new Dictionary<Material, bool>();
    public List<Material> auxiliarEyes;
    public static Dictionary<Material, bool> eyes = new Dictionary<Material, bool>();
    public static Dictionary<int, bool> hats = new Dictionary<int, bool>();
    public static int coins;

    [Header("Pingu Equiped")]
    public static Material equipedBody;
    public static Material equipedEyes;
    public static int equipedHat;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetupInventory();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void SetupInventory()
    {
        foreach (Material material in auxiliarBodyColor) bodyColor.Add(material, false);
        foreach (Material material in auxiliarEyes) eyes.Add(material, false);
        for(int i = 0; i < 5; i++) hats.Add(i, false);

        bodyColor[auxiliarBodyColor[0]] = true;
        eyes[auxiliarEyes[0]] = true;
        hats[0] = true;

        coins = 40;
        SetupAppareance();
        LoadData();
    }
    private void SetupAppareance()
    {
        equipedBody = auxiliarBodyColor[0];
        Debug.Log(equipedBody);
        equipedEyes = auxiliarEyes[0];
        Debug.Log(equipedEyes);
        equipedHat = 0;
    }
    public static void SaveData()
    {
        PlayerPrefs.SetInt("savedData", 1);
        PlayerPrefs.SetInt("coins", coins);

        StringBuilder colorList = new StringBuilder();
        foreach (KeyValuePair<Material, bool> color in bodyColor) if(color.Value == true) colorList.Append(Instance.auxiliarBodyColor.IndexOf(color.Key) + "\n");
        PlayerPrefs.SetString("bodyColor", colorList.ToString());

        StringBuilder eyeList = new StringBuilder();
        foreach (KeyValuePair<Material, bool> eye in bodyColor) if (eye.Value == true) colorList.Append(Instance.auxiliarEyes.IndexOf(eye.Key) + "\n");
        PlayerPrefs.SetString("eyes", eyeList.ToString());

        StringBuilder hatList = new StringBuilder();
        foreach (KeyValuePair<int, bool> hat in hats) if (hat.Value == true) colorList.Append(hat.Key + "\n");
        PlayerPrefs.SetString("hats", hatList.ToString());
    }
    private static void LoadData()
    {
        if (!PlayerPrefs.HasKey("savedData")) return;

        coins = PlayerPrefs.GetInt("coins");

        string[] colorList = PlayerPrefs.GetString("bodyColor").Split("\n");
        for(int i = 0; i < colorList.Length - 1; i++)
        {
            bodyColor[Instance.auxiliarBodyColor[int.Parse(colorList[i])]] = true;
        }

        string[] eyeList = PlayerPrefs.GetString("eyes").Split("\n");
        for (int i = 0; i < eyeList.Length - 1; i++)
        {
            eyes[Instance.auxiliarEyes[int.Parse(eyeList[i])]] = true;
        }

        string[] hatList = PlayerPrefs.GetString("hats").Split("\n");
        for (int i = 0; i < hatList.Length - 1; i++)
        {
            hats[int.Parse(hatList[i])] = true;
        }
    }
}
