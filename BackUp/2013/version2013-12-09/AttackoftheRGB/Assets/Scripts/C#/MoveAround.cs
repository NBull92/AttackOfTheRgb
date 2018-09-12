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
				}
				else
				{				
					health.health = 0;	
				}
			}			
			Destroy(hit.gameObject);
			isCollided = false;
		}
		if(hit.gameObject.tag == "greenBossProjectile")
		{
			if(!isCollided)
			{
				isCollided = true;
				gotHIT = true;
				if(health.health > 0)
				{
					health.health -= 100;
					health.transform.localScale -= new Vector3(0.02f, 0,0);
				}
				else
				{				
					health.health = 0;	
				}
			}			
			Destroy(hit.gameObject);
			isCollided = false;
		}
		if(hit.gameObject.tag == "blueBossProjectile")
		{
			if(!isCollided)
			{
				isCollided = true;
				gotHIT = true;
				if(health.health > 0)
				{
					health.health -= 150;
					health.transform.localScale -= new Vector3(0.03f, 0,0);
				}
				else
				{				
					health.health = 0;	
				}
			}			
			Destroy(hit.gameObject);
			isCollided = false;
		}
		//if collided with level bound left then respawn on the right
		if(hit.gameObject.tag == "levelBounds-Left")
		{
			transform.position = new Vector3(80f,transform.position.y,transform.position.z);
		}
		
		//if collided with level bound right then respawn on the left
		if(hit.gameObject.tag == "levelBounds-Right")
		{
			transform.position = new Vector3(-88f,transform.position.y,transform.position.z);
		}
		
		//if collided with level bound top then respawn on the bottom
		if(hit.gameObject.tag == "levelBounds-Top")
		{
			transform.position = new Vector3(transform.position.x,transform.position.y,-48f);
		}
		
		//if collided with level bound bottom then respawn on the top
		if(hit.gameObject.tag == "levelBounds-Bottom")
		{
			transform.position = new Vector3(transform.position.x,transform.position.y,57.0f);
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

	private void Update () 
	{
		enemiesKilled += 0;
		//print(enemiesKilled);
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