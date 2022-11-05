using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastSwitch : MonoBehaviour
{
    public Animator anima;
    private void Start()
    {

    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    if (hit.transform.tag == "Switch" &&  hit.transform.GetComponent<toggleswitch>().state == false)
                    {
                         hit.transform.GetComponent<toggleswitch>().state = true;
                         hit.transform.position = hit.transform.GetComponent<toggleswitch>().Zero.position;
                    }
                    else if (hit.transform.tag == "Switch" && hit.transform.GetComponent<toggleswitch>().state == true)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = false;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().One.position;
                    }
                    if (hit.transform.tag == "Switch2" && hit.transform.GetComponent<toggleswitch>().state == false)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = true;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().Zero.position;
                    }
                    else if (hit.transform.tag == "Switch2" && hit.transform.GetComponent<toggleswitch>().state == true)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = false;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().One.position;
                    }
                    if (hit.transform.tag == "Switch3" && hit.transform.GetComponent<toggleswitch>().state == false)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = true;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().Zero.position;
                    }
                    else if (hit.transform.tag == "Switch3" && hit.transform.GetComponent<toggleswitch>().state == true)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = false;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().One.position;
                    }
                    if (hit.transform.tag == "Switch4" && hit.transform.GetComponent<toggleswitch>().state == false)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = true;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().Zero.position;
                    }
                    else if (hit.transform.tag == "Switch4" && hit.transform.GetComponent<toggleswitch>().state == true)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = false;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().One.position;
                    }
                    if (hit.transform.tag == "Switch5" && hit.transform.GetComponent<toggleswitch>().state == false)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = true;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().Zero.position;
                    }
                    else if (hit.transform.tag == "Switch5" && hit.transform.GetComponent<toggleswitch>().state == true)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = false;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().One.position;
                    }
                    if (hit.transform.tag == "Switch6" && hit.transform.GetComponent<toggleswitch>().state == false)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = true;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().Zero.position;
                    }
                    else if (hit.transform.tag == "Switch6" && hit.transform.GetComponent<toggleswitch>().state == true)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = false;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().One.position;
                    }
                    if (hit.transform.tag == "Switch7" && hit.transform.GetComponent<toggleswitch>().state == false)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = true;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().Zero.position;
                    }
                    else if (hit.transform.tag == "Switch7" && hit.transform.GetComponent<toggleswitch>().state == true)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = false;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().One.position;
                    }
                    if (hit.transform.tag == "Switch8" && hit.transform.GetComponent<toggleswitch>().state == false)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = true;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().Zero.position;
                    }
                    else if (hit.transform.tag == "Switch8" && hit.transform.GetComponent<toggleswitch>().state == true)
                    {
                        hit.transform.GetComponent<toggleswitch>().state = false;
                        hit.transform.position = hit.transform.GetComponent<toggleswitch>().One.position;
                    }


                }
            }
        }
    }
}
