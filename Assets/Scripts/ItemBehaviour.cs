using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    private GuideController guide;

    private Item itemProperties;
    private Sprite spriteSheet;
    private Image spriteActive;
    private int spriteIndexOnWidth = 0;
    private int spriteIndexOnHeight = 0;
    private int nStatus;

    private string status;
    private int statusIndex;

    public Item ItemProperties { get => itemProperties; set => itemProperties = value; }

    // Start is called before the first frame update
    void Start()
    {
        spriteActive = gameObject.GetComponent<Image>();
        spriteSheet = Resources.Load<Sprite>(ItemProperties.image.src);
        nStatus = ItemProperties.etats.Length;
        guide = transform.parent.Find("Guide").GetComponent<GuideController>();
        SetInitialeSprite();
    }

    private void SetInitialeSprite()
    {
        Rect spriteRect = CutSprite();
        spriteActive.sprite = Sprite.Create(spriteSheet.texture, spriteRect, new Vector2(0f, 1f));
        if (spriteIndexOnHeight > 1) ++statusIndex;
        Debug.Log(ItemProperties.nom + "\n" + spriteRect);
    }

    public IEnumerator ChangeItemStatus()
    {
        status = ItemProperties.etats[statusIndex];
        ChangeSprite();
        Debug.Log(status);
        yield return null;
    }

    private void ChangeSprite()
    {
        Rect spriteRect = CutSprite();
        spriteActive.sprite = Sprite.Create(spriteSheet.texture, spriteRect, new Vector2(0f, 0f));
    }

    private Rect CutSprite()
    {
        int sheetPositionOnWidth = spriteIndexOnWidth * ItemProperties.image.dimX;
        int sheetPositionOnHeight = spriteIndexOnHeight * ItemProperties.image.dimY;

        spriteIndexOnWidth = (spriteIndexOnWidth + 1) % ItemProperties.image.clefs.x;
        spriteIndexOnHeight = (spriteIndexOnHeight + 1) % ItemProperties.image.clefs.y;
        statusIndex = (statusIndex + 1) % nStatus;

        Debug.Log(ItemProperties.nom + "\nposX : " + sheetPositionOnWidth + " posY : " + sheetPositionOnHeight);

        return new Rect(sheetPositionOnWidth, sheetPositionOnHeight, ItemProperties.image.dimX, ItemProperties.image.dimY);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        guide.ResetTextGuide();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        guide.SetTextGuide(ItemProperties.nom, ItemProperties.type);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.localPosition = Input.mousePosition;
    }
}
