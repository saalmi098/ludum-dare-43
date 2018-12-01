using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


	public float moveSpeed;
	public Boolean isScrolling;
	public bool followWithDelay;
	public GameObject followObject;
	
	public int height; // z axis
	
	public static CameraController instance;

	private void Awake()
	{
		instance = this;
	}
	
	void Start () {
	}
	
	void Update () {
		if (isScrolling)
		{
			AutoScroll(followObject.transform.position);	
		}
		else
		{
			MoveTo(followObject.transform.position);
		}
	}
	

	public void MoveTo(Vector2 destination)
	{
		if (followWithDelay)
		{
			Vector3 move = Vector3.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
			transform.position = move;
		}
		else
		{
			transform.position = destination;
		}

		transform.position = new Vector3(transform.position.x, transform.position.y, height);
	}

	public void AutoScroll(Vector2 destination)
	{
		Vector3 move = Vector3.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
		transform.position = new Vector3(transform.position.x+moveSpeed*Time.deltaTime, move.y, height);
	}
}
