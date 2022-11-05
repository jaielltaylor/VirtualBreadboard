using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LED : MonoBehaviour
{
    public bool isConnected;
    public bool charge;
    public GameObject bulb;
    public Material on;
    public Material off;

    private bool modulated = false;
    private GameObject outputToggle;

    // Start is called before the first frame update
    void Awake()
    {
        //Check if the Scene is a Module
        if (SceneManager.GetActiveScene().name.Contains("Module")) 
        {
            modulated = true;
            GameObject[] holdToggles = GameObject.FindGameObjectsWithTag("criteria");
            List<GameObject> criteria = new List<GameObject>(holdToggles);
            for (int i = 0; i < criteria.Count; i++)
            {
                if (criteria[i].GetComponentInChildren<Text>().text.Contains("Output"))
                {
                    outputToggle = criteria[i];
                    Debug.Log("Output Criteria Found: " + criteria[i].GetComponentInChildren<Text>().text);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (charge && isConnected)
        {
            bulb.GetComponent<MeshRenderer>().material = on;

            if (SceneManager.GetActiveScene().name.Contains("Module"))
            {
                if (modulated && outputToggle.GetComponentInChildren<Text>().text.Contains("1")) { outputToggle.GetComponentInChildren<Toggle>().isOn = true; }
                else { outputToggle.GetComponentInChildren<Toggle>().isOn = false; }
            }
        }
        else if (!charge && isConnected)
        {
            bulb.GetComponent<MeshRenderer>().material = off;

            if (SceneManager.GetActiveScene().name.Contains("Module"))
            {
                if (modulated && outputToggle.GetComponentInChildren<Text>().text.Contains("0")) { outputToggle.GetComponentInChildren<Toggle>().isOn = true; }
                else { outputToggle.GetComponentInChildren<Toggle>().isOn = false; }
            }
        }
        else if (!isConnected)
        {
            bulb.GetComponent<MeshRenderer>().material = off;
            outputToggle.GetComponentInChildren<Toggle>().isOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("slotRow")) 
        { 
            charge = other.GetComponent<slot>().charge;
            if (other.GetComponent<slot>().peg != null) { isConnected = true; }
            else { isConnected = false; }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("slotRow"))
        {
            charge = other.GetComponent<slot>().charge;
            if (other.GetComponent<slot>().peg != null) { isConnected = true; }
            else { isConnected = false; }
        }
    }
}
