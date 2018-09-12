using UnityEngine;
using System.Collections;

public class healthBarScript : MonoBehaviour 
{
	public Texture2D healthBar;
	private double healthMax = 1000.0;
	public double health = 1000.0;
	public bool repair = false;
	
	private void Start()
	{
		health = 1000.0;
		transform.localScale = new Vector3(0.2f,0,1);
	}
	
	private void OnTriggerExit(Collider hit)
	{
	}
	
	private void Update()
	{
		//checks whether the health bar is at a length where it is visible
		if(repair == true)
		{
			if(health > 0 && health < 1000)
			{
				//print(health);
				health += 500 * Time.deltaTime;
				print (500 * Time.deltaTime);
				//transform.localScale += new Vector3(0.2f,0.0f,0.0f);
			}
			else
			{
				//print("Your Dead");
				
			}
						
			if(health > 1000)
			{
				health = healthMax;
				transform.localScale = new Vector3(0.2f,0,1);	//change scale of healthbar					
			}
			
			if(transform.localScale.x >= 0.2)
			{
				transform.localScale = new Vector3(0.2f,0,1);
				health = 1000;
			}
			
			if(health < 0)
			{
				health = 0;
				transform.localScale =  new Vector3(0,0,1);
				//you're dead
			}
			
			if(transform.localScale.x < 0)
			{
				transform.localScale =  new Vector3(0,0,1);
				health = 0;
				//you're dead;
			}
		}
	}
}
