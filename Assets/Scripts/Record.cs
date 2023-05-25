using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record
{
    public bool dnf;
    public string time;

    public Record()
    {

    }

    public Record(string _time, bool _dnf)
    {
        dnf = _dnf;
        time = _time;
    }

}
