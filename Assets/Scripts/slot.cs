using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    public bool charge;
    public bool isWired;
    public int counter = 0;
    public bool contact;

    public GameObject peg;
    public GameObject pin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (counter > 0)
        {
            contact = true;
        }
        else
        {
            contact = false;
        }

        if (pin != null && peg != null)
        {
            if (peg.CompareTag("PegIn")) 
            { 
                pin.GetComponent<pin>().connectOut = peg;
                pin.GetComponent<pin>().isConnected = true;
            }
            else if (peg.CompareTag("PegOut")) 
            { 
                pin.GetComponent<pin>().connectIn = peg;
                pin.GetComponent<pin>().isConnected = true;
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        counter++;
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("PegIn")) { peg = collision.gameObject; }
        else if (collision.CompareTag("PegOut"))
        {
            peg = collision.gameObject; 
            charge = peg.GetComponent<pegScript>().charge;
        }
        
        if (collision.gameObject.CompareTag("pinIn") || collision.gameObject.CompareTag("pinOut")) { pin = collision.gameObject; }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "PegOut")
        {
            charge = false;
            counter--;
            
            
            
        }
    }
}
