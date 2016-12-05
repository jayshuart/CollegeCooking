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
    private bool emptyHand; //is there something in our hand?

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

        //set default field values
        emptyHand = true; //nothing grabbed, so nothing in our hand
	}

	
    void OnCollisionStay(Collision collision)
    {
        //check for grab(r trigger) being pushed down
        if(input.rTriggerIn > 0)
        {
            //grab an object
            Grab(collision.gameObject);
        }
        
    }


    public void FixedUpdate()
    {
        //update controller input
        input.UpdateInput();

        //update players translation and rotation based on input
        Move();
        Rotate();

        //ungrab if R Trigger is let go
        LetGo();
    }

    //METHODS=====================================================================================================
    #region Methods
    /// <summary>
    /// moves hand based on controller input
    /// </summary>
    void Move()
    {
        //get lSticks input or both axis
        if(Mathf.Abs(input.horizontalLStickIn) > input.delay || Mathf.Abs(input.verticalLStickIn) > input.delay)
        {

            //update pos for the x/z plane by the input
            body.AddForce(new Vector3(-input.verticalLStickIn * moveSpeed, 0, -input.horizontalLStickIn * moveSpeed));
        }

        //get rSticks input or both axis
        if (Mathf.Abs(input.horizontalRStickIn) > input.delay)
        {
            //check if Ltrigger is not being held down(shouldnt be)
            if (input.lTriggerIn == 0)
            {
                //it is so we should use RStick to move on the y axis
                body.AddForce(new Vector3(0, -input.horizontalRStickIn * moveSpeed, 0));
            }
        }

        //add drag to stop us from constantly moving
        body.AddForce(-body.velocity*2.0f);
    }

    /// <summary>
    /// rotates hand based on controller input
    /// </summary>
    void Rotate()
    {
        //get lSticks input or both axis and check if left rigger is being held down
        if (Mathf.Abs(input.horizontalRStickIn) > input.delay || Mathf.Abs(input.verticalRStickIn) > input.delay)
        {
            //backward
            if(input.lTriggerIn > 0 && input.horizontalRStickIn > 0) //check for trigger being down and stick being moved
            {
                //rotate on forward axis in the world oientation
                transform.Rotate(Vector3.forward * rotationSpeed, Space.World);
            }
            
            //forward
            if (input.lTriggerIn > 0 && input.horizontalRStickIn < 0)
            {
                //check if we are at limit of rotation range
                if (transform.localRotation.eulerAngles.x < rotationMax)
                {
                    //rotate
                }
                transform.Rotate(Vector3.forward * -rotationSpeed, Space.World);

            }
            
            //left
            if (input.lTriggerIn > 0 && input.verticalRStickIn < 0)
            {
                //check if we are at limit of rotation range
                if (transform.rotation.y < rotationMax)
                {
                    //rotate
                }
                transform.Rotate(Vector3.right * rotationSpeed, Space.World);

            }
            
            //right
            if (input.lTriggerIn > 0 && input.verticalRStickIn > 0)
            {
                //check if we are at limit of rotation range
                if (transform.rotation.y > -rotationMax)
                {
                    //rotate
                }
                transform.Rotate(Vector3.right * -rotationSpeed, Space.World);

            }
        }

        //check for Left Bumper use
        if(input.lBumper)
        {
            //rotate hand around its y axis(not world) to the left
            transform.Rotate(Vector3.up * -rotationSpeed);
        }

        //check for Right Bumper use
        if (input.rBumper)
        {
            //rotate hand around its y axis(not world) to the right
            transform.Rotate(Vector3.up * rotationSpeed);
        }
    }

    /// <summary>
    /// binds passed in obj to the position and roations of the hand thats grabbing it
    /// </summary>
    /// <param name="obj"> object to attempt a grab on</param>
    void Grab(GameObject obj)
    {
        //check for object being grabable, and the hand being empty
        if (obj.tag == "Grabable" && emptyHand)
        {
            //bind 'grabbed' object to the hand
            obj.transform.parent = gameObject.transform; //set parent
            Destroy(obj.GetComponent<Rigidbody>()); //get rid of the rigidbody so physics isnt weird

            //update hand being full so we dont grab multiple objects
            emptyHand = false;
        }
    }

    /// <summary>
    /// let go of whatever object is being held
    /// </summary>
    void LetGo()
    {
       //check if R trigger has been let go and if there is something being grabbed
       if(input.rTriggerIn == 0 && !emptyHand)
        {
            //get child of the hand
            GameObject child = gameObject.transform.GetChild(1).gameObject;

            //set its parent to not be the hand anymore
            child.transform.parent = null;

            //add a rigidbody back so itll have physics
            child.AddComponent<Rigidbody>();

            Rigidbody rb = child.GetComponent<Rigidbody>();
            rb.useGravity = true;

            //set hand to eb empty again
            emptyHand = true;
        }
    }

    #endregion
}

