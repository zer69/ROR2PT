using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public AbilityPool abilityPool;
}
