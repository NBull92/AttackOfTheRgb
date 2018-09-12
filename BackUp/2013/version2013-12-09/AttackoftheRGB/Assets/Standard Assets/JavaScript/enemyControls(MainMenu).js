#pragma strict

var LookAtTarget : Transform;
var damp = 6.0;
var bullitPrefab : Transform;
var savedTime = 0;
var moveSpeed = 3;		//speed of enemy movement
var rotationSpeed = 3;	//speed of rotation
var gravity : float = 20.0;

var randomNumber;
var randomNumberMovement;

var myTransform : Transform;	//current transform data of this enemy
//var shooting : shootingScript;
//myTransform.position.y = 1.5;

function Awake()
{
	myTransform = transform;	//cache transform data for easy access/performance
}

function Start () 
{
	LookAtTarget = GameObject.FindWithTag("MainMenu").transform;	//target the player
	
}
function PickRandomNumber()
{
	//yield WaitForSeconds(2);
	randomNumber = Random.Range(0,6);
}
function PickRandomNumberMovement()
{
	//yield WaitForSeconds(2);
	randomNumberMovement = Random.Range(0,6);
}
function Update () 
{ 
	//shooting = GetComponent(shootingScript);
	//if(LookAtTarget) 
	//{ 
		transform.position.y = LookAtTarget.position.y;
		//change rotation of enemy
		var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position); 
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
    			transform.RotateAround (Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 20 * Time.deltaTime);
			}
			if (randomNumber == 2 || randomNumber == 4 )
    		{
				//orbit around the player at all times
				// Spin the object around the world origin at 20 degrees/second.			
    			transform.RotateAround (Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 20 * Time.deltaTime);
			}
			if (randomNumber == 3 || randomNumber == 6)
    		{
				//orbit around the player at all times
				// Spin the object around the world origin at 20 degrees/second.			
    			transform.RotateAround (Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.back, 20 * Time.deltaTime);
			}
		}
		else
		{
			if (randomNumber == 1 || randomNumber == 3 ||  randomNumber == 5)
    		{
				//orbit around the player at all times
				// Spin the object around the world origin at 20 degrees/second.			
    			transform.RotateAround (Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.up, 90 * Time.deltaTime);
			}
			if (randomNumber == 2 || randomNumber == 4 || randomNumber == 6 )
    		{
				//orbit around the player at all times
				// Spin the object around the world origin at 20 degrees/second.			
    			transform.RotateAround (Vector3(LookAtTarget.transform.position.x,LookAtTarget.transform.position.y,LookAtTarget.transform.position.z), Vector3.down, 90 * Time.deltaTime);
			}
			
		}		
		
		var seconds : int = Time.time;
		var oddEven = (seconds % 2);
		
		if (randomNumber == 1 ||  randomNumber == 5)
    	{
    		Shoot(seconds);
		}
	//} 
	//transform.LookAt(LookAtTarge­t); 
}
public function Shoot(seconds)
{
	if(seconds != savedTime)
	{
		var bullit = Instantiate(bullitPrefab, transform.Find("spawnPoint").transform.position, Quaternion.identity);
		bullit.gameObject.tag = "enemyProjectile";
		bullit.rigidbody.AddForce(transform.forward * 1000);
	
		savedTime = seconds;
	}
}

///currently need to add a slight more AI to this so that the enemy walks back and forward and jumps in the air.