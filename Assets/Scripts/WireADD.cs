using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireADD : MonoBehaviour
{
    public GameObject[] wireList;
    public GameObject wire;
    public GameObject wireBlue;
    public GameObject wireRed;
    public GameObject wireGreen;
    public GameObject pegIn;
    public GameObject pegOut;
    public GameObject Dummy;
    public GameObject add;

    public int color = 0;

    public int counter = 0;

    private void Start()
    {
        GameObject[] wireList = new GameObject[] { wireBlue, wireRed, wireGreen };
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && counter % 2 == 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    if (hit.transform.tag == "slotRow" || hit.transform.tag == "slotOrigin")
                    {
                        add = Instantiate(wireList[color], new Vector3(0, 0, 0), Quaternion.identity);
                        GameObject pegA = Instantiate(pegIn, hit.point, Quaternion.identity);
                        pegA.transform.parent = add.transform;
                        add.GetComponent<WireArc>().Point1 = pegA.transform;
                        add.GetComponent<WireArc>().Point2 = Dummy.transform;

                        counter++;

                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && counter % 2 == 1)
        {
            RaycastHit hitt;
            Ray rayy = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayy, out hitt, 100.0f))
            {
                if (hitt.transform != null)
                {
                    if (hitt.transform.tag == "slotRow" || hitt.transform.tag == "slotOrigin")
                    {
                        GameObject pegB = Instantiate(pegOut, hitt.point, Quaternion.identity);
                        add.GetComponent<WireArc>().Point3 = pegB.transform;
                        pegB.transform.parent = add.transform;

                        counter++;

                    }
                }
            }
        }

    }
    public void red()
    {
        color = 2;
    }
    public void blue()
    {
        color = 0;
    }
    public void green()
    {
        color = 1;
    }
}