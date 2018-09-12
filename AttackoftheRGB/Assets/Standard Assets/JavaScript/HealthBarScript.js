#pragma strict

var healthBar : Texture2D; //healthBar GUI
private var healthmax = 1000f; //the reason why the number is this big - is due to how long it take to get from the 1st shelter toe the ship
public var health = 100f;

var repair = true;

function Start () 
{
	health = 100f;
	transform.localScale.x = 0.1f;
}

function OnTriggerEnter(hit : Collider)
{
	if(hit.gameObject.tag == "ally")
	{
		//print("You have entered a shelter. health will cease to depleat now"); //check if player has collided with a shelter - health will not depleat.
		//healthBar.
		//health + 500;		
	}	
}
function Update () 
{
	
	//checks whether the health bar is at a length where it is visible
	if(repair == true)
	{
		if(health > 0)
		{
			//print(health);
			health += 1.75 * Time.deltaTime;
			//print("bar length " + transform.localScale.x); //check players health.
			transform.localScale += new Vector3(health / 60000000f,0,transform.localScale.z);	//change scale of healthbar
			//t//ransform.position.x -= 0.00075;
		}
		else
		{
			//print("Your Dead");
			
		}
		
		
		if(health > 1000)
		{
			health = healthmax;
			transform.localScale.x = 0.18;	//change scale of healthbar		
			
		}
		if(transform.localScale.x >= 0.18)
		{
			transform.localScale.x = 0.18;
			health = 1000;
		}
		if(health < 0)
		{
			health = 0;
			transform.localScale.x = 0;
			//your dead
		}
		if(transform.localScale.x < 0)
		{
			transform.localScale.x = 0;
			health = 0;
			//yourdead;
		}
	}
	
	

}
