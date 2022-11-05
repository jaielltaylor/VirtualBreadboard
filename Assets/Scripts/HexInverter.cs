using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexInverter : Chip
{
    private NotGate gates;
    public GameObject[] Pin;
    
    void Start()
    {
        gates = GetComponent<NotGate>();
    }

    void Update()
    {
        
        if (chipIns[0] != null && chipOuts[0] != null)
        {
            gates.computeNot(chipIns[0], chipOuts[0]);
            transform.GetChild(6).GetComponent<pin>().charge = gates.outValue;
        }

        if (chipIns[1] != null && chipOuts[1] != null)
        {
            gates.computeNot(chipIns[1], chipOuts[1]);
            transform.GetChild(3).GetComponent<pin>().charge = gates.outValue;
        }

        if (chipIns[2] != null && chipOuts[2] != null)
        {
            gates.computeNot(chipIns[2], chipOuts[2]);
            transform.GetChild(2).GetComponent<pin>().charge = gates.outValue;
        }

        if (chipIns[3] != null && chipOuts[3] != null)
        {
            gates.computeNot(chipIns[3], chipOuts[3]);
            transform.GetChild(8).GetComponent<pin>().charge = gates.outValue;
        }

        if (chipIns[4] != null && chipOuts[4] != null)
        {
            gates.computeNot(chipIns[4], chipOuts[4]);
            transform.GetChild(10).GetComponent<pin>().charge = gates.outValue;
        }

        if (chipIns[5] != null && chipOuts[5] != null)
        {
            gates.computeNot(chipIns[5], chipOuts[5]);
            transform.GetChild(10).GetComponent<pin>().charge = gates.outValue;
        }

    }
    
}
