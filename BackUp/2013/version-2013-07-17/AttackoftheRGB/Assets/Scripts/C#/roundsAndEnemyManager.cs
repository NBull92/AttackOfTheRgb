using UnityEngine;
using System.Collections;

public class roundsAndEnemyManager : MonoBehaviour 
{
	public int totalRounds;
	public int roundsCount;
	
	public int aliveCount;
	
	public Transform[] redSpawnPoints = new Transform[8];
	public Transform[] greenSpawnPoints = new Transform[6];
	public Transform[] blueSpawnPoints = new Transform[4];
	
	public bool roundComplete = false;
	// Use this for initialization
	void Start () 
	{
		totalRounds = 1;
		roundsCount = 1;
		print(aliveCount);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//check all spawns are in active
		for(int i = 0; i < 8; i++)
		{
			if(redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete == true)			
			{
				//print (spawnPoints[i]="isComplete");
				roundComplete = true;
			}
			else
			{
				roundComplete = false;
			}
			if(greenSpawnPoints[i].GetComponent<greenEnemySpawn>().isComplete == true)			
			{
				//print (spawnPoints[i]="isComplete");
				roundComplete = true;
			}
			else
			{
				roundComplete = false;
			}
			if(blueSpawnPoints[i].GetComponent<blueEnemySpawn>().isComplete == true)			
			{
				//print (spawnPoints[i]="isComplete");
				roundComplete = true;
			}
			else
			{
				roundComplete = false;
			}
		}
		
		if(roundComplete)
		{
			//check aliveCount = 0
			if(aliveCount == 0)
			{	
				print ("ROUND COMPLETE!!!!!!!!!!!");
				print ("alive count = 0");
				for(int i = 0; i < redSpawnPoints.Length; i++)
				{
					Time.timeScale = 0;			
				}
				totalRounds +=1;
				print ("total rounds = " + totalRounds);
				if(roundsCount != 5)
				{
					roundsCount +=1;					
				}
				else
				{
					roundsCount = 1;
				}
				
				roundComplete = false;
			}
		}		
	}
}
