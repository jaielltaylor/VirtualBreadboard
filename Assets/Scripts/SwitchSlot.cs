using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSlot : MonoBehaviour
{
    
    public bool charge = false;
    public int counter = 0;
    public bool contact = false;

    public GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        if (name.Contains("1")) { origin = GameObject.FindGameObjectWithTag("Switch"); }
        else if (name.Contains("2")) { origin = GameObject.FindGameObjectWithTag("Switch2"); }
        else if (name.Contains("3")) { origin = GameObject.FindGameObjectWithTag("Switch3"); }
        else if (name.Contains("4")) { origin = GameObject.FindGameObjectWithTag("Switch4"); }
        else if (name.Contains("5")) { origin = GameObject.FindGameObjectWithTag("Switch5"); }
        else if (name.Contains("6")) { origin = GameObject.FindGameObjectWithTag("Switch6"); }
        else if (name.Contains("7")) { origin = GameObject.FindGameObjectWithTag("Switch7"); }
        else if (name.Contains("8")) { origin = GameObject.FindGameObjectWithTag("Switch8"); }

    }

    // Update is called once per frame
    void Update()
    {
    }
     
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "peg")
        {
            collision.gameObject.transform.parent.GetComponent<WireArc>().charge = charge;
        }
    }
}
