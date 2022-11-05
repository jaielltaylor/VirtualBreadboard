using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : LogicGate
{
    public void FixedUpdate()
    {
        //computeNot(inputs[0], outputs[0]);
    }
    public void computeNot(WireArc in0, WireArc out0)
    {
        if (!in0.charge) { outValue = true; }
        else { outValue = false; }

        //sendOutput();
    }
}
