using UnityEngine;
using System.Collections;

public class redBossHealth : MonoBehaviour 
{
	public Texture2D healthBar;
	public GUITexture background;
	private double healthMax = 1000.0;
	public double health = 1000.0;
	
	public bool repair = false;
	
	public redBossControl RBC;
	
	private void Start()
	{
		health = 1000.0;
		transform.localScale = new Vector3(0.035f,0.4f,0);
		transform.localPosition = new Vector3(0.1f, 0.51f,0);
		//background.guiTexture.enabled = true;
		RBC =  GameObject.FindGameObjectWithTag("RedBoss").GetComponent<redBossControl>();
	}
	
	private void Update()
	{
		//checks whether the health bar is at a length where it is visible
		if(repair == true)
		{
			if(health > 0 && health < 1000)
			{
				//print(health);
				health += 1.75 * Time.deltaTime;
				print (1.75 * Time.deltaTime);
			}
			else
			{
				//print("Your Dead");				
			}
						
			if(health > 1000)
			{
				health = healthMax;
				transform.localScale = new Vector3(0.035f,0.4f);	//change scale of healthbar					
			}
			
			if(transform.localScale.y >= 0.4)
			{
				transform.localScale = new Vector3(0.035f,0.4f);
				health = 1000;
			}
			
			if(health == 0)
			{
				health = 0;
				transform.localScale =  new Vector3(0,0,1);
				background.guiTexture.enabled = false;
				
				//red boss is dead
				Destroy(RBC.myTransform);
			}
			
			if(transform.localScale.y < 0)
			{
				transform.localScale =  new Vector3(0,0,1);
				health = 0;
				background.guiTexture.enabled = false;
				
				//red boss is dead;
				Destroy(RBC.myTransform);
			}
		}
	}
}