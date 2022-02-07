using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AA0000
{
	public class ParentToObject : MonoBehaviour
	{
		public LayerMask whatToParent;

		private void OnTriggerEnter(Collider other)
		{
			if ((whatToParent.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
			{
				other.transform.parent = transform.parent;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			other.transform.parent = null;
		}
	} 
}
