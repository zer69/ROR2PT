using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveLoadout : MonoBehaviour
{
    public TMP_InputField runTime;
    public Toggle dnf;
    public LoadoutMono loadout;

    public LoadoutBase dataBase;

    public void SaveNewRecord()
    {
        if (!ValidateTime())
        {
            Debug.LogError("Time not valid!");
            return;
        }    
        loadout.loadout.recordList.Add(new Record(runTime.text, dnf.isOn));
        loadout.loadout.UpdateAverageTime();
        loadout.loadout.UpdateBestTime();
        loadout.loadout.UpdateWinRate();
        dataBase.AddLoadout(loadout.loadout);
        //loadout.loadout.PrintLoadout();
    }

    private bool ValidateTime()
    {
        if (runTime.text == null)
            return false;

        string tmpTime = runTime.text;
        string[] splitTime = tmpTime.Split(':');

        if (splitTime == null)
            return false;
        int validtmp;

        if (!(int.TryParse(splitTime[0], out validtmp)) || !(int.TryParse(splitTime[0], out validtmp)))
            return false;

        if ((int.Parse(splitTime[1]) > 59) || (int.Parse(splitTime[1]) < 0))
            return false;

        if (int.Parse(splitTime[0]) < 0)
            return false;



        return true;
    }

    



}
