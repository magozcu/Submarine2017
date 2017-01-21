using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Scanner scanner;

    private float xVel = 50f;
    private float yVel = 50f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        myRigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * xVel * Time.deltaTime, Input.GetAxis("Vertical") * yVel * Time.deltaTime));

        if (Input.GetKey(KeyCode.Space))
        {
            scanner.setScan(true);
        }
	}
}
