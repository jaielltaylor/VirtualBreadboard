using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XorGate : LogicGate
{
    public void FixedUpdate()
    {
        //computeXor(inputs[0], inputs[1], outputs[0]);
    }
    public void computeXor(WireArc in0, WireArc in1, WireArc out0)
    {
        if (in0.charge && in1.charge) { outValue = false; }
        else if (!in0.charge && !in1.charge) { outValue = false; }
        else { outValue = true; }

        //sendOutput();
    }
}
