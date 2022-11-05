using MaximovInk;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chip : MonoBehaviour
{
    public List<WireArc> chipIns;
    public List<WireArc> chipOuts;
    public List<bool> charges;
    public List<bool> insDetected;
    public Transform attachPoint;

    public int cloneID;
    public int index;

    public GameObject logicPrefab;

    private Vector3 screenPoint;
    private Vector3 offset;

    //private float x = 150;
    //private float y = 0;

    public GameObject newLogic;

    public GameObject criteriaTracker;

    void Awake()
    {
        Debug.Log(PublicVars.cloneID);
        cloneID = PublicVars.cloneID;
        Debug.Log("Clone ID - " + PublicVars.cloneID + " added to: " + name);
        PublicVars.cloneID += 1;

        //Adds chip to chips list and sets index of the chip
        Camera.main.GetComponent<RayCastDelete>().chips.Add(this);
        index = Camera.main.GetComponent<RayCastDelete>().chips.Count - 1;

        if (SceneManager.GetActiveScene().name.Contains("Module")) //Check if the Scene is a Module
        {
            Debug.Log("Within a Module!");
            //if the name of the chip is the same as the text of the toggle, turn that specific toggle on.
            //make a list of all the toggles in the scene
            GameObject[] holdToggles = GameObject.FindGameObjectsWithTag("criteria");
            List<GameObject> criteria = new List<GameObject>(holdToggles);
            Debug.Log("Criteria count = " + criteria.Count);
            for (int i = 0; i < criteria.Count; i++)
            {
                if (criteria[i].GetComponentInChildren<Text>().text.Contains("Quad") && name.Contains("Quad")) //Checking if they are quad
                {
                    if (criteria[i].GetComponentInChildren<Text>().text.Contains("Or") && name.Contains("Or")) 
                    { 
                        criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                        criteriaTracker = criteria[i];
                    }
                    else if (criteria[i].GetComponentInChildren<Text>().text.Contains("Nor") && name.Contains("Nor"))
                    {
                        criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                        criteriaTracker = criteria[i];
                    }
                    else if (criteria[i].GetComponentInChildren<Text>().text.Contains("Xor") && name.Contains("Xor"))
                    {
                        criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                        criteriaTracker = criteria[i];
                    }
                    else if (criteria[i].GetComponentInChildren<Text>().text.Contains("Xnor") && name.Contains("Xnor"))
                    {
                        criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                        criteriaTracker = criteria[i];
                    }
                    else if (criteria[i].GetComponentInChildren<Text>().text.Contains("And") && name.Contains("And"))
                    {
                        criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                        criteriaTracker = criteria[i];
                    }
                    else if (criteria[i].GetComponentInChildren<Text>().text.Contains("Nand") && name.Contains("Nand"))
                    {
                        criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                        criteriaTracker = criteria[i];
                    }
                }
                else if (criteria[i].GetComponentInChildren<Text>().text.Contains("Triple") && name.Contains("Triple")) //checking if they are triple
                {
                    if (criteria[i].GetComponentInChildren<Text>().text.Contains("And") && name.Contains("And"))
                    {
                        criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                        criteriaTracker = criteria[i];
                    }
                    else if (criteria[i].GetComponentInChildren<Text>().text.Contains("Nand") && name.Contains("Nand"))
                    {
                        criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                        criteriaTracker = criteria[i];
                    }
                }
                else if (criteria[i].GetComponentInChildren<Text>().text.Contains("Inverter") && name.Contains("Inverter"))
                {
                    criteria[i].GetComponentInChildren<Toggle>().isOn = true;
                    criteriaTracker = criteria[i];
                }
            }
        }

    }

    void FixedUpdate()
    {
        if (criteriaTracker != null) { criteriaTracker.GetComponentInChildren<Toggle>().isOn = true; }
    }

    public void assignSingleInput(LogicGate gate, WireArc in0) { gate.inputs[0] = in0; }

    public void assignDuoInputs(LogicGate gate, WireArc in0, WireArc in1)
    {
        gate.inputs[0] = in0;
        gate.inputs[1] = in1;    
    }

    public void assignTripleInputs(LogicGate gate, WireArc in0, WireArc in1, WireArc in2)
    {
        gate.inputs[0] = in0;
        gate.inputs[1] = in1;
        gate.inputs[2] = in2;
    }

    void OnMouseDown()
    { 
        if (attachPoint != null) { attachPoint.tag = "attach"; } //removes fill from attachSpot

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        //find the closest attachpoint
        Debug.Log("Looking For Attachpoint");
        if (GameObject.FindGameObjectsWithTag("attach") != null)
        {
            GameObject[] holdTargets = GameObject.FindGameObjectsWithTag("attach");
            List<GameObject> targets = new List<GameObject>(holdTargets);
            float minDistance = float.MaxValue;
            for (int i = 0; i < targets.Count; i++)
            {
                float tempDist = Vector3.Distance(targets[i].transform.position, transform.position);
                Debug.Log(tempDist);
                if (tempDist <= minDistance)
                {
                    minDistance = tempDist;
                    attachPoint = targets[i].transform;
                }
            }

            transform.position = attachPoint.position + new Vector3(0.988f, 1.255f, 5.035f);
            transform.rotation = attachPoint.rotation;
            Debug.Log("I am Attached to..." + attachPoint.gameObject.name + "!");
            attachPoint.tag = "fullAttach";

            if (newLogic == null) { handleLogic(); }
        }
        else{ Debug.Log("Attachpoint was not found"); }
    }

    void handleLogic()
    {
        GameObject content = GameObject.FindGameObjectWithTag("Diagram");
        newLogic = Instantiate(logicPrefab, new Vector2(PublicVars.x, PublicVars.y), Quaternion.identity);
        newLogic.GetComponent<RectTransform>().SetParent(content.GetComponent<RectTransform>(), false);
        
        //keep distance between added logic
        PublicVars.x += 200;
        PublicVars.change += 1;

        if (cloneID == 0) { PublicVars.instanceID -= 7; }

        if (newLogic.name.Contains("hexInverterUI"))
        {
            NotUI[] newGates = newLogic.GetComponentsInChildren<NotUI>();
            foreach (NotUI gate in newGates)
            {
                gate.instanceId = PublicVars.instanceID;
                PublicVars.instanceID += 1;

                gate.GetComponent<RawImage>().color =
                    new Color(gate.GetComponent<RawImage>().color.r,
                    gate.GetComponent<RawImage>().color.g,
                    gate.GetComponent<RawImage>().color.b, 0.5f);
            }
        }
        else if (newLogic.name.Contains("quad2andUI") || newLogic.name.Contains("triple3andUI"))
        {
            AndUI[] newGates = newLogic.GetComponentsInChildren<AndUI>();
            foreach (AndUI gate in newGates)
            {
                gate.instanceId = PublicVars.instanceID;
                PublicVars.instanceID += 1;

                gate.GetComponent<RawImage>().color =
                    new Color(gate.GetComponent<RawImage>().color.r,
                    gate.GetComponent<RawImage>().color.g,
                    gate.GetComponent<RawImage>().color.b, 0.5f);
            }
        }
        else if (newLogic.name.Contains("quad2nandUI") || newLogic.name.Contains("triple3nandUI"))
        {
            NandUI[] newGates = newLogic.GetComponentsInChildren<NandUI>();
            foreach (NandUI gate in newGates)
            {
                gate.instanceId = PublicVars.instanceID;
                PublicVars.instanceID += 1;

                gate.GetComponent<RawImage>().color =
                    new Color(gate.GetComponent<RawImage>().color.r,
                    gate.GetComponent<RawImage>().color.g,
                    gate.GetComponent<RawImage>().color.b, 0.5f);
            }
        }
        else if (newLogic.name.Contains("quad2norUI"))
        {
            NorUI[] newGates = newLogic.GetComponentsInChildren<NorUI>();
            foreach (NorUI gate in newGates)
            {
                gate.instanceId = PublicVars.instanceID;
                PublicVars.instanceID += 1;

                gate.GetComponent<RawImage>().color =
                    new Color(gate.GetComponent<RawImage>().color.r,
                    gate.GetComponent<RawImage>().color.g,
                    gate.GetComponent<RawImage>().color.b, 0.5f);
            }
        }
        else if (newLogic.name.Contains("quad2xorUI"))
        {
            XorUI[] newGates = newLogic.GetComponentsInChildren<XorUI>();
            foreach (XorUI gate in newGates)
            {
                gate.instanceId = PublicVars.instanceID;
                PublicVars.instanceID += 1;

                gate.GetComponent<RawImage>().color =
                    new Color(gate.GetComponent<RawImage>().color.r,
                    gate.GetComponent<RawImage>().color.g,
                    gate.GetComponent<RawImage>().color.b, 0.5f);

            }
        }
        else if (newLogic.name.Contains("quad2xnorUI"))
        {
            XnorUI[] newGates = newLogic.GetComponentsInChildren<XnorUI>();
            foreach (XnorUI gate in newGates)
            {
                gate.instanceId = PublicVars.instanceID;
                PublicVars.instanceID += 1;

                gate.GetComponent<RawImage>().color =
                    new Color(gate.GetComponent<RawImage>().color.r,
                    gate.GetComponent<RawImage>().color.g,
                    gate.GetComponent<RawImage>().color.b, 0.5f);

            }
        }
        else if (newLogic.name.Contains("quad2orUI"))
        {
            OrUI[] newGates = newLogic.GetComponentsInChildren<OrUI>();
            foreach (OrUI gate in newGates)
            {
                gate.instanceId = PublicVars.instanceID;
                PublicVars.instanceID += 1;

                gate.GetComponent<RawImage>().color =
                    new Color(gate.GetComponent<RawImage>().color.r,
                    gate.GetComponent<RawImage>().color.g,
                    gate.GetComponent<RawImage>().color.b, 0.5f);
            }
        }
        PublicVars.instanceID = 1;
    }
}
