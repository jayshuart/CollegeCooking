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
    public int playerNum; //set from inspector

	//Physics
	private Rigidbody body;
    public float moveSpeed;

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

        //update players translation and rotation based on input
        Move();
        Rotate();
    }

    //METHODS=====================================================================================================
    /// <summary>
    /// moves hand based on controller input
    /// </summary>
    void Move()
    {
        //get lSticks input or both axis
        if(Mathf.Abs(input.horizontalLStickIn) > input.delay || Mathf.Abs(input.verticalLStickIn) > input.delay)
        {
            transform.position += new Vector3(input.horizontalLStickIn * moveSpeed, 0, -input.verticalLStickIn * moveSpeed);
        }
    }

    /// <summary>
    /// rotates hand based on controller input
    /// </summary>
    void Rotate()
    {
        //get lSticks input or both axis
        if (Mathf.Abs(input.horizontalRStickIn) > input.delay || Mathf.Abs(input.verticalRStickIn) > input.delay)
        {
            
        }
    }

    /// <summary>
    /// binds passed in obj to the position and roations of the hand thats grabbing it
    /// </summary>
    /// <param name="obj"></param>
    void Grab(GameObject obj)
    {

    }
}

