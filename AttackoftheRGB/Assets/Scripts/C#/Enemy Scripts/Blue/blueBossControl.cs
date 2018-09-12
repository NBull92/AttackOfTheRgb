using UnityEngine;
using System.Collections;

public class blueBossControl : MonoBehaviour 
{
	public Transform LookAtTarget;
	public float damp = 6.0f;
	public Transform bulletPrefab;
	public Transform BIGbulletPrefab;
	public double savedTime = 0.0;
	public int moveSpeed = 3;
	public float gravity = 20.2f;
	public int distanceFromPlayer = 50;

	int randomNumber;
	int randomNumberMovement;

	public Transform myTransform;	//current transform data of this enemy
	
	public int shotCount = 0;
	public float hitCoolDown = 10.0f;
	public float minihitCoolDown = 10.0f;
	private float hitCoolDownDefault = 10.0f;
		
	roundsAndEnemyManager enemiesAlive;
	
	public BlueBossHealth health;
	GUITexture gt ;
	GUITexture healthBackground;
	
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
		enemiesAlive.aliveCount = 1;
		health = GameObject.FindGameObjectWithTag("blueEnemyHealth").GetComponent<BlueBossHealth>();			
		gt = health.GetComponent(typeof(GUITexture)) as GUITexture;
		gt.enabled = true;
		healthBackground = GameObject.FindGameObjectWithTag("blueEnemyHealthBack").GetComponent(typeof(GUITexture)) as GUITexture;
		healthBackground.enabled = true;
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
		if(health.health <= 0)
		{
			gt.enabled = false;
		}							
			Vector3 tmp = transform.position;
			tmp.y = LookAtTarget.position.y;
			transform.position = tmp;
						
			//change rotation of enemy
			var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position); 
			transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp); 
			
			//move enemy
			//if(myTransform.position >= (LookAtTarget.position + Vector3(LookAtTarget.position.x + 2,LookAtTarget.position.y + 2,LookAtTarget.position.z + 2)))
			if(myTransform.position.x > (LookAtTarget.position.x + distanceFromPlayer) || myTransform.position.x < (LookAtTarget.position.x - distanceFromPlayer)
				|| myTransform.position.z > (LookAtTarget.position.z + distanceFromPlayer) || myTransform.position.z < (LookAtTarget.position.z - distanceFromPlayer))
			{
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
				
				
				if (randomNumber == 1 || randomNumber == 5)
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 10 * Time.deltaTime);
				}
				if (randomNumber == 4 )
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 10 * Time.deltaTime);
				}
				if ( randomNumber == 6)
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.back, 10 * Time.deltaTime);
				}
			}
			else
			{
				if (randomNumber == 1 || randomNumber == 3 ||  randomNumber == 5)
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 45 * Time.deltaTime);
				}
				if (randomNumber == 2 || randomNumber == 4 || randomNumber == 6 )
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 45 * Time.deltaTime);
				}				
			}		
		
		int seconds = (int)Time.time;
		double oddEven = (seconds % 2);
		
		if(myTransform.position.x > (LookAtTarget.position.x + 36) || myTransform.position.x < (LookAtTarget.position.x - 36)
			|| myTransform.position.z > (LookAtTarget.position.z + 36) || myTransform.position.z < (LookAtTarget.position.z - 36))
		{
			if(shotCount >0)
			{
				shotCount++;
			}
			if (shotCount == 20)
			{
				shotCount = 0;
			}
			if(shotCount == 0)
			{
				Shoot(seconds, false);	
			}				
		}
		else
		{
			Shoot(seconds, true);	
		}		
							
	
	}

	public void Shoot(int seconds, bool closeShots)
	{		
		if(!closeShots)
		{
			savedTime = seconds;		
			Transform bullet = (Transform)Instantiate(BIGbulletPrefab, transform.Find("spawnPoint1").transform.position, Quaternion.identity);
			bullet.gameObject.tag = "blueBossProjectile";		
			bullet.rigidbody.AddForce(transform.forward * 2500);
			
			Transform bullet2 = (Transform)Instantiate(BIGbulletPrefab, transform.Find("spawnPoint2").transform.position, Quaternion.identity);
			bullet2.gameObject.tag = "blueBossProjectile";		
			bullet2.rigidbody.AddForce(transform.forward * 2500);
			shotCount++;
		}
		else
		{
			if(seconds != savedTime)
			{
				savedTime = seconds;		
				Transform bullet = (Transform)Instantiate(bulletPrefab, transform.Find("spawnPoint3").transform.position, Quaternion.identity);
				bullet.gameObject.tag = "blueBossProjectile";		
				bullet.rigidbody.AddForce(transform.forward * 2500);
				
				Transform bullet2 = (Transform)Instantiate(bulletPrefab, transform.Find("spawnPoint4").transform.position, Quaternion.identity);
				bullet2.gameObject.tag = "blueBossProjectile";		
				bullet2.rigidbody.AddForce(transform.forward * 2500);
			}
		}
	}
}
