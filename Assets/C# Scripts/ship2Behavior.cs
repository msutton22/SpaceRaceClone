using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ship2Behavior : MonoBehaviour
{
    public float speed; //variable for speed of the spaceship
	public float score = 0; //score holder
	private int idleTimer = 0;
	public GameObject scoreInGame; //adding game object for score text
    public GameObject projectilePrefabs; //Adding Prefab of projectiles
    private List <GameObject> Projectiles = new List<GameObject> ();  //creating a list of projectile objects
    private float projectileVelocity; //variable for velocity of the projectiles
    // Start is called before the first frame update
    void Start()
    {
        projectileVelocity = 6; //stating projectile velocity
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.D))  //if the spacebar is pressed 
		{
			GameObject bullet = (GameObject)Instantiate (projectilePrefabs, transform.position, Quaternion.identity); //create a projectile object in the current position
			Projectiles.Add (bullet); //add actual projectial or bullet to scene
	
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
		if (Input.GetKey (KeyCode.W)) {
			this.GetComponent<Transform> ().Translate (new Vector3 (0, speed));	//spaceship willl move up at a positive speed dictated elsewhere		
		}
		if (Input.GetKey (KeyCode.S)) {
			this.GetComponent<Transform> ().Translate (new Vector3 (0, -speed));	//spaceship willl move down at a negative speed dictated elsewhere		
		}
    }
	
	void OnCollisionEnter2D(Collision2D collision) //when you collide with enemy
	{
		if (collision.gameObject.tag.Equals ("wall")) {
			score += 1;
			scoreInGame.gameObject.GetComponent<Text>().text = ("" + (int)score);
			gameObject.transform.position = new Vector3(-4.34f, -4.2f, 0);
		}
		if (collision.gameObject.tag.Equals ("enemy")) {
			Destroy (collision.gameObject); //get rid of that bullet
			Camera.main.GetComponent<shakeBehavior>().TriggerShake();
			gameObject.transform.position = new Vector3(-4.34f, -4.2f, 0);
		}
	}

}