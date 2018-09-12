using UnityEngine;
using System.Collections;

public class enemyControlsMainMenu : MonoBehaviour 
{
	

	Transform LookAtTarget;
	float damp = 6.0f;
	Transform bulletPrefab;
	double savedTime = 0;
	int moveSpeed = 3;		//speed of enemy movement
	int rotationSpeed = 3;	//speed of rotation
	float gravity = 20.0f;

	int randomNumber;
	int randomNumberMovement;

	Transform myTransform ;	//current transform data of this enemy
	//var shooting : shootingScript;
	//myTransform.position.y = 1.5;

	private void Awake()
	{
		myTransform = transform;	//cache transform data for easy access/performance
	}

	private void Start () 
	{
		LookAtTarget = GameObject.FindWithTag("MainMenu").transform;	//target the player
		
	}
	private void PickRandomNumber()
	{
		//yield WaitForSeconds(2);
		randomNumber = Random.Range(0,6);
	}
	private void PickRandomNumberMovement()
	{
		//yield WaitForSeconds(2);
		randomNumberMovement = Random.Range(0,6);
	}
	
	private void Update () 
	{ 
			Vector3 tmp = transform.position;
			tmp.y = LookAtTarget.position.y;
			transform.position = tmp;
			
			//change rotation of enemy
			Quaternion rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position); 
			transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp); 
			
			//move enemy
			//if(myTransform.position >= (LookAtTarget.position + Vector3(LookAtTarget.position.x + 2,LookAtTarget.position.y + 2,LookAtTarget.position.z + 2)))
			if(myTransform.position.x > (LookAtTarget.position.x + 20) || myTransform.position.x < (LookAtTarget.position.x - 20)
				|| myTransform.position.z > (LookAtTarget.position.z + 20) || myTransform.position.z < (LookAtTarget.position.z - 20))
			{
				//print("enemy further than player");
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
				//myTransform.position.y = 1.5;	
				
				
				if (randomNumber == 1 || randomNumber == 5)
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround ( new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 20 * Time.deltaTime);
				}
				if (randomNumber == 2 || randomNumber == 4 )
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 20 * Time.deltaTime);
				}
				if (randomNumber == 3 || randomNumber == 6)
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround ( new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.back, 20 * Time.deltaTime);
				}
			}
			else
			{
				if (randomNumber == 1 || randomNumber == 3 ||  randomNumber == 5)
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround ( new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 90 * Time.deltaTime);
				}
				if (randomNumber == 2 || randomNumber == 4 || randomNumber == 6 )
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround ( new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 90 * Time.deltaTime);
				}
				
			}		
			
			double seconds = Time.time;
			double oddEven = (seconds % 2);
			
			if (randomNumber == 1 ||  randomNumber == 5)
			{
				Shoot(seconds);
			}
	}
	
	public void Shoot(double seconds)
	{
		if(seconds != savedTime)
		{
			Transform bullet = (Transform)Instantiate(bulletPrefab, transform.Find("spawnPoint").transform.position, Quaternion.identity);
			bullet.gameObject.tag = "enemyProjectile";
			bullet.rigidbody.AddForce(transform.forward * 1000);
		
			savedTime = seconds;
		}
	}

	///currently need to add a slight more AI to this so that the enemy walks back and forward and jumps in the air.
}