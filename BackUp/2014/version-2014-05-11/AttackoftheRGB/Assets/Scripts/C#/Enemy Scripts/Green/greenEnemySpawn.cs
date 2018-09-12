using UnityEngine;
using System.Collections;

public class greenEnemySpawn : MonoBehaviour 
{
	public Transform enemy;
	public int count = 0;
	public double savedTime = 0;
	public bool isActive = false;
	public bool isComplete = false;

	int randomNumber;
	
	public roundsAndEnemyManager roundsCount;

	private void Start()
	{
		InvokeRepeating ("PickRandomNumber", 1.0f,1.0f);
		roundsCount = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
	}

	private void PickRandomNumber()
	{
		randomNumber = Random.Range(0,10);
	}

	private void Update()
	{
		if(roundsCount.totalRounds > 5)
		{
		
			if(count == (roundsCount.roundsCount + 1))
			{
				isComplete = true;		
				
			}
			if(!isComplete)
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
						if(time == time*200 && count < (roundsCount.roundsCount + 1))
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