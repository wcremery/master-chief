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
            SetItemImage(item, currentGameObject);
            SetItemRectTransform(item, currentGameObject);
            currentGameObject.GetComponent<Button>().onClick.AddListener(delegate { StartCoroutine(PrintMyName(item, currentGameObject)); });
        }
    }

    private IEnumerator PrintMyName(Item item, GameObject currentGameObject)
    {
        Debug.Log(item.nom);
        yield return null;
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
    }

    private static void SetItemImage(Item item, GameObject currentGameObject)
    {
        Sprite currentSprite = Resources.Load<Sprite>(item.image.src);
        
        currentGameObject.GetComponent<Image>().sprite = Sprite.Create(currentSprite.texture, new Rect(.0f, .0f, item.image.dimX, item.image.dimY), new Vector2(.0f, .0f));
    }

    private static void SetItemRectTransform(Item item, GameObject currentGameObject)
    {
        currentGameObject.GetComponent<RectTransform>().localPosition = new Vector3(item.x, -item.y, 0);
        currentGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(item.image.dimX, item.image.dimY);
        currentGameObject.GetComponent<RectTransform>().anchorMin = new Vector2(.0f, 1f);
        currentGameObject.GetComponent<RectTransform>().anchorMax = new Vector2(.0f, 1f);
        currentGameObject.GetComponent<RectTransform>().pivot = new Vector2(.0f, 1f);               
    }
}
