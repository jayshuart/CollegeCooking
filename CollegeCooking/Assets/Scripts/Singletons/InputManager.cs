using UnityEngine;
using System.Collections;

/// <summary>
/// Should load all sound files from resources and store them in a dictionary on awake.
/// A play sound method should be defined for looping and one shot sounds.
/// Any calls to sound manager should be made in code.
/// Any ui sounds will be handled seperately through canvas.
/// </summary>
public class InputManager : Singleton<InputManager>
{
	#region Fields
    private Vector3 startPos;
	#endregion

	#region Properties
	#endregion

	protected InputManager(){}

	public void Reset()
	{
	}

	void Update()
	{

	}
		
}
