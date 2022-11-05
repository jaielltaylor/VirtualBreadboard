using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad2InputXnor : Chip
{
    private XnorGate gates;
    void Start()
    {
        gates = GetComponent<XnorGate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chipIns[0] != null && chipIns[1] != null && chipOuts[0] != null)
        {
            gates.computeXnor(chipIns[0], chipIns[1], chipOuts[0]);
            transform.GetChild(5).GetComponent<pin>().charge = gates.outValue;
        }

        if (chipIns[2] != null && chipIns[3] != null && chipOuts[1] != null)
        {
            gates.computeXnor(chipIns[2], chipIns[3], chipOuts[1]);
            transform.GetChild(2).GetComponent<pin>().charge = gates.outValue;
        }

        if (chipIns[4] != null && chipIns[5] != null && chipOuts[2] != null)
        {
            gates.computeXnor(chipIns[4], chipIns[5], chipOuts[2]);
            transform.GetChild(8).GetComponent<pin>().charge = gates.outValue;
        }

        if (chipIns[6] != null && chipIns[7] != null && chipOuts[3] != null)
        {
            gates.computeXnor(chipIns[6], chipIns[7], chipOuts[3]);
            transform.GetChild(12).GetComponent<pin>().charge = gates.outValue;
        }
    }
}
