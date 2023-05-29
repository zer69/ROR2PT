using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadoutMono: MonoBehaviour
{
    public Loadout loadout;
    public TMP_Text bestTime;
    public TMP_Text avgTime;
    public TMP_Text winRate;
    public TMP_Text winStreak;
    public Graph graph;

    public void UpdateStats()
    {
        bestTime.text = loadout.bestTime;
        avgTime.text = loadout.averageTime;
        winRate.text = loadout.winRate;
        winStreak.text = loadout.winStreak;
        graph.ShowGraph(loadout);
    }

    public void PrintLoadout()
    {
        Debug.Log(loadout.id);
        Debug.Log(loadout.winRate);
        Debug.Log(loadout.bestTime);
        Debug.Log(loadout.averageTime);
        Debug.Log(loadout.winStreak);
        foreach (Record record in loadout.recordList)
            Debug.Log(record.time + " " + record.dnf);
    }
}
