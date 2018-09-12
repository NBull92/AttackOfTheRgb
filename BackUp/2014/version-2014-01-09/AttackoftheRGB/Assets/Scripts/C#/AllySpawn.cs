using UnityEngine;
using System.Collections;

public class AllySpawn : MonoBehaviour 
{
	public Transform LookAtTarget;
	public float damp = 6.0f;
	public Transform myTransform;	//current transform data of this enemy	
	public int moveSpeed = 3;
	public roundsAndEnemyManager manager;
	int randomNumber;
	public bool hasSpawned = false;
	public Transform AllyPrefab;
	public double savedTime = 0.0;
	
	private void Awake()
	{
		myTransform = transform;	//cache transform data for easy access/performance
	}
	
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();	
	}
	
	// Update is called once per frame
	void Update () 
	{		
		Vector3 tmp = transform.position;
		tmp.y = LookAtTarget.position.y + 1.6f;
		transform.position = tmp;		
		
		//change rotation of enemy
		var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position); 
		transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp); 
	
//		// Spin the object around the world origin at 20 degrees/second.			
		transform.RotateAround (new Vector3(0,1.6f,0), Vector3.up, 20 * Time.deltaTime);	
		
		if(manager.roundsCount == 2 || manager.roundsCount == 5)
		{
			randomNumber = Random.Range(0,10);
			if(randomNumber == 5 && hasSpawned == false)
			{
				//spawn ally
				int seconds = (int)Time.time;
				spawn(seconds);
				hasSpawned = true;
			}
		}
		else
		{
			hasSpawned = false;
		}
	}
	
	public void spawn(int seconds)
	{
		if(seconds != savedTime)
		{	
			savedTime = seconds;		
			Transform allyInstant = (Transform)Instantiate(AllyPrefab, transform.position, Quaternion.identity);
			allyInstant.gameObject.tag = "Ally";
			//allyInstant.rigidbody.AddForce(transform.forward * 1000);
		}
	}
}