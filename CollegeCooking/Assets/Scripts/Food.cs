using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Food : MonoBehaviour 
{
	#region Fields
	//Assigned in editor for simple balancing
	public float cookTime; //in seconds
	public float cookRate;
	public float breakForce;

	//Events
	protected UnityEvent cookEvent;
	private UnityEvent breakEvent; //Might not use. 

	//private
	private bool cooking;
	private bool cooked;
	private float cookTimer;
	#endregion

	#region Properties
	public bool Cooking { get { return cooking; } set { cooking = value; } }
	public bool Cooked { get { return cooked; } }

	//Events
	public UnityEvent BreakEvent { get { return breakEvent; } }
	#endregion

	protected void Update()
	{
		//Cooking logic
		if (!cooked)
		{
			if (cooking)
			{
				//increase cook time, currently cooking
				if (cookTimer >= cookTime)
				{
					//This item was cooked so invoke the cookEvent
					cookTimer = 0f;
					cooked = true;
					cookEvent.Invoke();
				}
				else
				{
					cookTimer += cookRate * Time.deltaTime;
				}
			}
			else
			{
				//You're cooling off son
				if (cookTimer < 0)
				{
					cookTimer = 0f;
				}
				else
				{
					cookTimer -= cookRate * Time.deltaTime;
				}
			}
		}
	}
}
