using UnityEngine;
using System.Collections;

/// <summary>
/// Does whatever a player does
/// </summary>
[RequireComponent (typeof (Rigidbody))]
public class Player : MonoBehaviour 
{
	#region Fields
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
		//Assign body
		body = GetComponent<Rigidbody>();
	}

	
    void OnCollisionEnter(Collision collision)
    {

    }

    //Every update check if player is gonna fall off tile
    public void FixedUpdate()
    {
        
    }

}

