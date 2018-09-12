using UnityEngine;
using System.Collections;

public class bosskillMeOverTime : MonoBehaviour 
{
	public Transform LookAtTarget;
	public float LifeTime = 2.0f;
	public float damp = 6.0f;
	
	private void Start()
	{
		LookAtTarget = GameObject.FindWithTag("Player").transform;	//target the player
	}

	private void Awake()
	{
		//Destroy(gameObject, LifeTime);
	}
	private void Update()
	{
		//change rotation of enemy
			var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position); 
			transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp); 
			
		//print ("lifetime: " + LifeTime);
		if(LifeTime < 1)
		{
			Destroy (this.gameObject);
		}
		else
		{
			LifeTime -= Time.deltaTime;
			
		}
		
	}
	
}
