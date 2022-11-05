using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegScript : MonoBehaviour
{
    public bool charge;
    public GameObject slot;
    public GameObject pin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
      
    
    void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("slotOrigin")) //Peg must be a PegIn
        {
            slot = collision.gameObject;
            charge = slot.GetComponent<SwitchSlot>().charge;
            transform.parent.GetComponent<WireArc>().charge = charge;
        }
        else if (collision.gameObject.CompareTag("slotRow") && CompareTag("PegIn"))
        {
            slot = collision.gameObject;
            charge = slot.GetComponent<slot>().charge;
            transform.parent.GetComponent<WireArc>().charge = charge;
        }
        else if (collision.gameObject.CompareTag("slotRow") && CompareTag("PegOut"))
        {
             slot = collision.gameObject;
             charge = transform.parent.GetComponent<WireArc>().charge;
             collision.GetComponent<slot>().charge = charge;
        }

        if(collision.CompareTag("pinIn"))
        {
            pin = collision.gameObject;
            if (CompareTag("PegIn"))
            {
                charge = pin.GetComponent<pin>().charge;
            }
            else if (CompareTag("PegOut"))
            {
                pin.GetComponent<pin>().charge = charge;
            }
        }
        else if (collision.CompareTag("pinOut"))
        {
            pin = collision.gameObject;
            if (CompareTag("PegIn"))
            {
                charge = pin.GetComponent<pin>().charge;
            }
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "slotOrigin")
        {
            slot = other.gameObject;
            if (other.gameObject.GetComponent<SwitchSlot>().charge)
            {
                charge = true;
                transform.parent.GetComponent<WireArc>().charge = true;
            }

            if (!other.gameObject.GetComponent<SwitchSlot>().charge)
            {
                charge = false;
                transform.parent.GetComponent<WireArc>().charge = false;
            }
        }
        else if (other.gameObject.tag == "slotRow" && CompareTag("PegIn"))
        {
            slot = other.gameObject;
            if (other.gameObject.GetComponent<slot>().charge)
            {
                charge = true;
                transform.parent.GetComponent<WireArc>().charge = true;
            }
            else if (!other.gameObject.GetComponent<slot>().charge)
            {
                charge = false;
                transform.parent.GetComponent<WireArc>().charge = false;
            }
        }
        else if (other.gameObject.CompareTag("slotRow") && CompareTag("PegOut"))
        {
            slot = other.gameObject;
            charge = transform.parent.GetComponent<WireArc>().charge;
            other.GetComponent<slot>().charge = charge;
        }
    }
    */
}
