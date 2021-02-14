using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private JsonParser jsonParser;

    private void Start()
    {
        jsonParser = GameObject.Find("GameManager").GetComponent<JsonParser>();
        foreach (Item item in jsonParser.ItemsDictionary.Values)
        {
            GameObject currentItem = new GameObject(item.nom, typeof(SpriteRenderer));
            SpriteRenderer spriteRendererItem = currentItem.GetComponent<SpriteRenderer>();

            currentItem.transform.position = new Vector2(item.x, item.y);
            currentItem.transform.localScale = new Vector2(item.image.dimX, item.image.dimY);
            spriteRendererItem.sprite = Resources.Load<Sprite>(item.image.src);
            spriteRendererItem.sortingLayerName = "Game";
        }
    }
}
