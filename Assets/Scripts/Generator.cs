using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Generator : MonoBehaviour
{
    [SerializeField] private CharacterPool characterPool;
    [SerializeField] private GameObject abilityPrefab;

    private Transform character;
    private Transform abilities;
    private int characterId;
    private string loadoutId;

    private void Start()
    {
        character = transform.GetChild(0).GetChild(0);
        abilities = transform.GetChild(0).GetChild(1);
        Generate();


    }

    public void Generate()
    {
        loadoutId = "";
        RandomizeCharacter();
        RandomizeAbilities();
        transform.GetChild(0).GetComponent<Loadout>().id = loadoutId;
        
    }

    private void RandomizeCharacter()
    {
        characterId = Random.Range(0, characterPool.characterList.Count);
        character.GetChild(0).GetComponent<Image>().sprite = characterPool.characterList[characterId].sprite;
        character.GetChild(1).GetComponent<TMP_Text>().text = characterPool.characterList[characterId].name;
        loadoutId += characterPool.characterList[characterId].name;
    }

    private void RandomizeAbilities()
    {
        foreach (Transform ability in abilities)
            GameObject.Destroy(ability.gameObject);
        GameObject tmpAbility;
        AbilityPool abilityPool = characterPool.characterList[characterId].abilityPool;
        int abilityIndex;

        if (abilityPool.miscellaneousList.Count > 0)
        {
            abilityIndex = Random.Range(0, abilityPool.miscellaneousList.Count);
            tmpAbility = Instantiate(abilityPrefab, abilities);
            tmpAbility.GetComponent<Image>().sprite = abilityPool.miscellaneousList[abilityIndex];
            loadoutId += abilityPool.miscellaneousList[abilityIndex].name;
        }

        if (characterId == 3)
        {
            abilityIndex = Random.Range(0, abilityPool.primaryList.Count);
            tmpAbility = Instantiate(abilityPrefab, abilities);
            tmpAbility.GetComponent<Image>().sprite = abilityPool.primaryList[abilityIndex];
            loadoutId += abilityPool.primaryList[abilityIndex].name;
        }
        abilityIndex = Random.Range(0, abilityPool.primaryList.Count);
        tmpAbility = Instantiate(abilityPrefab, abilities);
        tmpAbility.GetComponent<Image>().sprite = abilityPool.primaryList[abilityIndex];
        loadoutId += abilityPool.primaryList[abilityIndex].name;

        abilityIndex = Random.Range(0, abilityPool.secondaryList.Count);
        tmpAbility = Instantiate(abilityPrefab, abilities);
        tmpAbility.GetComponent<Image>().sprite = abilityPool.secondaryList[abilityIndex];
        loadoutId += abilityPool.secondaryList[abilityIndex].name;

        abilityIndex = Random.Range(0, abilityPool.utilityList.Count);
        tmpAbility = Instantiate(abilityPrefab, abilities);
        tmpAbility.GetComponent<Image>().sprite = abilityPool.utilityList[abilityIndex];
        loadoutId += abilityPool.utilityList[abilityIndex].name;

        abilityIndex = Random.Range(0, abilityPool.specialList.Count);
        tmpAbility = Instantiate(abilityPrefab, abilities);
        tmpAbility.GetComponent<Image>().sprite = abilityPool.specialList[abilityIndex];
        loadoutId += abilityPool.specialList[abilityIndex].name;


    }
}
