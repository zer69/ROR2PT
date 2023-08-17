using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Generator : MonoBehaviour
{
    [SerializeField] private CharacterPool characterPool;
    [SerializeField] private GameObject abilityPrefab;
    [SerializeField] private LoadoutBase loadoutBase;
    [SerializeField] private LoadoutMono loadoutContainer;
    public Graph graph;


    private Transform character;
    private Transform abilities;
    private int characterId;
    private string loadoutId;

    private bool characterLocked = false;

    private List<int> abilityList = new List<int>() {-1, -1, -1, -1, -1, -1, -1}; // misc, primary, primary, secondary, utility, special, special
    [SerializeField]private List<bool> lockedAbilities = new List<bool>() { false, false, false, false, false, false, false };

    private void Start()
    {
        //character = transform.GetChild(0).GetChild(0);
        //abilities = transform.GetChild(0).GetChild(1);

        character = transform.GetChild(1).GetChild(0).GetChild(0);
        abilities = transform.GetChild(1).GetChild(0).GetChild(1);
        Generate();


    }
    private void Update()
    {
        //Generate();
    }

    public bool getAbilityLockStatus(int abilitySlot)
    {
        return lockedAbilities[abilitySlot];
    }

    public void Generate()
    {
        loadoutId = "";
        RandomizeCharacter();
        RandomizeAbilities();
        if (loadoutBase.loadoutTable.ContainsKey(loadoutId))
            loadoutContainer.loadout = (Loadout)loadoutBase.loadoutTable[loadoutId];
        else
            loadoutContainer.loadout = new Loadout(loadoutId);
        graph.ShowGraph(loadoutContainer.loadout);
        loadoutContainer.UpdateStats();

    }

    private void RandomizeCharacter()
    {
        if (!characterLocked)
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
       

        if (abilityPool.miscellaneousList.Count > 0)
        {
            if (!lockedAbilities[0])
                abilityList[0] = Random.Range(0, abilityPool.miscellaneousList.Count);
            tmpAbility = Instantiate(abilityPrefab, abilities);
            tmpAbility.GetComponent<Image>().sprite = abilityPool.miscellaneousList[abilityList[0]];
            tmpAbility.GetComponent<Ability>().abilitySlot = 0;
            loadoutId += abilityPool.miscellaneousList[abilityList[0]].name;
        }
        if (!lockedAbilities[1])
            abilityList[1] = Random.Range(0, abilityPool.primaryList.Count);
        tmpAbility = Instantiate(abilityPrefab, abilities);
        tmpAbility.GetComponent<Image>().sprite = abilityPool.primaryList[abilityList[1]];
        tmpAbility.GetComponent<Ability>().abilitySlot = 1;
        loadoutId += abilityPool.primaryList[abilityList[1]].name;

        if (characterId == 3)
        {
            if (!lockedAbilities[2])
                abilityList[2] = Random.Range(0, abilityPool.primaryList.Count);
            tmpAbility = Instantiate(abilityPrefab, abilities);
            tmpAbility.GetComponent<Image>().sprite = abilityPool.primaryList[abilityList[2]];
            tmpAbility.GetComponent<Ability>().abilitySlot = 2;
            loadoutId += abilityPool.primaryList[abilityList[2]].name;
        }

        if (!lockedAbilities[3])
            abilityList[3] = Random.Range(0, abilityPool.secondaryList.Count);
        tmpAbility = Instantiate(abilityPrefab, abilities);
        tmpAbility.GetComponent<Image>().sprite = abilityPool.secondaryList[abilityList[3]];
        tmpAbility.GetComponent<Ability>().abilitySlot = 3;
        loadoutId += abilityPool.secondaryList[abilityList[3]].name;

        if (!lockedAbilities[4])
            abilityList[4] = Random.Range(0, abilityPool.utilityList.Count);
        tmpAbility = Instantiate(abilityPrefab, abilities);
        tmpAbility.GetComponent<Image>().sprite = abilityPool.utilityList[abilityList[4]];
        tmpAbility.GetComponent<Ability>().abilitySlot = 4;
        loadoutId += abilityPool.utilityList[abilityList[4]].name;


        if (!lockedAbilities[5])
            abilityList[5] = Random.Range(0, abilityPool.specialList.Count);
        tmpAbility = Instantiate(abilityPrefab, abilities);
        tmpAbility.GetComponent<Image>().sprite = abilityPool.specialList[abilityList[5]];
        tmpAbility.GetComponent<Ability>().abilitySlot = 5;
        loadoutId += abilityPool.specialList[abilityList[5]].name;

        if (characterId == 10)
        {
            if (!lockedAbilities[6])
                abilityList[6] = Random.Range(0, abilityPool.specialList.Count);
            tmpAbility = Instantiate(abilityPrefab, abilities);
            tmpAbility.GetComponent<Image>().sprite = abilityPool.specialList[abilityList[6]];
            tmpAbility.GetComponent<Ability>().abilitySlot = 6;
            loadoutId += abilityPool.specialList[abilityList[6]].name;
        }
        



    }

    public void LockCharacter(bool state)
    {
        characterLocked = state;
    }

    public void LockAbilities(bool state, int slot)
    {
        lockedAbilities[slot] = state;
    }
}
