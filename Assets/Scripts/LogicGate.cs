using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGate: MonoBehaviour
{
    public List<WireArc> inputs;
    public List<WireArc> outputs;
    public bool outValue;

    public bool GetValue()
    {
        if(!inputs[0].charge) { outValue = false; }
        else { outValue = true; }
        return outValue;
    }

    public List<WireArc> GetInputs() { return inputs; }

    public List<WireArc> GetOutputs() { return outputs; }

    public void sendOutput()
    {
        if (outputs != null)
        {
            for (int i = 0; i < outputs.Count; i++)
            {
                outputs[i].charge = outValue;
            }
        }
    }


}
