using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MaximovInk
{
	public class NodeUI : MonoBehaviour
	{

		public PointInUI[] InPoints { get; private set; }

		public PointOutUI[] OutPoints { get; private set; }

		public int instanceId;

		private void Awake()
		{

			InPoints = GetComponentsInChildren<PointInUI>();
			OutPoints = GetComponentsInChildren<PointOutUI>();
			for (var i = 0; i < OutPoints.Length; i++)
			{
				OutPoints[i].id = i;
			}
		}

		public void RemoveNode()
		{
			if (InPoints != null)
			{
				foreach (var InPoint in InPoints)
				{
					if (InPoint.input != null)
						InPoint.input.Outs.Remove(InPoint);
				}
			}

			if (OutPoints != null)
			{
				foreach (var OutPoint in OutPoints)
				{
					foreach (var Out in OutPoint.Outs)
					{
						Out.input = null;
						Out.value = false;
						Out.UpdateLine();
						Out.OnCircuitChanged();
					}
				}
			}
			Destroy(gameObject);
		}

		public void PositionChanged()
		{
			transform.position = new Vector3(
				Mathf.Round(transform.position.x / MainManager.instance.NodeSnap) * MainManager.instance.NodeSnap
				,
				Mathf.Round(transform.position.y / MainManager.instance.NodeSnap) * MainManager.instance.NodeSnap
			);

			if (InPoints != null)
			{
				foreach (var InPoint in InPoints)
				{
					InPoint.UpdateLine();
				}
			}

			if (OutPoints != null)
			{
				foreach (var OutPoint in OutPoints)
				{
					foreach (var Out in OutPoint.Outs)
					{
						Out.UpdateLine();
					}
				}
			}
		}

		public virtual void OnCircuitChange()
		{
			if (OutPoints == null)
				return;

			foreach (var Out in OutPoints)
			{
				Out.OnCircuitChanged();
			}
		}
	}
}

