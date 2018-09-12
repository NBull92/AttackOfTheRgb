using UnityEngine;
using System.Collections;

public class greenBossShuttleControl : MonoBehaviour 
{	
	public Transform LookAtTarget;
	public float damp = 6.0f;
	public Transform bulletPrefab;
	public double savedTime = 0.0;
	public int moveSpeed = 3;
	public float gravity = 20.2f;

	int randomNumber;
	int randomNumberMovement;
	
	public int shotCount = 0;
	public float hitCoolDown = 10.0f;
	private float hitCoolDownDefault;
		
	public Transform myTransform;	//current transform data of this enemy
	
	void Awake () 
	{
		myTransform = transform;	//cache transform data for easy access/performance
	}
	
	// Use this for initialization
	void Start () 
	{
		LookAtTarget = GameObject.FindWithTag("Player").transform;	//target the player	
		InvokeRepeating ("PickRandomNumber", 1.0f, 3.0f);
	}
	private void PickRandomNumber()
	{
		//yield WaitForSeconds(2);
		randomNumber = Random.Range(0,6);
	}
	
	// Update is called once per frame
	void Update () 
	{		
//		int seconds = (int)Time.time;
//		double oddEven = (seconds % 2);
//		
//		print (randomNumber);
//		
//		if(randomNumber == 1 ||  randomNumber == 5)
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
	
	public void Shoot(int seconds)
	{
		savedTime = seconds;		
		Transform bullet = (Transform)Instantiate(bulletPrefab, transform.Find("Arm1").Find("spawnPoint1").transform.position, Quaternion.identity);
		bullet.gameObject.tag = "enemyProjectile";		
		bullet.rigidbody.AddForce(transform.forward * 1000);
		//shotCount++;
		
		bullet = (Transform)Instantiate(bulletPrefab, transform.Find("Arm2").Find("spawnPoint1").transform.position, Quaternion.identity);
		bullet.gameObject.tag = "enemyProjectile";		
		bullet.rigidbody.AddForce(transform.forward * 1000);
	}
}
