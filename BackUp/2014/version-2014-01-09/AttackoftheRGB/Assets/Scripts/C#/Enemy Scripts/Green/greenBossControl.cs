using UnityEngine;
using System.Collections;

public class greenBossControl : MonoBehaviour 
{
	public Transform LookAtTarget;
	public float damp = 6.0f;
	public Transform bulletPrefab;
	public Transform BIGbulletPrefab;
	public double savedTime = 0.0;
	public int moveSpeed = 3;
	public float gravity = 20.2f;

	int randomNumber;
	int randomNumberMovement;

	public Transform myTransform;	//current transform data of this enemy
	
	public int shotCount = 0;
	public float hitCoolDown = 10.0f;
	public float minihitCoolDown = 10.0f;
	private float hitCoolDownDefault = 10.0f;
		
	roundsAndEnemyManager enemiesAlive;
	
	public GreenBossHealth health;
	GUITexture gt ;
	
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
		enemiesAlive.aliveCount += 1;
		health = GameObject.FindGameObjectWithTag("greenEnemyHealth").GetComponent<GreenBossHealth>();			
		gt = health.GetComponent(typeof(GUITexture)) as GUITexture;
		gt.enabled = true;
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
			if(myTransform.position.x > (LookAtTarget.position.x + 7) || myTransform.position.x < (LookAtTarget.position.x - 7)
				|| myTransform.position.z > (LookAtTarget.position.z + 7) || myTransform.position.z < (LookAtTarget.position.z - 7))
			{
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
				
				
				if (randomNumber == 1 || randomNumber == 5)
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 20 * Time.deltaTime);
				}
				if (randomNumber == 4 )
				{
					//orbit around the player at all times
					// Spin the object around the world origin at 20 degrees/second.			
					transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 20 * Time.deltaTime);
				}
				if ( randomNumber == 6)
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
		
		if(randomNumber == 1 ||  randomNumber == 5)
		{
			if(shotCount >0)
			{
				//print(shotCount);
				shotCount++;
			}
			if (shotCount == 150)
			{
				shotCount = 0;
				//print("shotcount = 10");
			}
			if(shotCount == 0)
			{
				Shoot(seconds, false);	
			}				
		}
		else
		{
			if(hitCoolDown > 0)
			{
				hitCoolDown -= Time.deltaTime;
				//need some kind of animation of effect to show this
			}
			else
			{
				//shotCount = 0;
				hitCoolDown = hitCoolDownDefault;
			}
		}
		if(randomNumber != 1 ||  randomNumber == 5)
		{			
			Shoot(seconds,true);
		}
		else
		{
			if(hitCoolDown > 0)
			{
				minihitCoolDown -= Time.deltaTime;
				//need some kind of animation of effect to show this
			}
			else
			{
				shotCount = 0;
				minihitCoolDown = hitCoolDownDefault;
			}
		}	
	}

	public void Shoot(int seconds,bool shuttles)
	{	
		if(seconds != savedTime)
		{
			if(!shuttles)
			{				
				savedTime = seconds;		
				Transform bullet = (Transform)Instantiate(BIGbulletPrefab, transform.Find("spawnPoint1").transform.position, Quaternion.identity);
				bullet.gameObject.tag = "greenBossProjectile";		
				bullet.rigidbody.AddForce(transform.forward * 2000);
				shotCount++;
			}			
			else
			{
				savedTime = seconds;		
				Transform bullet = (Transform)Instantiate(bulletPrefab, transform.Find("Shuttle1").Find("Arm1").Find("spawnPoint2").transform.position, Quaternion.identity);
				bullet.gameObject.tag = "enemyProjectile";		
				bullet.rigidbody.AddForce(transform.forward * 2000);
				//shotCount++;
				
				bullet = (Transform)Instantiate(bulletPrefab, transform.Find("Shuttle1").Find("Arm2").Find("spawnPoint3").transform.position, Quaternion.identity);
				bullet.gameObject.tag = "enemyProjectile";		
				bullet.rigidbody.AddForce(transform.forward * 2000);
				
				bullet = (Transform)Instantiate(bulletPrefab, transform.Find("Shuttle2").Find("Arm1").Find("spawnPoint2").transform.position, Quaternion.identity);
				bullet.gameObject.tag = "enemyProjectile";		
				bullet.rigidbody.AddForce(transform.forward * 2000);
				//shotCount++;
				
				bullet = (Transform)Instantiate(bulletPrefab, transform.Find("Shuttle2").Find("Arm2").Find("spawnPoint3").transform.position, Quaternion.identity);
				bullet.gameObject.tag = "enemyProjectile";		
				bullet.rigidbody.AddForce(transform.forward * 2000);
			}
		}
	}
}
