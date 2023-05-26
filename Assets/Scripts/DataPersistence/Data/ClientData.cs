using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClientData
{
    public Dictionary<string, Loadout> loadoutDataBase;

    public ClientData()
    {
        this.loadoutDataBase = new Dictionary<string, Loadout>();
    }
}
