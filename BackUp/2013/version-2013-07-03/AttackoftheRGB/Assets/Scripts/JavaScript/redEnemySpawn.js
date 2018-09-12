#pragma strict

var enemy : Transform;

//var red : Transform;
//var green : Transform;
//var blue : Transform;

var count  = 0;
var savedTime = 0;
var isActive = false;

var randomNumber;

function Start () 
{
	InvokeRepeating ("PickRandomNumber", 1.0, 1.0);
	
}

function PickRandomNumber()
{
	//yield WaitForSeconds(2);
	randomNumber = Random.Range(0,10);
}

function Update () 
{
	//print(randomNumber);
	if (randomNumber == 3)
    {
    	isActive = true;
    
	}
	if(isActive)
	{
		//print(count);
		var seconds : int = Time.time;
		var time = (seconds % 2);
		
		if(isActive)
		{
			if(time == time*200 && count < 2)
			{
				Spawn(seconds);
				
			}
		}
		isActive = false;
		
	}
	else
	{
		isActive = false;
	}
}

function Spawn(seconds)
{
	if(seconds != savedTime)
	{
		var ENEMY = Instantiate(enemy, transform.position, Quaternion.identity);
		ENEMY.gameObject.tag = "Enemy";
		count++;
		savedTime = seconds;
		
	}
}