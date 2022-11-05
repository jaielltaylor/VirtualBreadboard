using MaximovInk;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayCastDelete : MonoBehaviour
{
    public GameObject pointer;
    public List<Chip> chips;
    private int chipIndex;

    private int pinChild;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    if (hit.transform.tag == "PegIn" || hit.transform.tag == "PegOut")
                    {
                        if (hit.transform.GetComponent<pegScript>().slot.CompareTag("slotRow"))
                        {
                            if (hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin != null)
                            {
                                hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponent<pin>().isConnected = false;

                                getNum(hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin);

                                if (hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().name.Contains("Hex"))
                                {
                                    if (hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().newLogic.transform.GetChild(hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponent<pin>().chipInIndex).GetChild(pinChild).GetComponent<PointInUI>().line != null)
                                    {
                                        Debug.Log("Removing with Line!");
                                        hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().newLogic.transform.GetChild(hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponent<pin>().chipInIndex).GetChild(pinChild).GetComponent<PointInUI>().RemoveLine();
                                    }
                                    else { Debug.Log("Removing without Line!"); }
                                }
                                else if (hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().name.Contains("Quad2"))
                                {
                                    if (hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().newLogic.transform.GetChild(hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponent<pin>().chipInIndex).GetChild(pinChild).GetComponent<PointInUI>().line != null)
                                    {
                                        Debug.Log("Removing with Line!");
                                        hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().newLogic.transform.GetChild(hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponent<pin>().chipInIndex).GetChild(pinChild).GetComponent<PointInUI>().RemoveLine();
                                    }
                                    else { Debug.Log("Removing without Line!"); }
                                }
                                else if (hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().name.Contains("Triple3"))
                                {
                                    if (hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().newLogic.transform.GetChild(hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponent<pin>().chipInIndex).GetChild(pinChild).GetComponent<PointInUI>().line != null)
                                    {
                                        Debug.Log("Removing with Line!");
                                        hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponentInParent<Chip>().newLogic.transform.GetChild(hit.transform.GetComponent<pegScript>().slot.GetComponent<slot>().pin.GetComponent<pin>().chipInIndex).GetChild(pinChild).GetComponent<PointInUI>().RemoveLine();
                                    }
                                    else { Debug.Log("Removing without Line!"); }
                                }
                            }
                        }
                        Destroy(hit.transform.parent.gameObject);
                    }
                    else if (hit.transform.CompareTag("Chip"))
                    {
                        //Test if Chip is in toggle, if so, turn toggle off.
                        if (SceneManager.GetActiveScene().name.Contains("Module")) { checkToggle(hit.transform.gameObject); }

                        //Destroy wires attached to chip
                        pin[] pins = hit.transform.GetComponentsInChildren<pin>();

                        foreach (pin p in pins)
                        {
                            if (p.connectIn != null)
                            {
                                p.isConnected = false;

                                if (p.GetComponentInParent<Chip>().newLogic.transform.GetChild(p.chipInIndex).GetChild(0).GetComponent<PointInUI>() != null)
                                    p.GetComponentInParent<Chip>().newLogic.transform.GetChild(p.chipInIndex).GetChild(0).GetComponent<PointInUI>().RemoveLine();

                                Destroy(p.connectIn.transform.parent.gameObject);
                            }
                        }

                        //Destroys logic diagram representation
                        Destroy(hit.transform.GetComponent<Chip>().newLogic);

                        //Gets the index of the chip that will be deleted.
                        hit.transform.GetComponent<Chip>().index = chipIndex;
                        chips.RemoveAt(hit.transform.GetComponent<Chip>().index);
                        
                        //Empties attachpoint and destroys the Chip
                        hit.transform.GetComponent<Chip>().attachPoint.tag = "attach";
                        Destroy(hit.transform.gameObject);

                        //find all chips in chips list that are at or past the chipIndex and move their newLogic's position's by 200.
                        for (int i = chipIndex; i < chips.Count; i++)
                        {
                            if (chips[i].newLogic != null)
                            {
                                chips[i].newLogic.GetComponent<RectTransform>().position = new Vector3(chips[i].newLogic.GetComponent<RectTransform>().position.x - 200, chips[i].newLogic.GetComponent<RectTransform>().position.y, chips[i].newLogic.GetComponent<RectTransform>().position.z);
                            }                        
                        }
                        PublicVars.x -= 200;
                    }

                }
            }
        }
    }

    void checkToggle(GameObject chip)
    {
        Debug.Log("Deleting from Checklist!");
        if (chip.GetComponent<Chip>().criteriaTracker != null) { chip.GetComponent<Chip>().criteriaTracker.GetComponentInChildren<Toggle>().isOn = false; }
    }

    void getNum(GameObject pin)
    {
        if (pin.name.Contains("A")) { pinChild = 0; }
        else if (pin.name.Contains("B") || (pin.name.Contains("C") && !pin.name.Contains("V"))) { pinChild = 1; }
    }
}
