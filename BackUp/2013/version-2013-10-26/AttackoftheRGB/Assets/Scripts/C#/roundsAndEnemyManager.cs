using UnityEngine;
using System.Collections;

public class roundsAndEnemyManager : MonoBehaviour 
{
	public int totalRounds;
	public int roundsCount;	
	
	public int aliveCount;
	
	public Transform[] redSpawnPoints = new Transform[8];
	public Transform[] greenSpawnPoints = new Transform[6];
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
		for(int i = 0; i < 8; i++)
		{
			redSpawnPoints[i].GetComponent<redEnemySpawn>().count = 0;
			redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete = false;	
			if(totalRounds >6 && i < 6)
			{
			
				greenSpawnPoints[i].GetComponent<greenEnemySpawn>().count = 0;
				greenSpawnPoints[i].GetComponent<greenEnemySpawn>().isComplete = false;			
			
			}
		}
		//if(totalRounds >6)
		//{
//			for(int j = 0; j < greenSpawnPoints.Length; j++)
//			{
//				greenSpawnPoints[j].GetComponent<greenEnemySpawn>().count = 0;
//				greenSpawnPoints[j].GetComponent<greenEnemySpawn>().isComplete = false;			
//			}
		//}
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
			if(i < 6)
			{
				if(greenSpawnPoints[i].GetComponent<greenEnemySpawn>().isComplete == true)			
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
		}
		
		if(aliveCount == 0)
		{			
			if(roundComplete == true)
			{
				print (redBossDEAD + "readBossDEAD");
				roundComplete = false;			
				//print ("ROUND COMPLETE!!!!!!!!!!!");				
				
				if(roundsCount < 5)
				{	
					roundsCount +=1;
					print ("rounds count = " + roundsCount);
					reset ();
					
				}
				else if(roundsCount == 5 && redBossDEAD == false)
				{
						//check to see if red boss level is complete
						//if(redBossDEAD == false)// && redBossDEAD != true)
						//{
							//if not make the spawn active
							redBossSpawn.GetComponent<redBossSpawn>().isActive = true;
							//redBossDEAD = true;
							for(int i = 0; i < 8; i++)
							{
								redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete = true;
							}
						//}				
						
				}				
				else
				{			
					roundsCount = 1;
					//print ("rounds count = " + roundsCount);
					reset ();
				}
				totalRounds +=1;
				print ("total rounds = " + totalRounds);			
			}
		}
		
	}		
}

