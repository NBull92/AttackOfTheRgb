#pragma strict
//moving around
var speed = 3.0;
var rotateSpeed = 3.0;

//var jumpSpeed : float = 8.0;
var gravity : float = 20.0;
private var moveDirection : Vector3 = Vector3.zero;
//shooting
var bullitPrefab:Transform;

//dying
static var dead = false;

//getting hit
static var gotHIT = false;

//for tilting the player when hit
var smooth = 90.0;
var tiltAngle = -90.0;;
var tiltAroundX;

var health: HealthBarScript;

public var enemiesKilled : int = 0;
var waves : int = 1;


function OnTriggerEnter(hit : Collider)
{
	if(hit.gameObject.tag == "fallout")
	{
		dead = true;
		//subtract life here
		//HealthControlJS.LIVES -= 1;
		//HealthControlJS.HITS = 3;
	}
	
	if(hit.gameObject.tag == "enemyProjectile")
	{
		gotHIT = true;
		health.health = health.health - 5;
		health.transform.localScale.x = health.transform.localScale.x  - 0.005;
		//HealthControlJS.HITS += 1;
		//Destroy(gameObject);
		
	}
	if(hit.gameObject.tag == "levelBounds")
	{
		//player respawn at the opposite levelBounds	
		//print("hit trigger");	
		print(transform.position.x);
		respawn();
	}
	
}
function Awake () 
{
	//enemiesKilled = 0;
}


function Start () 
{
	enemiesKilled = 0;
}

function respawn()
{	
	if(transform.position.z < 50 && transform.position.z > 48)
	{
		//top trigger
		//print("top");
		transform.position.z = -48;
	}
	else if(transform.position.z > -60 && transform.position.z < -40)
	{
		//bottom trigger
		//print("bottom");
		transform.position.z = 48;
	}	
	else if(transform.position.x < 82 && transform.position.x > 79)
	{
		//right trigger
		//print("right");
		transform.position.x = -88;
	}	
	else if(transform.position.x > -98 && transform.position.x < -79)
	{
		//left trigger
		//print("left");
		transform.position.x = 80;
	}
}

function Update () 
{
	enemiesKilled += 0;
	print(enemiesKilled);
	var controller : CharacterController = GetComponent(CharacterController);
	
	//Rotate around y - axis
	transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
	
	//move forward / backward
	var forward = transform.TransformDirection(Vector3.forward);
	var curSpeed = speed * Input.GetAxis("Vertical");
	controller.SimpleMove(forward * curSpeed);	
	
	//var tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
    //var tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;		
		
	//shoot
	if(Input.GetButtonDown("Jump"))
	{
		var bullit = Instantiate(bullitPrefab,  transform.Find("spawnPoint").transform.position, Quaternion.identity);
		bullit.tag = "playerProjectile";
		bullit.rigidbody.AddForce(transform.forward * 2000);
	}
	
    		
    //var target = Quaternion.Euler (0, 0, 0);
    //Dampen towards the target rotation
    //transform.rotation = Quaternion.Slerp(transform.rotation, target,
     //time.deltaTime * smooth);
    //                               
				//dead = false;
	
		
	
		// jump
	//	if(!dead)
	//	{
     //   	if (Input.GetButton("Jump")) 
	//		{
	//			moveDirection.y = jumpSpeed;
    //    	}
    //	}
    //	else
    //	{
    //		if (Input.GetButton("Jump")) 
	//		{
	//			moveDirection.y = jumpSpeed;		 
	//			// Smoothly tilts a transform towards a target rotation.
			
	//			tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
    			//var tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
    		
    //			var target = Quaternion.Euler (0, 0, 0);
    //			// Dampen towards the target rotation
    //			transform.rotation = Quaternion.Slerp(transform.rotation, target,
     //                              Time.deltaTime * smooth);
    //                               
	//			dead = false;
    //    	}
    //	}
	//}
	//apply gravity
	//moveDirection.y -= (gravity * Time.deltaTime) * 2;
	
	 // Move the controller
    //controller.Move(moveDirection * Time.deltaTime);
    
    //if(dead)
	//{
    	//target = Quaternion.Euler (-90, 0, 0);
    	// Dampen towards the target rotation
    	//transform.rotation = Quaternion.Slerp(transform.rotation, target,
        //                           Time.deltaTime * smooth);

		//transform.position = Vector3(7.1,1.8,-10);
	//}
}
@script RequireComponent(CharacterController);