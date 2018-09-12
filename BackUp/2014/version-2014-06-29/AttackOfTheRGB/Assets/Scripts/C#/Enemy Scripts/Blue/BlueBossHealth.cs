using UnityEngine;
using System.Collections;

public class BlueBossHealth : MonoBehaviour 
{
	public Texture2D healthBar;
	public GUITexture background;
	private double healthMax = 1000.0;
	public double health = 1000.0;
	
	public bool repair = false;
	
	public blueBossControl BBC;
	
	private void Start()
	{
		health = 1000.0;
		transform.localScale = new Vector3(0.2f,0.02f,1);
		BBC =  GameObject.FindGameObjectWithTag("BlueBoss").GetComponent<blueBossControl>();
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
				transform.localScale = new Vector3(0.2f,0.02f,1);	//change scale of healthbar					
			}
			
			if(transform.localScale.x >= 0.2)
			{
				transform.localScale = new Vector3(0.2f,0.02f,1);
				health = 1000;
			}
			
			if(health < 0)
			{
				health = 0;
				transform.localScale =  new Vector3(0,0,1);
				//blue boss is dead
				Destroy(BBC.myTransform);
			}
			
			if(transform.localScale.x < 0)
			{
				transform.localScale =  new Vector3(0,0,1);
				health = 0;
				//blue boss is dead
				Destroy(BBC.myTransform);
			}
		}
	}
}
