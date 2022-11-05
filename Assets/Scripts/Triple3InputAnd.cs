using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple3InputAnd : Chip
{
    
    void Start()
    {

    }

    void Update()
    {
        if (chipIns[0] != null && chipIns[1] != null && chipIns[2] != null && chipOuts[0] != null)
        {
            computeTripleAnd(chipIns[0], chipIns[1], chipIns[2], chipOuts[0]);
            transform.GetChild(11).GetComponent<pin>().charge = chipOuts[0].charge;
        }

        if (chipIns[3] != null && chipIns[4] != null && chipIns[5] != null && chipOuts[1] != null)
        {
            computeTripleAnd(chipIns[3], chipIns[4], chipIns[5], chipOuts[1]);
            transform.GetChild(2).GetComponent<pin>().charge = chipOuts[1].charge;
        }

        if (chipIns[6] != null && chipIns[7] != null && chipIns[8] && chipOuts[2] != null)
        {
            computeTripleAnd(chipIns[6], chipIns[7], chipIns[8], chipOuts[2]);
            transform.GetChild(8).GetComponent<pin>().charge = chipOuts[2].charge;
        }
    }

    public void computeTripleAnd(WireArc in0, WireArc in1, WireArc in2, WireArc out0)
    {
        bool tempOut;

        if (in0.charge && in1.charge) { tempOut = true; }
        else { tempOut = false; }

        if (tempOut && in2.charge) { out0.charge = true; }
        else { out0.charge = false; }
    }
}
