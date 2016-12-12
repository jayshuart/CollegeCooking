using UnityEngine;
using System.Collections;

public class EggYolk : Food 
{
	#region Fields

	#endregion

	void Start()
	{
		cookEvent.AddListener(Cooked);
	}

	void Cooked()
	{
		
	}
}
