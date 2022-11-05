using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MaximovInk;

public class pin : MonoBehaviour
{
    public bool charge;
    public bool isConnected = false;
    public int chipInIndex = 0;
    public int logicInstanceID = 0;

    public GameObject connectOut;
    public GameObject connectIn;
    public string parentName;

    public GameObject pinRow;

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<Chip>().newLogic != null)
        {
            configureID();
        }

        
        if(isConnected && GetComponentInParent<Chip>().newLogic != null)
        {
            
            //Make Gate untransparent
            if (GetComponentInParent<Chip>().newLogic.transform.childCount > 0 && (!name.Contains("GND") && !name.Contains("VCC")))
            {
                GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetComponent<RawImage>().color
                = new Color(GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetComponent<RawImage>().color.r,
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetComponent<RawImage>().color.g,
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetComponent<RawImage>().color.b, 1f);
            }
        }
        else if (!isConnected && GetComponentInParent<Chip>().newLogic != null)
        {
            //Make Gate transparent
            if (GetComponentInParent<Chip>().newLogic.transform.childCount > 0 && (!name.Contains("GND") && !name.Contains("VCC")))
            {
                GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetComponent<RawImage>().color
                = new Color(GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetComponent<RawImage>().color.r,
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetComponent<RawImage>().color.g,
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetComponent<RawImage>().color.b, 0.5f);
            }
        }
        

        if (connectOut != null && connectOut.GetComponentInParent<WireArc>().complete)
        {
            if (parentName.Contains("HexInverter"))
            {
                GetComponentInParent<HexInverter>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
            else if (parentName.Contains("Quad2InputAnd"))
            {
                GetComponentInParent<Quad2InputAnd>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
            else if (parentName.Contains("Quad2InputNand"))
            {
                GetComponentInParent<Quad2InputNand>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
            else if (parentName.Contains("Quad2InputNor"))
            {
                GetComponentInParent<Quad2InputNor>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
            else if (parentName.Contains("Quad2InputXor"))
            {
                GetComponentInParent<Quad2InputXor>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
            else if (parentName.Contains("Quad2InputXnor"))
            {
                GetComponentInParent<Quad2InputXnor>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
            else if (parentName.Contains("Quad2InputOr"))
            {
                GetComponentInParent<Quad2InputOr>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
            else if (parentName.Contains("Triple3InputAnd"))
            {
                GetComponentInParent<Triple3InputAnd>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
            else if (parentName.Contains("Triple3InputNand"))
            {
                GetComponentInParent<Triple3InputNand>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            }
        }

        if (pinRow != null && isConnected && (connectIn != null || connectOut != null))
        {
            operate();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("slotRow") && GetComponentInParent<Chip>().attachPoint != null)
        {
            pinRow = collision.gameObject;
            
            if (pinRow.GetComponent<slot>().peg != null)
            {
                Debug.Log("The peg exists at: " + name);
                if (pinRow.GetComponent<slot>().peg.CompareTag("PegOut") && !uniqueIdCheck(pinRow.GetComponent<slot>().peg.GetComponentInParent<WireArc>()))
                {
                    Debug.Log(transform.parent.name + " has a new Wire!");

                    connectIn = pinRow.GetComponent<slot>().peg;
                    isConnected = true;
                    connectIn.GetComponentInParent<WireArc>().uniqueID += 1;
                }
                else if (pinRow.GetComponent<slot>().peg.CompareTag("PegIn") && !uniqueIdCheck(pinRow.GetComponent<slot>().peg.GetComponentInParent<WireArc>()))
                {
                    Debug.Log(transform.parent.name + " has a new Wire!");

                    connectOut = pinRow.GetComponent<slot>().peg;
                    isConnected = true;
                    connectOut.GetComponentInParent<WireArc>().uniqueID += 1;
                }
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("slotRow") && GetComponentInParent<Chip>().attachPoint != null)
        {
            pinRow = collision.gameObject;
            if (pinRow.GetComponent<slot>().peg != null)
            {
                Debug.Log("The peg exists at: " + name);
                if (pinRow.GetComponent<slot>().peg.CompareTag("PegOut") && !uniqueIdCheck(pinRow.GetComponent<slot>().peg.GetComponentInParent<WireArc>()))
                {
                    Debug.Log(transform.parent.name + " has a new Wire!");

                    connectIn = pinRow.GetComponent<slot>().peg;
                    isConnected = true;
                    connectIn.GetComponentInParent<WireArc>().uniqueID += 1;
                }
                else if (pinRow.GetComponent<slot>().peg.CompareTag("PegIn") && !uniqueIdCheck(pinRow.GetComponent<slot>().peg.GetComponentInParent<WireArc>()))
                {
                    Debug.Log(transform.parent.name + " has a new Wire!");

                    connectOut = pinRow.GetComponent<slot>().peg;
                    isConnected = true;
                    connectOut.GetComponentInParent<WireArc>().uniqueID += 1;
                }
            }
        }
    }

    private bool uniqueIdCheck(WireArc wire)
    {
        if (wire.uniqueID != 0) { return true; }
        else { return false; }
    }

    void configureID()
    {
        NodeUI[] newNodes = GetComponentInParent<Chip>().newLogic.GetComponentsInChildren<NodeUI>();

        if (transform.parent.name.Contains("HexInverter"))
        {
            if (name.Contains("1")) { logicInstanceID = newNodes[0].instanceId; }
            else if (name.Contains("2")) { logicInstanceID = newNodes[1].instanceId; }
            else if (name.Contains("3")) { logicInstanceID = newNodes[2].instanceId; }
            else if (name.Contains("4")) { logicInstanceID = newNodes[3].instanceId; }
            else if (name.Contains("5")) { logicInstanceID = newNodes[4].instanceId; }
            else if (name.Contains("6")) { logicInstanceID = newNodes[5].instanceId; }
        }
        else if (transform.parent.name.Contains("Quad2Input"))
        {
            if (name.Contains("1")) { logicInstanceID = newNodes[0].instanceId; }
            else if (name.Contains("2")) { logicInstanceID = newNodes[1].instanceId; }
            else if (name.Contains("3")) { logicInstanceID = newNodes[2].instanceId; }
            else if (name.Contains("4")) { logicInstanceID = newNodes[3].instanceId; }
        }
        else if (transform.parent.name.Contains("Triple3Input"))
        {
            if (name.Contains("1") && (name.Contains("A") || name.Contains("B") || name.Contains("Y")))
            {
                logicInstanceID = newNodes[0].instanceId;
            }
            else if (name.Contains("1") && name.Contains("C")) { logicInstanceID = newNodes[1].instanceId; }
            else if (name.Contains("2") && (name.Contains("A") || name.Contains("B") || name.Contains("Y")))
            {
                logicInstanceID = newNodes[2].instanceId;
            }
            else if (name.Contains("2") && name.Contains("C")) { logicInstanceID = newNodes[3].instanceId; }
            else if (name.Contains("3") && (name.Contains("A") || name.Contains("B") || name.Contains("Y")))
            {
                logicInstanceID = newNodes[4].instanceId;
            }
            else if (name.Contains("3") && name.Contains("C")) { logicInstanceID = newNodes[5].instanceId; }
        }
    }

    void operate()
    {
        if (name.Contains("A") || name.Contains("B") || (name.Contains("C") && !name.Contains("V")))
        {
            if (transform.parent.name.Contains("HexInverter"))
            {
                GetComponentInParent<Chip>().chipIns[chipInIndex] = connectIn.GetComponentInParent<WireArc>();
                charge = connectIn.GetComponent<pegScript>().charge;

                //Show Wire on UI
                if (connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.CompareTag("slotOrigin")) //connected to switchboard
                {
                    PointOutUI newIn = connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.GetComponent<SwitchSlot>().origin.GetComponent<toggleswitch>().newLogic.GetComponentInChildren<PointOutUI>();
                    PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>();

                    if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                    else { newIn.Outs.Add(newOut); }
                    newOut.input = newIn;
                    if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().line == null)
                    {
                        GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().createLine(newIn, newOut);
                    }
                    else
                    {
                        GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().UpdateLine();
                    }
                }
                else if (connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.CompareTag("slotRow")) //connected to chip
                {
                    PointOutUI newIn = findPointOut();
                    PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>();

                    if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                    else { newIn.Outs.Add(newOut); }
                    newOut.input = newIn;
                    if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().line == null)
                    {
                        GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().createLine(newIn, newOut);
                    }
                    else
                    {
                        GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().UpdateLine();
                    }
                }

            }
            else if (transform.parent.name.Contains("Quad2"))
            {
                
                charge = connectIn.GetComponent<pegScript>().charge;

                //Show Wire on UI
                if (connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.CompareTag("slotOrigin")) //connected to switchboard
                {
                    if (name.Contains("A"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum()] = connectIn.GetComponentInParent<WireArc>();
                        PointOutUI newIn = connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.GetComponent<SwitchSlot>().origin.GetComponent<toggleswitch>().newLogic.GetComponentInChildren<PointOutUI>();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().UpdateLine();
                        }
                    }
                    else if (name.Contains("B"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum() + 1] = connectIn.GetComponentInParent<WireArc>();
                        PointOutUI newIn = connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.GetComponent<SwitchSlot>().origin.GetComponent<toggleswitch>().newLogic.GetComponentInChildren<PointOutUI>();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().UpdateLine();
                        }
                    }

                }
                else if (connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.CompareTag("slotRow")) //connected to chip
                {
                    if (name.Contains("A"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum()] = connectIn.GetComponentInParent<WireArc>();
                        PointOutUI newIn = findPointOut();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().UpdateLine();
                        }
                    }
                    else if (name.Contains("B"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum() + 1] = connectIn.GetComponentInParent<WireArc>();
                        PointOutUI newIn = findPointOut();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().UpdateLine();
                        }
                    }

                }
            }
            else if (transform.parent.name.Contains("Triple3"))
            {
                charge = connectIn.GetComponent<pegScript>().charge;

                //Show Wire on UI
                if (connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.CompareTag("slotOrigin")) //connected to switchboard
                {
                    if (name.Contains("A"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum()] = connectIn.GetComponentInParent<WireArc>();

                        PointOutUI newIn = connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.GetComponent<SwitchSlot>().origin.GetComponent<toggleswitch>().newLogic.GetComponentInChildren<PointOutUI>();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().UpdateLine();
                        }
                    }
                    else if (name.Contains("B"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum() + 1] = connectIn.GetComponentInParent<WireArc>();
                        PointOutUI newIn = connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.GetComponent<SwitchSlot>().origin.GetComponent<toggleswitch>().newLogic.GetComponentInChildren<PointOutUI>();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().UpdateLine();
                        }
                    }
                    else if (name.Contains("C") && !name.Contains("V")) //logicInstanceID = chipInIndex + 1
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum() + 1] = connectIn.GetComponentInParent<WireArc>();
                        PointOutUI newIn = connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.GetComponent<SwitchSlot>().origin.GetComponent<toggleswitch>().newLogic.GetComponentInChildren<PointOutUI>();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().UpdateLine();
                        }
                    }

                }
                else if (connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.CompareTag("slotRow")) //connected to chip
                {
                    if (name.Contains("A"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum()] = connectIn.GetComponentInParent<WireArc>();

                        PointOutUI newIn = findPointOut();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(0).GetComponent<PointInUI>().UpdateLine();
                        }
                    }
                    else if (name.Contains("B"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum() + 1] = connectIn.GetComponentInParent<WireArc>();

                        PointOutUI newIn = findPointOut();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().UpdateLine();
                        }
                    }
                    else if (name.Contains("C") && !name.Contains("V"))
                    {
                        GetComponentInParent<Chip>().chipIns[chipInIndex + checkNum() + 1] = connectIn.GetComponentInParent<WireArc>();

                        PointOutUI newIn = findPointOut();
                        PointInUI newOut = GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>();

                        if (newIn.Outs.Contains(newOut)) { /*do nothing*/ }
                        else { newIn.Outs.Add(newOut); }
                        newOut.input = newIn;
                        if (GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().line == null)
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().createLine(newIn, newOut);
                        }
                        else
                        {
                            GetComponentInParent<Chip>().newLogic.transform.GetChild(chipInIndex).GetChild(1).GetComponent<PointInUI>().UpdateLine();
                        }
                    }
                }
            }
        }
        else if (name.Contains("Y"))
        {
            GetComponentInParent<Chip>().chipOuts[chipInIndex] = connectOut.GetComponentInParent<WireArc>();
            connectOut.GetComponent<pegScript>().charge = charge;
            connectOut.GetComponent<pegScript>().slot.GetComponent<slot>().charge = charge;
        }
    }

    PointOutUI findPointOut()
    {
        return connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().newLogic.transform.GetChild(connectIn.GetComponentInParent<WireArc>().Point1.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponent<pin>().chipInIndex).GetComponentInChildren<PointOutUI>();
    }

    private int checkNum()
    {
        int num = 0;
        if (name.Contains("1")) { num = 0; }
        else if (name.Contains("2")) { num = 1; }
        else if (name.Contains("3")) { num = 2; }
        else if (name.Contains("4")) { num = 3; }

        return num;
    }
}
