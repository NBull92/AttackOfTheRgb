using UnityEngine;
using System.Collections;

public class roundsAndEnemyManager : MonoBehaviour 
{
	public int totalRounds;
	public int roundsCount;
	
	
	public int aliveCount;
	
	public Transform[] redSpawnPoints = new Transform[8];
	//public Transform[] greenSpawnPoints = new Transform[6];
	//public Transform[] blueSpawnPoints = new Transform[4];
	
	public Transform redBossSpawn;
	public bool redBossDEAD = false;
	//public Transform greenBossSpawn;
	//public Transform blueBossSpawn;
	
	public bool roundComplete = false;
	// Use this for initialization
	void Start () 
	{
		totalRounds = 1;
		roundsCount = 1;
	}
	void reset()
	{
		for(int i = 0; i < redSpawnPoints.Length; i++)
		{
			redSpawnPoints[i].GetComponent<redEnemySpawn>().count = 0;
			redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete = false;
		}	
	}
	// Update is called once per frame
	void Update () 
	{
		//check all spawns are in active			
		for(int i = 0; i < 8; i++)
		{
			if(redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete == true)			
			{
				roundComplete = true;
				break;
			}
			else
			{
				roundComplete = false;
				break;
			}
		}
		if(redBossSpawn.GetComponent<redBossSpawn>().isComplete == true)
		{
			roundComplete = true;
		}
		if(aliveCount == 0)
		{
			if(roundComplete == true)
			{
				roundComplete = false;			
				print ("ROUND COMPLETE!!!!!!!!!!!");
				print ("alive count = 0");
				
				if(roundsCount < 5)
				{
					roundsCount +=1;
					print ("rounds count = " + roundsCount);
					reset ();
					
				}
				else if(roundsCount == 5)
				{
						//check to see if red boss level is complete
						if(redBossSpawn.GetComponent<redBossSpawn>().isComplete == false)// && redBossDEAD != true)
						{
							//if not make the spawn active
							redBossSpawn.GetComponent<redBossSpawn>().isActive = true;
						}				
						else
						{
							roundsCount = 1;
							reset ();
						}
				}				
				
				totalRounds +=1;
				print ("total rounds = " + totalRounds);			
			}
		}
		
	}		
}

