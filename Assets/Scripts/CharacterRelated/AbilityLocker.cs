using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLocker : MonoBehaviour
{
    

    public void UpdateLocks()
    {
        bool state = GameObject.Find("LockCharacter").GetComponent<Toggle>().isOn;
        foreach (Transform child in transform)
        {
            if (!state && child.GetChild(1).GetComponent<Toggle>().isOn)
                child.GetChild(1).GetComponent<Toggle>().isOn = false;
            child.GetChild(1).GetComponent<Toggle>().interactable = state;
        }
    }
}
