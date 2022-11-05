using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MaximovInk;

public class toggleswitch : MonoBehaviour
{
    public GameObject row;
    public Transform Zero;
    public Transform One;
    public bool state = false;
    
    public GameObject logicPrefab;
    public GameObject newLogic;
    // Start is called before the first frame update
    void Start()
    {
        GameObject content = GameObject.FindGameObjectWithTag("Diagram");

        if (CompareTag("Switch")) { newLogic = Instantiate(logicPrefab, new Vector2(0, 120), Quaternion.identity); }
        
        else if (CompareTag("Switch2")) { newLogic = Instantiate(logicPrefab, new Vector2(0, 80), Quaternion.identity); }

        else if (CompareTag("Switch3")) { newLogic = Instantiate(logicPrefab, new Vector2(0, 40), Quaternion.identity); }

        else if (CompareTag("Switch4")) { newLogic = Instantiate(logicPrefab, new Vector2(0, 0), Quaternion.identity); }

        else if (CompareTag("Switch5")) { newLogic = Instantiate(logicPrefab, new Vector2(0, -40), Quaternion.identity); }

        else if (CompareTag("Switch6")) { newLogic = Instantiate(logicPrefab, new Vector2(0, -80), Quaternion.identity); }

        else if (CompareTag("Switch7")) { newLogic = Instantiate(logicPrefab, new Vector2(0, -120), Quaternion.identity); }

        else if (CompareTag("Switch8")) { newLogic = Instantiate(logicPrefab, new Vector2(0, -160), Quaternion.identity); }

        newLogic.GetComponent<RectTransform>().SetParent(content.GetComponent<RectTransform>(), false);
        newLogic.GetComponent<ToggleButtonUI>().instanceId = PublicVars.instanceID;
        PublicVars.instanceID += 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwitchTrigger")) 
        { 
            row.GetComponent<SwitchSlot>().charge = false;
            toggle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SwitchTrigger"))
        {
            row.GetComponent<SwitchSlot>().charge = true;
            toggle();
        }
    }


    public void toggle()
    {
       if (row.GetComponent<SwitchSlot>().charge == true)
       {
            row.GetComponent<SwitchSlot>().charge = false;
            newLogic.GetComponentInChildren<PointOutUI>().value = false;
            newLogic.GetComponentInChildren<Text>().text = "0";
       }
       else
       { 
            row.GetComponent<SwitchSlot>().charge = true;
            newLogic.GetComponentInChildren<PointOutUI>().value = true;
            newLogic.GetComponentInChildren<Text>().text = "1";
       }
       newLogic.GetComponentInChildren<PointOutUI>().OnCircuitChanged();
    }
}
