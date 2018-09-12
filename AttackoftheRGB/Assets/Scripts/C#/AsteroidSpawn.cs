using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour 
{
	public bool isActive; 		//	is spawn active
	private Transform asteroid;
	public Transform asteroidLarge;
	public Transform asteroidMedium;
	public Transform asteroidSmall;
	public int count = 0;
	public double savedTime = 0;
	public bool isComplete = false;
	public roundsAndEnemyManager manager;
	public float countdown = 60.0f;
	
	int asteroidTypes; //Types of asteroids
	
	void Awake () 
	{
		PickRandomNumber();
	}
	
	private void PickRandomNumber()
	{
		asteroidTypes = Random.Range(0,2);
	}	
	
	// Use this for initialization
	void Start () 
	{
		count = 0;
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (asteroidTypes)
			{
			    case 1:
					asteroid = asteroidLarge;
				break;
			    case 2:	
					asteroid = asteroidSmall;			
				break;			    
				default:
					asteroid = asteroidMedium;			
				break;
			}	
		
		int seconds = (int)Time.time;
		double time = (seconds % 2);
		if((manager.roundsCount == 4 || manager.roundsCount == 5) && isActive == true)
		{
			countdown -= Time.deltaTime;
			if(count < 1 && isComplete == false && countdown < 1.0f)
			{
				Spawn(seconds);
			}
		}
	}
		
	private void Spawn(int seconds)
	{
		if(seconds != savedTime)
		{
			Transform AST = (Transform)Instantiate(asteroid, transform.position, Quaternion.identity);	
			isComplete = true;
			count = 1;		
			AST.gameObject.tag = "Asteroid";
			AST.rigidbody.AddForce(Vector3.left * 1000);
			savedTime = seconds;
		}
	}
}
