using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutMono: MonoBehaviour
{
    public Loadout loadout;

    public void AddRecord(Record src)
    {
        loadout.recordList.Add(src);
    }
}
