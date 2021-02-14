using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [System.Serializable]
    public class Clefs
    {
        public int x;
        public int y;
    }

    [System.Serializable]
    public class Image 
    { 
        public string src;
        public int dimX;
        public int dimY;
        public Clefs clefs;
    }

    public string nom;
    public string type;
    public string[] etats;
    public int x;
    public int y;
    public bool mobile;
    public Image image;

    public static Item CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Item>(jsonString);
    }
}
