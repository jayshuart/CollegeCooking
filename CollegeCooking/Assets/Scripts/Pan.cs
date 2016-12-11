using UnityEngine;
using System.Collections;

public class Pan : MonoBehaviour 
{
	#region Fields
	//This code will be trash and can only be used in this situation
	public int buttersNeeded;
	public int buttersGot;
	public bool heated;
	#endregion

	public void ButterMelted()
	{
		buttersGot++;
		if (buttersGot > buttersNeeded)
		{
			heated = true;
            //Do something funky with color or whatev

            //update task icon - 1 for melting butter being done
            GameManager.Instance.NextTask(1);

		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent<CuttableBlock>() && col.gameObject.GetComponent<CuttableBlock>().type == FoodType.Butter)
		{
			col.gameObject.GetComponent<CuttableBlock>().Cooking = true;
			col.gameObject.GetComponent<CuttableBlock>().cookEvent.AddListener(ButterMelted);
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.GetComponent<CuttableBlock>() && col.gameObject.GetComponent<CuttableBlock>().type == FoodType.Butter)
		{
			col.gameObject.GetComponent<CuttableBlock>().Cooking = false;
		}
	}
}
