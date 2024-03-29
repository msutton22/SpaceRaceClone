﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shipBehavior : MonoBehaviour
{
    public float speed; //variable for speed of the spaceship
	public float score = 0; //score holder
	public GameObject scoreInGame;
    public GameObject projectilePrefabs; //Adding Prefab of projectiles
	public GameObject projectile2Prefabs; //Adding Prefab of projectiles
    private List <GameObject> Projectiles = new List<GameObject> ();  //creating a list of projectile objects
	private List <GameObject> Projectiles2 = new List<GameObject> ();  //creating a list of projectile objects
    private float projectileVelocity; //variable for velocity of the projectiles
	public AudioSource Shoot; //audio source variable
	
    // Start is called before the first frame update
    void Start()
    {
	    AudioSource[] audios = GetComponents<AudioSource> (); //making an array of audio sources 
	    Shoot = audios [0];
        projectileVelocity = 6; //stating projectile velocity
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			GameObject bullet = (GameObject)Instantiate (projectilePrefabs, transform.position, Quaternion.identity); //create a projectile object in the current position
			Projectiles.Add (bullet); //add actual projectial or bullet to scene
			Shoot.Play(); //play shooting sound
	
		}
	    
	    if (Input.GetKeyDown (KeyCode.LeftArrow))
	    {
		    GameObject bullet2 = (GameObject)Instantiate (projectile2Prefabs, transform.position, Quaternion.identity); //create a projectile object in the current position
		    Projectiles2.Add(bullet2);
		    Shoot.Play(); //play shooting sound

	    }

	    for (int i = 0; i < Projectiles.Count; i++) { //loop to see how many projectiles are in the scene
		    GameObject goBullet = Projectiles [i]; //going through list of projectiles to see number of projectiles
		    if (goBullet != null) { //checking if goBullet is null
			    goBullet.transform.Translate (new Vector3 (0, 1) * Time.deltaTime * projectileVelocity); //Projectiles moving at given velocity over time
			    Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position); // Finding the position of the bullet
			    if (bulletScreenPos.y >= Screen.height) { //checking to see if the bullet has gone out of the screen
				    DestroyObject (goBullet); //will get rid of bullet if bullet leaves screen
				    Projectiles.Remove (goBullet); //Projectile will be removed 
			    }
		    }
	    }

	    for (int i = 0; i < Projectiles2.Count; i++) { //loop to see how many projectiles are in the scene
		    GameObject goBullet = Projectiles2 [i]; //going through list of projectiles to see number of projectiles
		    if (goBullet != null) { //checking if goBullet is null
			    goBullet.transform.Translate (new Vector3 (-1, 0) * Time.deltaTime * projectileVelocity); //Projectiles moving at given velocity over time
			    Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position); // Finding the position of the bullet
			    if (bulletScreenPos.y >= Screen.height) { //checking to see if the bullet has gone out of the screen
				    DestroyObject (goBullet); //will get rid of bullet if bullet leaves screen
				    Projectiles2.Remove (goBullet); //Projectile will be removed 
			    }
		    }
	    }
	    
		if (Input.GetKey (KeyCode.UpArrow)) {
			this.GetComponent<Transform> ().Translate (new Vector3 (0, speed));	//spaceship willl move up at a positive speed dictated elsewhere		
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			this.GetComponent<Transform> ().Translate (new Vector3 (0, -speed));	//spaceship willl move down at a negative speed dictated elsewhere		
		}
    }
	
	void OnCollisionEnter2D(Collision2D collision) //when you collide with enemy
	{
		if (collision.gameObject.tag.Equals ("wall")) {
			score += 1;
			scoreInGame.gameObject.GetComponent<Text>().text = ("" + (int)score);
			gameObject.transform.position = new Vector3(4.34f, -4.2f, 0);
		}
		if (collision.gameObject.tag.Equals ("enemy")) {
			Destroy (collision.gameObject); //get rid of that bullet
			Camera.main.GetComponent<shakeBehavior>().TriggerShake();
			gameObject.transform.position = new Vector3(4.34f, -4.2f, 0);
		}
		if (collision.gameObject.tag.Equals ("bullet2")) {
			Destroy (collision.gameObject); //get rid of that bullet
			Camera.main.GetComponent<shakeBehavior>().TriggerShake();
			gameObject.transform.position = new Vector3(4.34f, -4.2f, 0);
			if (score != 0)
			{
				score -= 1;
				scoreInGame.gameObject.GetComponent<Text>().text = ("" + (int)score);
			}
		}
	}

	
}
