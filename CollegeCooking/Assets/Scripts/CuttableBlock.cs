using UnityEngine;
using System.Collections;

public class CuttableBlock : Food
{
	#region Fields
	public int indexInObject;
	public FoodType type;
	private bool detached;
	#endregion

	void Update()
	{
		//Cooking logic applies
		base.Update();
	}

	public void Detach()
	{
		if (transform.parent != null && indexInObject > 0 && indexInObject < transform.parent.childCount - 1)
		{
			int oldIndex = indexInObject;

			//deparent all to the right
			//set proper index
			int x = 0;
			for (int i = 0; i < transform.parent.childCount; i++)
			{
				if (i < indexInObject)
				{
					transform.parent.GetChild(i).GetComponent<CuttableBlock>().indexInObject = i;
				}
				else
				{
					Debug.Log("Here and x is :" + x);
					transform.parent.GetChild(i).GetComponent<CuttableBlock>().indexInObject = x;
					x++;
				}
			}
			//Now deparent
			GameObject go = new GameObject();
			Transform oldTransform = transform.parent.transform;
			while (oldTransform.childCount > oldIndex)
			{
				oldTransform.GetChild(oldIndex).SetParent(go.transform);
			}
			go.AddComponent<BoxCollider>();
			go.AddComponent<Rigidbody>();
			go.AddComponent<CuttableObject>();
			go.tag = "Grabable";
			go.name = "New Cut";
		}
		else if (!detached)
		{
			//just deparent
			transform.SetParent(null);
			gameObject.AddComponent<Rigidbody>();
			detached = true;
			indexInObject = 0;
		}
	}
}
