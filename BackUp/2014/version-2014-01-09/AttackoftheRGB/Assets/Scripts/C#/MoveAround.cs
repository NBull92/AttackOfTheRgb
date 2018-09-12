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
	//static bool dead = false;

	//getting hit
	public  bool gotHIT = false;
	public float hitCoolDown = 5.0f;

	//for tilting the player when hit
	public float smooth = 90.0f;
	public float tiltAngle = -90.0f;
	float tiltAroundX;
	
	//Health and Shield
	public healthBarScript health;
	public Shield Shield;
	public bool hasShield = false;
	public bool shieldActive = false;
	public Transform shieldTransform;
	public Transform shieldInstant;

	public int enemiesKilled = 0;
	public int waves = 1;
	
	bool isCollided = false;
	
	//Weapon
	public float shotCount = 0;
	public float shotCap = 10;
	public float weaponCoolDown;
	public bool weaponMaxedOut = false;
	public float shotCapMultiplier = 1;
	
	//Power ups
	private Ally ally;
	public bool noWeaponCap = false;
	public bool weaponSpray;
	public bool isInvincible = false;
	public float weaponPowerUpTimer = 60.0f;
	
	
	
		
	private void Start () 
	{
		enemiesKilled = 0;
		Shield = GameObject.FindGameObjectWithTag("shield").GetComponent<Shield>();
	}
	
	private void OnTriggerEnter(Collider hit)
	{
//		if(hit.gameObject.tag == "fallout")
//		{
//			dead = true;
//		}
		
		if(hit.gameObject.tag == "enemyProjectile")
		{
			if(!isCollided)
			{
				isCollided = true;
				gotHIT = true;
				if(!isInvincible)
				{
					if(Shield.shield > 0)
					{
						Shield.shield -= 50;
						Shield.transform.localScale -= new Vector3(0.01f, 0,0);	
					}
					else
					{
						if(shieldInstant != null)
						{
							Destroy(shieldInstant.gameObject);
							shieldActive = false;
							hasShield = false;
						}
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
				if(!isInvincible)
				{
					if(Shield.shield > 0)
					{
						Shield.shield -= 100;
						Shield.transform.localScale -= new Vector3(0.02f, 0,0);	
					}
					else
					{
						if(shieldInstant != null)
						{
							Destroy(shieldInstant.gameObject);
							shieldActive = false;
							hasShield = false;
						}
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
				
				if(!isInvincible)
				{
					if(Shield.shield > 0)
					{
						Shield.shield -= 150;
						Shield.transform.localScale -= new Vector3(0.03f, 0,0);	
					}
					else
					{
						if(shieldInstant != null)
						{
							Destroy(shieldInstant.gameObject);
							shieldActive = false;
							hasShield = false;
						}
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
		
		//if collided with an 'Ally' 
		if(hit.gameObject.tag == "Ally")
		{
			ally = GameObject.FindGameObjectWithTag("Ally").GetComponent<Ally>();
			
			if(ally.powerUp == "No Weapon Cap")
			{
				noWeaponCap = true;
			}
			
			if(ally.powerUp == "Weapon Spray")
			{
				weaponSpray = true;
			}
			
			if(ally.powerUp == "Shield")
			{
				hasShield = true;
				Shield.shield = 250.0;
				Shield.transform.localScale = new Vector3(0.05f,0,1);
			}
			
			if(ally.powerUp == "Invincible")
			{
				isInvincible = true;
			}			
			
			if(ally.powerUp == "Extra Health")
			{
				health.health += 150;
				health.transform.localScale += new Vector3(0.03f, 0,0);
			}			
			
			Destroy(hit.gameObject);			
		}
		
	}
	
	private void Awake () 
	{
		//enemiesKilled = 0;
	}
	

	private void Update () 
	{
		enemiesKilled += 0;
		
		CharacterController controller = GetComponent<CharacterController>();
		
		//Rotate around y - axis
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
		
		//move forward / backward
		Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);			
			
		//shoot
		if(!weaponSpray)
		{
			if(!weaponMaxedOut) // check if weapon is maxed out and waiting for cool down
			{
				if(Input.GetButtonDown("Jump"))
				{
					if(shotCount < shotCap || noWeaponCap == true)	//	if bullet cap NOT reached or there is no cap 
					{
						Transform bullet = (Transform)Instantiate(bulletPrefab,transform.Find("spawnPoint").transform.position, Quaternion.identity);
						bullet.tag = "playerProjectile";
						bullet.rigidbody.AddForce(transform.forward * 2000);
						shotCount++;
						weaponCoolDown += 1.0f;
					}
					
					if(shotCount > shotCap)
					{
						weaponMaxedOut = true;
					}
				}	
			}		
		}
		else
		{
			weaponPowerUpTimer -= Time.deltaTime;
			shotCap = 50 * shotCapMultiplier;
			if(!weaponMaxedOut) // check if weapon is maxed out and waiting for cool down
			{
				if(Input.GetButton("Jump"))
				{				
					if(shotCount < shotCap) //	if bullet cap NOT reached
					{
						Transform bullet = (Transform)Instantiate(bulletPrefab,transform.Find("spawnPoint").transform.position, Quaternion.identity);
						bullet.tag = "playerProjectile";
						bullet.rigidbody.AddForce(transform.forward * 2000);
						shotCount++;
						weaponCoolDown += 1.0f;
					}
					else
					{
						weaponMaxedOut = true;
					}
				}
			}			
		}
		
		//Weapon Cooldown and shotcount reduction
		if(weaponCoolDown > 0.0f)
		{
			if(noWeaponCap == true || weaponSpray == true || weaponCoolDown > 40.0f)
			{
				weaponCoolDown -= Time.deltaTime * 10;		
			}
			else if (weaponCoolDown > 20.0f)
			{
				weaponCoolDown -= Time.deltaTime * 3;	
			}
			else
			{
				weaponCoolDown -= Time.deltaTime;
			}
		}
		if(shotCount >= 0)
		{
			if(noWeaponCap == true || weaponSpray == true || weaponCoolDown > 41.0f)
			{
				shotCount -= Time.deltaTime * 10;		
			}
			else if (weaponCoolDown > 20.0f)
			{
				weaponCoolDown -= Time.deltaTime * 3;	
			}
			else
			{
				shotCount -= Time.deltaTime;
			}
		}
		
		// reset weapon
		if(weaponMaxedOut == true && weaponCoolDown < 1.0f)
		{
			weaponMaxedOut = false;
		}
		
		// disable weapon power ups after time has ran out
		if(weaponPowerUpTimer < 0.0f)
		{
			weaponSpray = false;	
			noWeaponCap = false;
			isInvincible = false;
			weaponPowerUpTimer = 60.0f; //reset timer ready for next time
			shotCap = 10 * shotCapMultiplier; // reset cap
		}
		
		//check for weapon power up or invincible
		if( noWeaponCap == true || weaponSpray == true || isInvincible == true)
		{
			weaponPowerUpTimer -= Time.deltaTime;
		}
		
		//check if player has a shield put it is not ative yet - then activate it
		if(hasShield && !shieldActive)
		{
			shieldInstant = (Transform)Instantiate(shieldTransform,transform.position, Quaternion.identity);
			shieldActive = true;		
			Shield.shield = 250.0;
			Shield.transform.localScale = new Vector3(0.05f,0,1);
		}
		
		//check that it has a shield - update position
		if(hasShield)
		{
			Vector3 playerPos = new Vector3(transform.position.x,transform.position.y, transform.position.z);
			shieldInstant.localPosition = playerPos;
		}
		
		//check if not no shield - destroy shield
		if(!hasShield)
		{
			if(shieldInstant != null)
			{
				Destroy(shieldInstant.gameObject);				
				Shield.shield = 0.0;
				Shield.transform.localScale = new Vector3(0,0,1);
			}
			shieldActive = false;
		}
	}
}