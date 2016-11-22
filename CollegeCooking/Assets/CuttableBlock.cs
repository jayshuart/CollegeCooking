using UnityEngine;
using System.Collections;

public class CuttableBlock : MonoBehaviour 
{
	#region Fields
	private FixedJoint joint;
	#endregion

	void Start()
	{
		joint = GetComponent<FixedJoint>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (joint != default(FixedJoint))
			{
				Destroy(joint);
			}
		}
	}

	/*void OnCollisionEnter(Collision col)
	{
		if (col.collider.gameObject.tag == "Sharp")
		{
			if (leftJoint != default(FixedJoint))
			{
				Destroy(leftJoint);
			}
			else if (rightJoint != default(FixedJoint))
			{
				Destroy(rightJoint);
			}
		}
	}*/
}
