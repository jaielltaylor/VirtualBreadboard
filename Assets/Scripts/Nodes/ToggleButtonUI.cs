using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MaximovInk
{
    public class ToggleButtonUI : NodeUI
    {
        private void OnMouseDown()
        {
            OutPoints[0].value = !OutPoints[0].value;
            OutPoints[0].OnCircuitChanged();
        }
    }
}
