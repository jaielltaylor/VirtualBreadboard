using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace MaximovInk
{
    public class PointInUI : Point
    {
        public UILineRenderer line;
        public PointOutUI input;

        private GameObject content;

        public override void OnCircuitChanged()
        {


            if (input == null) { value = false; }

            base.OnCircuitChanged();

            GetComponentInParent<NodeUI>().OnCircuitChange();

            if (line != null) { line.color = value ? Color.white : Color.black; }
            

        }

        private Vector2 findCorrectPos(GameObject point)
        {
            Transform parentTransform = point.transform.parent;
            point.transform.SetParent(content.transform);

            //Debug.Log("correct position is: " + "x = " + point.transform.localPosition.x + ", y = " + point.transform.localPosition.y + ", z = " + point.transform.localPosition.z);
            Vector2 vector = point.transform.localPosition;
            vector.y += 210;

            point.transform.SetParent(parentTransform);
            if (point.GetComponent<PointInUI>() != null && point.name.Contains("0"))
            {
                point.transform.SetSiblingIndex(0);
            }
            else if (point.GetComponent<PointInUI>() != null && point.name.Contains("1"))
            {
                point.transform.SetSiblingIndex(1);
            }
            else if (point.GetComponent<PointOutUI>() != null)
            {
                point.transform.SetAsLastSibling();
            }

            return vector;
        }
        

        public void createLine(PointOutUI input, PointInUI output)
        {
            if (transform.childCount == 0)
            {
                GameObject gameObj = new GameObject("line", typeof(UILineRenderer), typeof(LineUI));
                gameObj.GetComponent<UILineRenderer>().Points = new Vector2[2];
                gameObj.GetComponent<UILineRenderer>().lineThickness = 2f;


                content = GameObject.FindGameObjectWithTag("Diagram");
                gameObj.transform.SetParent(content.transform, false);
                gameObj.GetComponent<UILineRenderer>().color = new Color(0, 0, 0, 1);
                line = gameObj.GetComponent<UILineRenderer>();
            }

            line.gameObject.GetComponent<LineUI>().start = input;
            line.gameObject.GetComponent<LineUI>().end = output;

            RectTransform rTransform = line.gameObject.GetComponent<RectTransform>();
            SetLine(input, output, rTransform);
        }

        public void SetLine(PointOutUI start, PointInUI end, RectTransform rect)
        {

            line.m_points[0] = findCorrectPos(start.gameObject);
            line.m_points[1] = findCorrectPos(end.gameObject);

            rect.gameObject.GetComponent<LineUI>().value = input.value;
            value = rect.gameObject.GetComponent<LineUI>().value;
        }

        public void UpdateLine()
        {
            line.GetComponent<LineUI>().end = this;

            if (input != null)
            {
                line.GetComponent<LineUI>().start = input;
                SetLine(input, this, line.GetComponent<RectTransform>());
            }
        }

        public void RemoveLine()
        {
            Debug.Log("Remove line has been called.");
            Destroy(line.gameObject);
            line = null;
            Debug.Log("Line is destroyed.");

            //Reset input and output
            //Go through outs in input and check which ones are equal to self and remove them
            for (int i = 0; i < input.Outs.Count; i++)
            {
                if (input.Outs[i].name == this.name) { input.Outs.RemoveAt(i); }
            }
            input = null;
        }

        public float vectorToAngleFloat(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            Debug.Log(n);
            return n;
        }
    }
}
