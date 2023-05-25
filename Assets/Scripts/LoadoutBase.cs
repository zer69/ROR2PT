using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutBase : MonoBehaviour
{
    public Hashtable loadoutTable = new Hashtable();

    public void AddLoadout(Loadout loadout)
    {
        if (loadoutTable.ContainsKey(loadout.id))
        {
            loadoutTable[loadout.id] = loadout;
        }
        else
        {
            loadoutTable.Add(loadout.id, new Loadout(loadout.id));
        }
    }
}
