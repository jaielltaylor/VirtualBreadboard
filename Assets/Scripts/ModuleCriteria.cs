using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleCriteria : MonoBehaviour
{
    public List<Toggle> toggles; //list of toggles for the criteria
    public bool moduleComplete = false;
    void Start()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.isOn = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkCriteria();
    }

    void checkCriteria()
    {
        int criteriaTracker = 0;
        for (int i = 0; i < toggles.Count; i ++)
        {
            if (toggles[i].isOn) { criteriaTracker += 1; }
        }

        if(criteriaTracker == (toggles.Count - 1)) { moduleComplete = true; }
    }
}
