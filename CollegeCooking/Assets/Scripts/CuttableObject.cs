using UnityEngine;
using System.Collections;

public class CuttableObject : Food
{
	#region Fields
	//public and assigned
	public FoodType type;
	public int numberOfPieces;
	public GameObject blockPrefab; //this can change based on what food
	#endregion

	//Add code to detect collision and seperate proper block
	void Start()
	{
		if (GetComponent<MeshRenderer>() == null)
		{
			//This was broken from another cuttable object
			//Don't generate more blocks
		}
		else
		{
			//disable the mesh
			GetComponent<MeshRenderer>().enabled = false;

			//Get the scale of each piece
			Vector3 scale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z / numberOfPieces);

			for (int i = 0; i < numberOfPieces; i++)
			{
				GameObject temp = (GameObject)GameObject.Instantiate(blockPrefab, transform.position, Quaternion.identity, gameObject.transform);

				//scale the go
				Vector3 tempLocalScale = temp.transform.localScale;
				temp.transform.localScale = new Vector3(temp.transform.localScale.x, temp.transform.localScale.y, temp.transform.localScale.z / numberOfPieces);

				//position the go
				temp.transform.localPosition = new Vector3(0f, 0f, (temp.transform.localScale.z * i) - (tempLocalScale.z / 2));

				//set index and type
				temp.GetComponent<CuttableBlock>().indexInObject = i;
				temp.GetComponent<CuttableBlock>().type = type;
			}
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			transform.GetChild(Random.Range(0, transform.childCount - 1)).GetComponent<CuttableBlock>().Detach();
		}
	}

	void OnCollisionEnter(Collision col)
	{
		//Should add checks to see if knife is down
		foreach (ContactPoint c in col.contacts)
		{
			if (c.otherCollider.name == "Knife" && c.thisCollider.gameObject.GetComponent<CuttableBlock>() != null)
			{
				c.thisCollider.gameObject.GetComponent<CuttableBlock>().Detach();
			}
		}
	}
}
