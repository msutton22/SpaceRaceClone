using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int speed; //speed of enemies moving
	public int xMoveDirection; //direction that enemies will go
	float nextSpawn = 0.0f; //time for next spawn
	public float spawnRate; //rate at which enemies will spawn


	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

		//if (xMoveDirection > 0)
		//{
			//checking if direction is bigger than 0
		//	xMoveDirection = -1; //if so, will turn the opposite directions
		//}
		//else
		//{
		//	xMoveDirection = 1; //else moving forward
		//}

		gameObject.GetComponent<Rigidbody2D>().velocity =
			new Vector2(xMoveDirection, 0) * speed; //game object velocity moving

		if (Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate; // The time it takes for a new enemy to spawn
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) //when you collide with enemy
	{
		if (collision.gameObject.tag.Equals ("wall"))
		{
			Destroy(gameObject);
		}
		//if (collision.gameObject.tag.Equals ("enemy")) {
		//	Destroy (collision.gameObject); //get rid of that bullet
		//}
	}
}