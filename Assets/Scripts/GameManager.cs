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
        StringBuilder colorList = new StringBuilder();
        StringBuilder eyeList = new StringBuilder();
        StringBuilder hatList = new StringBuilder();

        PlayerPrefs.SetInt("savedData", 1);
        PlayerPrefs.SetInt("coins", coins);

        

        foreach (KeyValuePair<Material, bool> color in bodyColor) if (color.Value == true) { colorList.Append(Instance.auxiliarBodyColor.IndexOf(color.Key) + "\n"); Debug.Log("Color saved: " + Instance.auxiliarBodyColor.IndexOf(color.Key)); }
        PlayerPrefs.SetString("bodyColor", colorList.ToString());
        Debug.Log(colorList.ToString());

        
        foreach (KeyValuePair<Material, bool> eye in eyes) if (eye.Value == true) { eyeList.Append(Instance.auxiliarEyes.IndexOf(eye.Key) + "\n"); Debug.Log("Eye saved: " + Instance.auxiliarEyes.IndexOf(eye.Key)); }
        PlayerPrefs.SetString("eyes", eyeList.ToString());
        Debug.Log(eyeList.ToString());

        
        foreach (KeyValuePair<int, bool> hat in hats) if (hat.Value == true) { hatList.Append(hat.Key + "\n"); Debug.Log("Hat saved: " + hat.Key); }
        PlayerPrefs.SetString("hats", hatList.ToString());
        Debug.Log (hatList.ToString());

        Debug.Log("Saved data");
    }
    private static void LoadData()
    {
        if (!PlayerPrefs.HasKey("savedData")) return;
        Debug.Log("Loading data");

        coins = PlayerPrefs.GetInt("coins");

        string[] colorList = PlayerPrefs.GetString("bodyColor").Split("\n");
        for(int i = 0; i < colorList.Length - 1; i++)
        {
            bodyColor[Instance.auxiliarBodyColor[int.Parse(colorList[i])]] = true;
            Debug.Log("Body Color activated: " + Instance.auxiliarBodyColor[int.Parse(colorList[i])]);
        }

        foreach(KeyValuePair<Material, bool> color in bodyColor) Debug.Log(color.Key + ":" + color.Value);

        string[] eyeList = PlayerPrefs.GetString("eyes").Split("\n");
        Debug.Log(eyeList.Length);
        for (int i = 0; i < eyeList.Length - 1; i++)
        {
            eyes[Instance.auxiliarEyes[int.Parse(eyeList[i])]] = true;
            Debug.Log("Eye activated: " + Instance.auxiliarEyes[int.Parse(eyeList[i])]);
        }

        string[] hatList = PlayerPrefs.GetString("hats").Split("\n");
        for (int i = 0; i < hatList.Length - 1; i++)
        {
            hats[int.Parse(hatList[i])] = true;
            Debug.Log("Hat activated: " + hats[int.Parse(hatList[i])]);
        }

        foreach (KeyValuePair<int, bool> hat in hats) Debug.Log(hat.Key + ":" + hat.Value);
    }
}
