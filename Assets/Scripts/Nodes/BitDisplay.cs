using UnityEngine;

namespace MaximovInk
{
    public class BitDisplay : Node
    {
        private float cd = 0.5f;
        public TextMesh text;
        public override void OnCircuitChange()
        {
            base.OnCircuitChange();
            text.text = InPoints[0].value ? "1" : "0";
            if(text.text == "1")
            {
                text.text = "True";
                text.color = new Color(0, cd, 0, 1);
            }
            else
            {
                text.text = "False";
                text.color = new Color (cd, 0, 0, 1);
            }
        }
    }
}