using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class AbilityPool : ScriptableObject
{
    public List<Sprite> miscellaneousList;
    public List<Sprite> primaryList;
    public List<Sprite> secondaryList;
    public List<Sprite> utilityList;
    public List<Sprite> specialList;
}
