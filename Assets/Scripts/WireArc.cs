using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireArc : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;
    public Transform Point3;
    public LineRenderer linerenderer;
    public float vertexCount = 12;
    public float Point2Ypositio = 2;
    public bool charge = false;
    public bool complete = false;

    public float uniqueID = 0f;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Point3 != null)
        {
            complete = true;
            Point2.transform.position = new Vector3((Point1.transform.position.x + Point3.transform.position.x) / 2
                , Point2Ypositio, (Point1.transform.position.z + Point3.transform.position.z) / 2);
            var pointList = new List<Vector3>();

            for (float ratio = 0; ratio <= 1; ratio += 1 / vertexCount)
            {
                var tangent1 = Vector3.Lerp(Point1.position, Point2.position, ratio);
                var tangent2 = Vector3.Lerp(Point2.position, Point3.position, ratio);
                var curve = Vector3.Lerp(tangent1, tangent2, ratio);

                pointList.Add(curve);
            }

            linerenderer.positionCount = pointList.Count;
            linerenderer.SetPositions(pointList.ToArray());
            charge = Point1.GetComponent<pegScript>().charge;
            Point3.GetComponent<pegScript>().charge = charge;

        }
    }
   
}