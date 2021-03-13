using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private JsonParser jsonParser;

    private void Start()
    {
        jsonParser = GameObject.Find("GameManager").GetComponent<JsonParser>();
        foreach (Item item in jsonParser.ItemsDictionary.Values)
        {
            InitializeGameObject(item, out GameObject currentGameObject);
            SetItemRectTransform(item, currentGameObject);
            currentGameObject.GetComponent<Button>().onClick.AddListener(delegate { OnClicItemBehaviour(item, currentGameObject); });
            currentGameObject.GetComponent<ItemBehaviour>().ItemProperties = item;
        }
    }

    private void OnClicItemBehaviour(Item item, GameObject currentGameObject)
    {
        StartCoroutine(currentGameObject.GetComponent<ItemBehaviour>().ChangeItemStatus());
    }

    private static void InitializeGameObject(Item item, out GameObject currentGameObject)
    {
        currentGameObject = new GameObject(item.nom);
        currentGameObject.transform.parent = GameObject.Find("Canvas").transform;
        AddComponentsToGameObject(currentGameObject);        
    }

    private static void AddComponentsToGameObject(GameObject currentGameObject)
    {
        currentGameObject.AddComponent<RectTransform>();
        currentGameObject.AddComponent<Image>();
        currentGameObject.AddComponent<Button>();
        currentGameObject.AddComponent<ItemBehaviour>();
    }

    private static void SetItemRectTransform(Item item, GameObject currentGameObject)
    {
        currentGameObject.GetComponent<RectTransform>().localPosition = new Vector3(item.x, -item.y, 0);
        currentGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(item.image.dimX, item.image.dimY);
        currentGameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 1f);
        currentGameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 1f);
        currentGameObject.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
    }
}
