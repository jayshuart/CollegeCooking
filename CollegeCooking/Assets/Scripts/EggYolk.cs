using UnityEngine;
using System.Collections;

public class EggYolk : Food 
{
	#region Fields
	public GameObject sunnySide;
	#endregion

	void Start()
	{
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
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "plate" && Cooked)
		{
			GameManager.Instance.winEvent.Invoke();
		}
	}
}
