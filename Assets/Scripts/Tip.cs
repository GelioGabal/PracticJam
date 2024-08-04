using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Tip : MonoBehaviour
{
    public static UnityEvent<string, string> Show = new();
    public static UnityEvent Close = new();
    [SerializeField] int maxSymInLine = 40;
    [SerializeField] RectTransform canvasRect;
    [SerializeField] TMP_Text NameField, TextField;
    [SerializeField] Transform TipTransform;
    RectTransform rect;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
        Show.AddListener(showTip);
        Close.AddListener(closeTip);
    }
    void showTip(string name, string text)
    {
        string description = "";
        int i = 0;
        foreach (var sym in text)
        {
            description += sym.ToString();
            if (sym == '\n') i = 0;
            if (i > maxSymInLine && sym == ' ')
            {
                description += '\n';
                i = 0;
            }
            i++;
        }
        NameField.SetText(name);
        NameField.ForceMeshUpdate();
        TextField.SetText(description);
        TextField.ForceMeshUpdate();

        Vector2 textSize = TextField.GetRenderedValues(false);
        Vector2 nameSize = NameField.GetRenderedValues(false);
        Vector2 paddingSize = new Vector2(50, 80);
        if (textSize.x < nameSize.x) textSize = new Vector2(nameSize.x, textSize.y);
        rect.sizeDelta = textSize + paddingSize;
        TipTransform.gameObject.SetActive(true);
    }
    void closeTip()
    {
        TipTransform.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasRect.localScale.x;
        anchoredPosition.x += 50f;
        anchoredPosition.y -= 40f;

        if (anchoredPosition.x + rect.rect.width > canvasRect.rect.width)
        {
            //anchoredPosition.x = canvasRect.rect.width - rect.rect.width;
        }
        if (anchoredPosition.y + rect.rect.height > canvasRect.rect.height)
        {
            anchoredPosition.y = canvasRect.rect.height - rect.rect.height;
        }
        if (Input.mousePosition.x > Screen.width / 2f) anchoredPosition.x -= rect.rect.width + 100f;
        rect.anchoredPosition = anchoredPosition;
    }
}
