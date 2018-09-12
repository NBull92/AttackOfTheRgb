using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

public class MoveAround : MonoBehaviour 
{
	//moving around
	public float speed = 3.0f;
	public float rotateSpeed = 3.0f;

	//var jumpSpeed : float = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	//shooting
	public Transform bulletPrefab;

	//dying
	static bool dead = false;

	//getting hit
	public  bool gotHIT = false;
	public float hitCoolDown = 5.0f;

	//for tilting the player when hit
	public float smooth = 90.0f;
	public float tiltAngle = -90.0f;
	float tiltAroundX;

	public healthBarScript health;

	public int enemiesKilled = 0;
	public int waves = 1;
	
	bool isCollided = false;

	private void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "fallout")
		{
			dead = true;
		}
		
		if(hit.gameObject.tag == "enemyProjectile")
		{
			if(!isCollided)
			{
				isCollided = true;
				gotHIT = true;
				if(health.health > 0)
				{
					health.health -= 50;
					health.transform.localScale -= new Vector3(0.01f, 0,0);
					print (health.transform.localScale);
				}
				else
				{				
					health.health = 0;	
				}
			}
			Destroy(hit.gameObject);
		}
		if(hit.gameObject.tag == "levelBounds")
		{
			//player respawn at the opposite levelBounds	
			//print("hit trigger");	
			print(transform.position.x);
			respawn();
		}
		
	}
	private void Awake () 
	{
		//enemiesKilled = 0;
	}
	
	private void Start () 
	{
		enemiesKilled = 0;
	}

	private void respawn()
	{	
		if(transform.position.z < 50 && transform.position.z > 48)
		{
			//top trigger
			//print("top");
			transform.position = new Vector3(transform.position.x,transform.position.y,-48f);
		}
		else if(transform.position.z > -60 && transform.position.z < -40)
		{
			//bottom trigger
			//print("bottom");
			transform.position = new Vector3(transform.position.x,transform.position.y,48.0f);
		}	
		else if(transform.position.x < 82 && transform.position.x > 79)
		{
			//right trigger
			//print("right");
			transform.position = new Vector3(-88f,transform.position.y,transform.position.z);
		}	
		else if(transform.position.x > -98 && transform.position.x < -79)
		{
			//left trigger
			//print("left");
			transform.position = new Vector3(80f,transform.position.y,transform.position.z);
		}
	}

	private void Update () 
	{
		if(gotHIT)
		{
			print (hitCoolDown);
			if(hitCoolDown > 0)
			{
				hitCoolDown -= Time.deltaTime;
				//need some kind of animation of effect to show this
			}
			else
			{
				gotHIT = false;
				hitCoolDown = 3.0f;
				isCollided = false;
			}
		}
		enemiesKilled += 0;
		print(enemiesKilled);
		CharacterController controller = GetComponent<CharacterController>();
		
		//Rotate around y - axis
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
		
		//move forward / backward
		 Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);			
			
		//shoot
		if(Input.GetButtonDown("Jump"))
		{
			Transform bullet = (Transform)Instantiate(bulletPrefab,transform.Find("spawnPoint").transform.position, Quaternion.identity);
			bullet.tag = "playerProjectile";
			bullet.rigidbody.AddForce(transform.forward * 2000);
		}
	}
}