using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NandGate : LogicGate
{
    public void FixedUpdate()
    {
        //computeNand(inputs[0], inputs[1], outputs[0]);
    }

    public void computeNand(WireArc in0, WireArc in1, WireArc out0)
    {
        if (in0.charge && in1.charge ) { outValue = false; }
        else { outValue = true; }

        //sendOutput();
    }
}
