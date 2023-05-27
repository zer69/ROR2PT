using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutBase : MonoBehaviour, IDataPersistence
{
    public Dictionary<string, Loadout> loadoutTable = new Dictionary<string, Loadout>();

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

    public void LoadData(ClientData data)
    {
        this.loadoutTable = data.loadoutDataBase;
    }

    public void SaveData(ref ClientData data)
    {
        data.loadoutDataBase = this.loadoutTable;
    }
}
