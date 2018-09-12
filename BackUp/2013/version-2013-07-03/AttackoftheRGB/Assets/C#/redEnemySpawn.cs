using UnityEngine;
using System.Collections;

public class redEnemySpawn : MonoBehaviour 
{
	public Transform enemy;
	public int count = 0;
	public double savedTime = 0;
	public bool isActive = false;

	int randomNumber;

	private void Start()
	{
		InvokeRepeating ("PickRandomNumber", 1.0f,1.0f);
	}

	private void PickRandomNumber()
	{
		randomNumber = Random.Range(0,10);
	}

	private void Update()
	{
		//print(randomNumber);
		if (randomNumber == 3)
		{
			isActive = true;
		
		}
		if(isActive)
		{
			//print(count);
			int seconds = (int)Time.time;
			double time = (seconds % 2);
			
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

	private void Spawn(int seconds)
	{
		if(seconds != savedTime)
		{
			Transform ENEMY = (Transform)Instantiate(enemy, transform.position, Quaternion.identity);
			ENEMY.gameObject.tag = "Enemy";
			count++;
			savedTime = seconds;		
		}
	}
}