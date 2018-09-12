using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
	public Texture2D shieldBar;
	private double shieldMax = 250.0;
	public double shield;// = 250.0;
	
	public bool repair = false;
	
	private void Start()
	{
//		shield = 250.0;
//		transform.localScale = new Vector3(0.05f,0,1);
	}
	
	private void OnTriggerExit(Collider hit)
	{
	}
	
	private void Update()
	{
		//checks whether the shield bar is at a length where it is visible
		if(repair == true)
		{
			if(shield > 0 && shield < 250)
			{
				//print(shield);
				shield += 1.75 * Time.deltaTime;
				print (1.75 * Time.deltaTime);
			}
						
			if(shield > 250)
			{
				shield = shieldMax;
				transform.localScale = new Vector3(0.05f,0,1);	//change scale of shieldbar					
			}
			
			if(transform.localScale.x >= 0.05)
			{
				transform.localScale = new Vector3(0.05f,0,1);
				shield = 250;
			}
			
			if(shield < 0)
			{
				shield = 0;
				transform.localScale =  new Vector3(0,0,1);
			}
			
			if(transform.localScale.x < 0)
			{
				transform.localScale =  new Vector3(0,0,1);
				shield = 0;
			}
		}
	}
}
