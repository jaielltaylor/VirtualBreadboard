using UnityEngine;
using UnityEngine.UI;

namespace MaximovInk
{
    public class Point : MonoBehaviour
    {
        public bool value;
        protected Color deactivated = Color.black;
        protected Color activated = Color.white;
        
        
        [HideInInspector]
        public Node node;

        private SpriteRenderer sp;
        private RawImage rw;

        private void Awake()
        {
            if (sp != null) { sp = GetComponent<SpriteRenderer>(); }
            else { rw = GetComponent<RawImage>(); }
        }

        public virtual void OnCircuitChanged()
        {
            if (sp != null) { sp.color = value ? activated : deactivated; }
            else if (rw != null) { rw.color = value ? activated : deactivated; }
        }

        private void Start()
        {
            transform.localPosition = new Vector3(
                //Mathf.Round(transform.localPosition.x/MainManager.instance.PointsSnap)*MainManager.instance.PointsSnap
                Mathf.Round((float)(transform.localPosition.x / 0.005)) * (float)0.005
                ,
                //Mathf.Round(transform.localPosition.y/MainManager.instance.PointsSnap)*MainManager.instance.PointsSnap,
                Mathf.Round((float)(transform.localPosition.y / 0.005)) * (float)0.005,
                1
            );

            node = GetComponentInParent<Node>();
            OnCircuitChanged();
        }
        
        
    }
}