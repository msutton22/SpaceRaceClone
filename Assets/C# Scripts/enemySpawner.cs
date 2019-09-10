using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy; //creating game object from prefab
    public float randX; //random variable for x
    float randY;  //random variable for y
    Vector2 whereToSpawn; //Vector to show where the enemy will spawn
    public float spawnRate = 1f; //the rate at which enemies will spawn
    float nextSpawn = 0.0f;  //keeping track of time to next enemy
    private float gametimer = 110f;




    // Use this for initialization
    void Start ()
    {
        enemy.GetComponent<Enemy>().speed = 3;
    }

    // Update is called once per frame
    void Update () {
		
        gametimer -= Time.deltaTime;
        Debug.Log(enemy.GetComponent<Enemy>().speed);

        if (gametimer <= 55f)
        {
            spawnRate = 0.75f;
            enemy.GetComponent<Enemy>().speed = 5;
        }
        else
        {
            spawnRate = 1f;
        }
        
        if (Time.time > nextSpawn) { //checking if new enemy should be spawned
            nextSpawn = Time.time + spawnRate; // The time it takes for a new enemy to spawn
           // randX = Random.Range (-8.4f, 8.4f); //finding a random x value in a range
            randY = Random.Range (4.5f, -2.8f); //finding a random y value in a range
            whereToSpawn = new Vector2 (randX, randY); //will spawn enemy in random range number coordinates
            Instantiate (enemy, whereToSpawn, Quaternion.identity); //Enemy will be on the screen from prefab
        }
    }
}
