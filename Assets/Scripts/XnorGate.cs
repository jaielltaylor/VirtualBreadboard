using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XnorGate : LogicGate
{
    public void FixedUpdate()
    {
        //computeXnor(inputs[0], inputs[1], outputs[0]);
    }

    public void computeXnor(WireArc in0, WireArc in1, WireArc out0)
    {
        if (in0.charge && in1.charge) { outValue = true; }
        else if (!in0.charge && !in1.charge) { outValue = true; }
        else { outValue = false; }

        //sendOutput();
    }
}
