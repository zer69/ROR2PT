using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLocker : MonoBehaviour
{
    [SerializeField] private Generator generator;

    public void UpdateLocks()
    {
        bool state = GameObject.Find("LockCharacter").GetComponent<Toggle>().isOn;
        foreach (Transform child in transform)
        {
            child.GetChild(1).GetComponent<Toggle>().interactable = state;
            if (!state && child.GetChild(1).GetComponent<Toggle>().isOn)
                child.GetChild(1).GetComponent<Toggle>().isOn = false;
            if (child.GetChild(1).GetComponent<Toggle>().interactable)
                child.GetChild(1).GetComponent<Toggle>().isOn = generator.getAbilityLockStatus(child.GetComponent<Ability>().abilitySlot);
        }
    }
}
