using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideController : MonoBehaviour
{
    private Text text;

    public Text Text { get => text; set => text = value; }

    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = "";
    }

    public void SetTextGuide(string name, string type)
    {
        Text.text = "Utiliser ";
        switch(type)
        {
            case "ingrédient":
                Text.text += name + " avec ...";
                break;
            case "ustensile":
                Text.text += name + " avec ...";
                break;
            case "électroménager":
                Text.text += name;
                break;
            default:
                Debug.LogError("The type of the item " + name + " do not exist !" );
                break;
        }
    }

    public void ResetTextGuide() => Text.text = "";
}
