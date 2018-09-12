using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class redEnemyControl : MonoBehaviour 
{
	public Transform LookAtTarget;
	public float damp = 6.0f;
	public Transform bulletPrefab;
	public double savedTime = 0.0;
	public int moveSpeed = 3;
	public float gravity = 20.2f;
	public int distanceFromPlayer = 15;

	int randomNumber;
	int randomNumberMovement;

	public Transform myTransform;	//current transform data of this enemy
	
	public int shotCount = 0;
	public float hitCoolDown = 5.0f;
	
	roundsAndEnemyManager enemiesAlive;
		
	//enemy bullet sound
	public AudioClip shootSound;
	
	private void Awake()
	{
		myTransform = transform;	//cache transform data for easy access/performance
	}

	private void Start () 
	{
		LookAtTarget = GameObject.FindWithTag("Player").transform;	//target the player
		InvokeRepeating ("PickRandomNumber", 1.0f, 1.0f);
		InvokeRepeating ("PickRandomNumber", 1.0f, 3.0f);
		enemiesAlive = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
		if(enemiesAlive.aliveCount == -1)
		{
			enemiesAlive.aliveCount += 2;
		}
		else
		{
			enemiesAlive.aliveCount += 1;
		}
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
						
		Vector3 tmpRotation = transform.rotation.eulerAngles;
  		tmpRotation.x = 0.0f;
  		transform.rotation = Quaternion.Euler(tmpRotation);
		
		//change rotation of enemy
		var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position); 
		transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp); 
		
		//move enemy
		//if(myTransform.position >= (LookAtTarget.position + Vector3(LookAtTarget.position.x + 2,LookAtTarget.position.y + 2,LookAtTarget.position.z + 2)))
		if(myTransform.position.x > (LookAtTarget.position.x + distanceFromPlayer) || myTransform.position.x < (LookAtTarget.position.x - distanceFromPlayer)
			|| myTransform.position.z > (LookAtTarget.position.z + distanceFromPlayer) || myTransform.position.z < (LookAtTarget.position.z - distanceFromPlayer))
		{
			//print("enemy further than player");
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			//myTransform.position.y = 1.5;	
			
			
			if (randomNumber == 1 || randomNumber == 5)
			{
				//orbit around the player at all times
				// Spin the object around the world origin at 20 degrees/second.			
				transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 20 * Time.deltaTime);
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
				transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.back, 20 * Time.deltaTime);
			}
		}
		else
		{
			if (randomNumber == 1 || randomNumber == 3 ||  randomNumber == 5)
			{
				//orbit around the player at all times
				// Spin the object around the world origin at 20 degrees/second.			
				transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 90 * Time.deltaTime);
			}
			if (randomNumber == 2 || randomNumber == 4 || randomNumber == 6 )
			{
				//orbit around the player at all times
				// Spin the object around the world origin at 20 degrees/second.			
				transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 90 * Time.deltaTime);
			}
			
		}		
				
		int seconds = (int)Time.time;
		double oddEven = (seconds % 2);
		
		if (randomNumber == 1 ||  randomNumber == 5)
		{
			Shoot(seconds);
		}
	}
	
	public void Shoot(int seconds)
	{
		if(seconds != savedTime)
		{	
			savedTime = seconds;		
			Transform bullet = (Transform)Instantiate(bulletPrefab, transform.Find("spawnPoint").transform.position, Quaternion.identity);
			bullet.gameObject.tag = "enemyProjectile";
			bullet.rigidbody.AddForce(transform.forward * 1000);
							
			// Play impact audio clip at volume 0.7						
			audio.PlayOneShot(shootSound, 0.5f);
		}
	}
}