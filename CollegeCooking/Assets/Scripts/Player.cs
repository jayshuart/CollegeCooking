using UnityEngine;
using System.Collections;

/// <summary>
/// Does whatever a player does
/// </summary>
[RequireComponent (typeof (Rigidbody))]
public class Player : MonoBehaviour 
{
    #region Fields
    //input
    InputSettings input; //input manager for this player
    int playerNum;

	//Physics
	private Rigidbody body;
	#endregion

	#region Properties
	public Vector3 Position { get { return transform.position; } }

	//Physics
	public Rigidbody Body { get { return body; } }
	#endregion

	void Start()
	{
        //setup input
        input = new InputSettings(); //initialize
        input.ConfigureInput(playerNum); //bind specific controlers input to this player

		//Assign body
		body = GetComponent<Rigidbody>();
	}

	
    void OnCollisionEnter(Collision collision)
    {

    }


    public void FixedUpdate()
    {
        //update controller input
        input.UpdateInput();
    }

    //METHODS=====================================================================================================
    /// <summary>
    /// moves hand based on controller input
    /// </summary>
    void Move()
    {

    }

    /// <summary>
    /// rotates hand based on controller input
    /// </summary>
    void Rotate()
    {

    }

    /// <summary>
    /// binds passed in obj to the position and roations of the hand thats grabbing it
    /// </summary>
    /// <param name="obj"></param>
    void Grab(GameObject obj)
    {

    }
}

