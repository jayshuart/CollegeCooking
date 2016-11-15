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

    public float rotationSpeed;
    public float rotationMin;
    public float rotationMax;

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

            //update pos by the input
            body.AddForce(new Vector3(-input.verticalLStickIn * moveSpeed, 0, -input.horizontalLStickIn * moveSpeed));
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
            //backward
            if(input.horizontalRStickIn > 0)
            {
                //rotate
                transform.Rotate(Vector3.right * -rotationSpeed);
            }

            //forward
            if (input.horizontalRStickIn < 0)
            {
                //check if we are at limit of rotation range
                if (transform.localRotation.eulerAngles.x < rotationMax)
                {
                    //rotate
                    transform.Rotate(Vector3.right * rotationSpeed);
                }
            }

            //left
            if (input.verticalRStickIn > 0)
            {
                //check if we are at limit of rotation range
                if (transform.rotation.y < rotationMax)
                {
                    //rotate
                    transform.Rotate(Vector3.forward * -rotationSpeed);
                }
            }

            //right
            if (input.verticalRStickIn < 0)
            {
                //check if we are at limit of rotation range
                if (transform.rotation.y > -rotationMax)
                {
                    //rotate
                   transform.Rotate(Vector3.forward * rotationSpeed);
                }
            }

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

