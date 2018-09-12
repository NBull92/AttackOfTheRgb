using UnityEngine;
using System.Collections;

public class bosskillMeOverTime : MonoBehaviour 
{

	public float LifeTime = 2.0f;

	private void Start()
	{
	}

	private void Awake()
	{
		//Destroy(gameObject, LifeTime);
	}
	private void Update()
	{
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
