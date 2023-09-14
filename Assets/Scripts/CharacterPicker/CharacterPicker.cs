using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPicker : MonoBehaviour
{
    [SerializeField] int pickedCharacter;
    [SerializeField] private Color highlightColor;
    [SerializeField] private Color deselectColor;
    [SerializeField] private Generator generator;
    [SerializeField] private Button rollButton;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePickedColorOnRoll();
    }

    public void SetPickedCharacter(int chr)
    {
        pickedCharacter = chr;
        UpdatePickedColor();
        rollButton.interactable = true;

    }

    private void UpdatePickedColor()
    {
        foreach (Transform child in transform)
        {
            child.GetChild(0).GetComponent<Image>().color = new Color(deselectColor.r, deselectColor.g, deselectColor.b, 0.5f);
            if (pickedCharacter == child.GetSiblingIndex())
            {
                child.GetChild(0).GetComponent<Image>().color = new Color(highlightColor.r, highlightColor.g, highlightColor.b, 0.5f);
            }
        }

    }

    public void UpdatePickedColorOnRoll()
    {
        foreach (Transform child in transform)
            child.GetChild(0).GetComponent<Image>().color = new Color(deselectColor.r, deselectColor.g, deselectColor.b, 0.5f);
    }

    public void GenerateNewCharacter()
    {
        generator.Generate(pickedCharacter);
    }

    public void ResetPicker()
    {
        pickedCharacter = -1;
        rollButton.interactable = false;
    }
}
