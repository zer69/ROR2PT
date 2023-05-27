using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout
{
    public string id;
    public string winRate = "N/A";
    public string bestTime = "N/A";
    public string averageTime = "N/A";
    public string winStreak = "0";
    public List<Record> recordList;


    public Loadout()
    {

    }
    
    public Loadout(string loadoutId)
    {
        id = loadoutId;
        recordList = new List<Record>();
    }

    public void UpdateBestTime()
    {
        int minTime = int.MaxValue;
        foreach(Record record in recordList)
        {
            if (record.dnf == false)
            {
                if (ParseRecord(record) < minTime)
                {
                    minTime = ParseRecord(record);
                }
                    
            }
               
        }
        if (minTime == int.MaxValue)
        {
            bestTime = "N/A";
            return;
        }
        bestTime = UnParseRecord(minTime);
    }

    public int ParseRecord(Record record)
    {
        string[] splitTime = record.time.Split(':');
        return int.Parse(splitTime[0]) * 60 + int.Parse(splitTime[1]);
    }

    private string UnParseRecord(int seconds)
    {
        return (seconds / 60).ToString() + ":" + ((seconds % 60) == 0 ? "00" : (seconds % 60).ToString());
    }

    public int MaxTime()
    {
        int maxTime = int.MinValue;
        foreach (Record record in recordList)
        {
            if (maxTime < ParseRecord(record))
                maxTime = ParseRecord(record);
        }

        return maxTime;
    }

    public int MinTime()
    {
        int minTime = int.MaxValue;
        foreach (Record record in recordList)
        {
            if (minTime > ParseRecord(record))
                minTime = ParseRecord(record);
        }

        return minTime;
    }

    public void UpdateAverageTime()
    {
        int total = 0;
        int wincount = 0;
        foreach(Record record in recordList)
        {
            if (record.dnf == false)
            {
                total += ParseRecord(record);
                wincount++;
            }
        }
        if (wincount == 0)
            return;
        averageTime = UnParseRecord(total / wincount);
    }

    public void UpdateWinRate()
    {
        int wins = 0;
        foreach (Record record in recordList)
        {
            if (record.dnf == false)
                wins++;
        }
        winRate = wins.ToString() + "/" + recordList.Count.ToString();
    }

    public void UpdateWinStreak()
    {
        int winStreaktmp = 0;
        foreach (Record record in recordList)
        {
            if (record.dnf)
                winStreaktmp = 0;
            else
                winStreaktmp++;
        }
        winStreak = winStreaktmp.ToString();
    }


    public void PrintLoadout()
    {
        Debug.Log(id);
        foreach (Record record in recordList)
            Debug.Log(record.time + " " + record.dnf);
        Debug.LogWarning(winRate);
        Debug.LogError(bestTime);
        Debug.LogError(averageTime);
    }
    
}
