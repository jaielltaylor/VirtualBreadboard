using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MaximovInk
{
    public class PointOutUI : Point
    {
        public List<PointInUI> Outs = new List<PointInUI>();
        public int id;
        public override void OnCircuitChanged()
        {
            base.OnCircuitChanged();

            foreach (var Out in Outs)
            {
                if (Out.value == value)
                    continue;
                Out.value = value;

                Out.OnCircuitChanged();
            }
        }
    }
}