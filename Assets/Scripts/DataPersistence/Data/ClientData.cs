using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClientData
{
    public SerializableDictionary<string, Loadout> loadoutDataBase;

    public ClientData()
    {
        this.loadoutDataBase = new SerializableDictionary<string, Loadout>();
    }
}
