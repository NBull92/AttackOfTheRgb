using UnityEngine;
using System.Collections;

public class greenBossShuttleControl : MonoBehaviour 
{	
	public Transform LookAtTarget;
	public float damp = 6.0f;
	//public Transform bulletPrefab;
	public double savedTime = 0.0;
	public int moveSpeed = 3;
	public float gravity = 20.2f;

	int randomNumber;
	int randomNumberMovement;

	public Transform myTransform;	//current transform data of this enemy
	
	public bool isShuttleDetached = true;
	
	
	void Awake () 
	{
		myTransform = transform;	//cache transform data for easy access/performance
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isShuttleDetached)
		{
			Vector3 tmp = transform.position;
			tmp.y = LookAtTarget.position.y;
			transform.position = tmp;
			
			
			//change rotation of enemy
			var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position); 
			transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp); 
			
			if(myTransform.name == "Shuttle1")
			{
				//move enemy
				//if(myTransform.position >= (LookAtTarget.position + Vector3(LookAtTarget.position.x + 2,LookAtTarget.position.y + 2,LookAtTarget.position.z + 2)))
				if(myTransform.position.x > (LookAtTarget.position.x + 8) || myTransform.position.x < (LookAtTarget.position.x - 8)
					|| myTransform.position.z > (LookAtTarget.position.z + 8) || myTransform.position.z < (LookAtTarget.position.z - 8))
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
			}
			
			if(myTransform.name == "Shuttle2")
			{
				//move enemy
				//if(myTransform.position >= (LookAtTarget.position + Vector3(LookAtTarget.position.x + 2,LookAtTarget.position.y + 2,LookAtTarget.position.z + 2)))
				if(myTransform.position.x > (LookAtTarget.position.x + 8) || myTransform.position.x < (LookAtTarget.position.x - 8)
					|| myTransform.position.z > (LookAtTarget.position.z + 8) || myTransform.position.z < (LookAtTarget.position.z - 8))
				{
					//print("enemy further than player");
					myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
					//myTransform.position.y = 1.5;	
					
					
					if (randomNumber == 1 || randomNumber == 5)
					{
						//orbit around the player at all times
						// Spin the object around the world origin at 20 degrees/second.			
						transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 20 * Time.deltaTime);
					}
					if (randomNumber == 2 || randomNumber == 4 )
					{
						//orbit around the player at all times
						// Spin the object around the world origin at 20 degrees/second.			
						transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 20 * Time.deltaTime);
					}
					if (randomNumber == 3 || randomNumber == 6)
					{
						//orbit around the player at all times
						// Spin the object around the world origin at 20 degrees/second.			
						transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.forward, 20 * Time.deltaTime);
					}
				}
				else
				{
					if (randomNumber == 1 || randomNumber == 3 ||  randomNumber == 5)
					{
						//orbit around the player at all times
						// Spin the object around the world origin at 20 degrees/second.			
						transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 90 * Time.deltaTime);
					}
					if (randomNumber == 2 || randomNumber == 4 || randomNumber == 6 )
					{
						//orbit around the player at all times
						// Spin the object around the world origin at 20 degrees/second.			
						transform.RotateAround (new Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 90 * Time.deltaTime);
					}
					
				}		
			}
			
			
			
			
			
			int seconds = (int)Time.time;
			double oddEven = (seconds % 2);
			
	//		if(shotCount != 10)
	//		{
	//			Shoot(seconds);
	//		}
	//		else
	//		{
	//			if(hitCoolDown > 0)
	//			{
	//				hitCoolDown -= Time.deltaTime;
	//				//need some kind of animation of effect to show this
	//			}
	//			else
	//			{
	//				shotCount = 0;
	//				hitCoolDown = hitCoolDownDefault;
	//			}
	//		}
				
			
		}
	

		}	
	
//	public void Shoot(int seconds)
//	{
//		savedTime = seconds;		
//		Transform bullet = (Transform)Instantiate(bulletPrefab, transform.Find("spawnPoint1").transform.position, Quaternion.identity);
//		bullet.gameObject.tag = "enemyProjectile";		
//		bullet.rigidbody.AddForce(transform.forward * 1000);
//		//shotCount++;
//		
//		bullet = (Transform)Instantiate(bulletPrefab, transform.Find("spawnPoint2").transform.position, Quaternion.identity);
//		bullet.gameObject.tag = "enemyProjectile";		
//		bullet.rigidbody.AddForce(transform.forward * 1000);
//	}
	}