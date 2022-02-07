using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AA0000
{
	public class MovingPlatform : MonoBehaviour
	{
		public Transform[] waypoints;
		private int targetWaypointIndex = 0;
		public bool randomizeWaypoint = false;
		[SerializeField] private Vector3 targetPoint;
		public float speed = 5.0f;
		public float minimumDistance;

		private void Start()
		{
			ChangeWaypoint();
		}

		private void Update()
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);
			if (Vector3.Distance(transform.position, targetPoint) <= minimumDistance)
			{
				ChangeWaypoint();
			}
		}

		private void ChangeWaypoint()
		{
			if (randomizeWaypoint)
			{
				RandomizeWaypoint();
			}
			else
			{
				NextWaypoint();
			}

			targetPoint = waypoints[targetWaypointIndex].position;
		}

		private void RandomizeWaypoint()
		{
			targetWaypointIndex = Random.Range(0, waypoints.Length);
		}

		private void NextWaypoint()
		{
			targetWaypointIndex++;
			if (targetWaypointIndex == waypoints.Length)
			{
				targetWaypointIndex = 0;
			}
		}
	} 
}
