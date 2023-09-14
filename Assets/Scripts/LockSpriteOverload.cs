using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockSpriteOverload : MonoBehaviour
{
    private Toggle toggle;
    private Image img;
    
    private void Start()
    {
        img = GetComponent<Image>();
        toggle = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            TweakAlpha(0f);
        }
        else
            TweakAlpha(1f);
    }

    void TweakAlpha(float alphaValue)
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, alphaValue);
    }
}
