using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(ClientData data);

    void SaveData(ref ClientData data);
}
