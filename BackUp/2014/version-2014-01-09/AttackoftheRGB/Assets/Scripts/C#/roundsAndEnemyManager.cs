using UnityEngine;
using System.Collections;

public class roundsAndEnemyManager : MonoBehaviour 
{
	public int totalRounds;
	public int roundsCount;	
	public int score;
	
	public int aliveCount;
	
	public Transform[] redSpawnPoints = new Transform[8];
	public Transform[] greenSpawnPoints = new Transform[6];
	public Transform[] blueSpawnPoints = new Transform[4];
	
	public Transform redBossSpawn;
	public bool redBossDEAD = false;
	public Transform greenBossSpawn;
	public bool greenBossDEAD = false;
	public Transform blueBossSpawn;
	public bool blueBossDEAD = false;
	
	public bool roundComplete = false;
	public bool finalLevel = false;
	
	public ReadSceneNames sceneNames;
	public BonusLevelManager BLM;
	
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this.gameObject);
		totalRounds = 1;
		roundsCount = 1;
		finalLevel = false;	
		sceneNames = GameObject.FindGameObjectWithTag("Manager").GetComponent<ReadSceneNames>();
	}
	
	void reset()
	{
		for(int i = 0; i < 8; i++)
		{
			redSpawnPoints[i].GetComponent<redEnemySpawn>().count = 0;
			redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete = false;	
			
			if(i < 6)
			{			
				greenSpawnPoints[i].GetComponent<greenEnemySpawn>().count = 0;
				greenSpawnPoints[i].GetComponent<greenEnemySpawn>().isComplete = false;			
			}
			
			if(i < 4)
			{			
				blueSpawnPoints[i].GetComponent<blueEnemySpawn>().count = 0;
				blueSpawnPoints[i].GetComponent<blueEnemySpawn>().isComplete = false;			
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{			
		if(finalLevel == false)
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
			if(i < 4)
			{
				if(blueSpawnPoints[i].GetComponent<blueEnemySpawn>().isComplete == true)			
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
					//print (redBossDEAD + "readBossDEAD");
					roundComplete = false;			
					print ("ROUND COMPLETE!!!!!!!!!!!");				
					
					if(roundsCount < 5)
					{	
						roundsCount +=1;
						print ("rounds count = " + roundsCount);
						reset ();
						totalRounds +=1;
						print ("total rounds = " + totalRounds);
					}
					else if(roundsCount == 5)
					{
						if(redBossDEAD == false)
						{
							//if not make the spawn active
							redBossSpawn.GetComponent<redBossSpawn>().isActive = true;
							//redBossDEAD = true;
							for(int i = 0; i < 8; i++)
							{
								redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete = true;
							}
							roundsCount = 0;
						}
						if(redBossDEAD == true && greenBossDEAD == false)
						{
							//if not make the spawn active
							greenBossSpawn.GetComponent<greenBossSpawn>().isActive = true;
							//redBossDEAD = true;
							for(int i = 0; i < 8; i++)
							{
								redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete = true;
								if(i < 6)
								{
									greenSpawnPoints[i].GetComponent<greenEnemySpawn>().isComplete = true;
								}
							}	
							roundsCount = 0;
						}
						if(redBossDEAD == true && greenBossDEAD == true && blueBossDEAD == false)
						{
							//if not make the spawn active
							blueBossSpawn.GetComponent<blueBossSpawn>().isActive = true;						
							for(int i = 0; i < 8; i++)
							{
								redSpawnPoints[i].GetComponent<redEnemySpawn>().isComplete = true;
								if(i < 6)
								{
									greenSpawnPoints[i].GetComponent<greenEnemySpawn>().isComplete = true;
								}
								if(i < 4)
								{
									blueSpawnPoints[i].GetComponent<blueEnemySpawn>().isComplete = true;
								}
								roundsCount = 0;
							}	
							//roundsCount = 0;
							print(aliveCount);
						}
					}
					else
					{			
						roundsCount = 1;
						//print ("rounds count = " + roundsCount);
						reset ();
					}			
				}
			}
		}
		if(finalLevel == true)
		{
//			if(redBossDEAD == true && greenBossDEAD == true && blueBossDEAD == true)
//			{		
				// Load the level named "BonusLevel".
				Application.LoadLevel ("BonusLevel");
				BLM = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<BonusLevelManager>();
				redBossDEAD = false;
				greenBossDEAD = false; 
				blueBossDEAD = false;
			//}
		}
	}
}