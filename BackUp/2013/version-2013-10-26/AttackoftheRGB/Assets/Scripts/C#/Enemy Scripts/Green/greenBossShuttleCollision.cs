using UnityEngine;
using System.Collections;

public class greenBossShuttleCollision : MonoBehaviour 
{
	public bool isDestroyed = false;
	bool isCollided = false;	
	public int hitcount = 0;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	private void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "playerProjectile" && !isCollided)
		{					
			isCollided = true;	
			if(hitcount != 2)
			{
				hitcount++;
			}
			else
			{
				//green boss dead
				Destroy(this.gameObject);	
				isDestroyed = true;
			}			
			Destroy(hit.gameObject);	
		}
		isCollided = false;
	}			
}
