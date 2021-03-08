using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class JsonParser : MonoBehaviour
{
    private string jsonContent;
    private Dictionary<string, Item> itemsDictionary;

    public Dictionary<string, Item> ItemsDictionary { get => itemsDictionary; }

    private void Awake()
    {
        InitializeJson();
        ParseItems();
    }

    public void ParseItems()
    {
        itemsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Item>>(jsonContent);
    }

    public void InitializeJson()
    {
        string jsonFilePath = "Assets/Data/objets.json";
        jsonContent = File.ReadAllText(jsonFilePath);
    }
}
