using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public int abilitySlot;
    [SerializeField] private Generator generator;
    [SerializeField] private Toggle lockAbility;

    private void Awake()
    {
        
        
        lockAbility = transform.GetChild(1).GetComponent<Toggle>();
        lockAbility.interactable = false;
        generator = GameObject.FindObjectOfType<Generator>();
        
    }

    public void SetAbilityLocked()
    {
        generator.LockAbilities(lockAbility.isOn, abilitySlot);
    }

    private void Update()
    {
        //generator.LockAbilities(lockAbility.isOn, abilitySlot);
    }

    
    
    

    

}
