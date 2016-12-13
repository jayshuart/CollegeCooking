using UnityEngine;
using System.Collections;

public class EggYolk : Food 
{
	#region Fields
	public GameObject sunnySide;
	#endregion

	void Awake()
	{
		GameManager.Instance.NextTask(3);
		cookEvent.AddListener(EggCooked);
	}

	void Update()
	{
		base.Update();
	}

	void EggCooked()
	{
		//Change model
		sunnySide.SetActive(true);
		GetComponent<MeshRenderer>().enabled = false;
		GameManager.Instance.NextTask(4);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "plate" && Cooked)
		{
			GameManager.Instance.winEvent.Invoke();
		}
	}
}
