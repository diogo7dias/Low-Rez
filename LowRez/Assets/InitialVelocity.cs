using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour 
{
	public Vector3 InitVel;

	void Start()
	{
		this.GetComponent<Rigidbody2D>().velocity = InitVel;
	}
	
}
