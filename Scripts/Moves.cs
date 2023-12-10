using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{

	[SerializeField] Rigidbody	    rb;
	[SerializeField] float		    speed;
    //private          bool           jump = true;
    [SerializeField] Camera          cam;

    // Start is called before the first frame update
    void Start()
    {}

	void Update()
	{
		//print(transform.position.x + " / " + transform.position.z);
		Vector3 xMove = cam.transform.right * Input.GetAxis("Horizontal");
		Vector3 yMove = cam.transform.forward * Input.GetAxis("Vertical");

		xMove = new Vector3(xMove.x, 0, xMove.z);
		yMove = new Vector3(yMove.x, 0, yMove.z);
		
		Vector3 mov = new Vector3(xMove.x + yMove.x, 0, xMove.z + yMove.z);

		rb.velocity = mov * speed;
    }
}