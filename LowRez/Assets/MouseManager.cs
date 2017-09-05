using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour 
{
	private Rigidbody2D grabbedObject = null;

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//WE CLICKED, BUT ON WHAT?
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x,mouseWorldPos3D.y);
			Vector2 dir = Vector2.zero;

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);

			if(hit != null && hit.collider != null)
			{
				//WE HIT ON SOMETHING THAT HAS A COLLIDER
				if(hit.collider.GetComponent<Rigidbody2D>() != null)
				{
					grabbedObject = hit.collider.GetComponent<Rigidbody2D>();
				}
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			grabbedObject = null;
		}
	}

	void FixedUpdate ()
	{
		if(grabbedObject != null)
		{
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x,mouseWorldPos3D.y);

			grabbedObject.position = mousePos2D;

		}
	}
}
