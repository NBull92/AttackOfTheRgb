using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class roundsAndEnemyManager : MonoBehaviour 
{
	//player
	public Transform player;
	
	//Rounds and Score
	public int totalRounds;
	public int roundsCount;	
	public int score;
	
	//GUI
	public GUIText rounds;
	public GUIText totalRoundsText;
	public GUIText centreRounds;
	public GUIText centreTotalRoundsText;
	public GUIText scoreGUI;
	public GUIText scoreText;
	public GUIText weapon;
	public GUITexture weaponHeat;
	public GUITexture healthBackground;
	public GUITexture health;
	public GUIText gameOverText;
	public GUIText congratulationsText;
	public GUIText pausedText;
	public GUIText powerupText;
	public float centerTextVisibleCounter = 1.0f;
	
	//How many enemies currently alive
	public int aliveCount;
	
	//Enemy spawn points
	public Transform[] redSpawnPoints = new Transform[8];
	public Transform[] greenSpawnPoints = new Transform[6];
	public Transform[] blueSpawnPoints = new Transform[4];
	
	//Enemy boss spawns and dead checks
	public Transform redBossSpawn;
	public bool redBossDEAD = false;
	public Transform greenBossSpawn;
	public bool greenBossDEAD = false;
	public Transform blueBossSpawn;
	public bool blueBossDEAD = false;
	
	//Round checks
	public bool roundComplete = false;
	public bool finalLevel = false;
	
	//Bonus Level
	public ReadSceneNames sceneNames;
	public BonusLevelManager BLM;
	public GUIText bonusRoundText;
	
	//Sound effects
	public AudioClip roundCompletionSound;
	
	public GameOver GO;
	
	
	// Use this for initialization
	void Start () 
	{
		//DO NOT DESTROY ON LOAD TO BONUS
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(player.gameObject);
		DontDestroyOnLoad(rounds.gameObject);
		DontDestroyOnLoad(totalRoundsText.gameObject);
		DontDestroyOnLoad(scoreGUI.gameObject);
		DontDestroyOnLoad(scoreText.gameObject);
		DontDestroyOnLoad(weapon.gameObject);
		DontDestroyOnLoad(weaponHeat.gameObject);
		DontDestroyOnLoad(healthBackground.gameObject);
		DontDestroyOnLoad(health.gameObject);
		DontDestroyOnLoad(centreRounds.gameObject);
		DontDestroyOnLoad(centreTotalRoundsText.gameObject);
		DontDestroyOnLoad(bonusRoundText.gameObject);
		DontDestroyOnLoad(gameOverText.gameObject);
		DontDestroyOnLoad(congratulationsText.gameObject);
		DontDestroyOnLoad(pausedText.gameObject);	
		DontDestroyOnLoad(powerupText.gameObject);					
				
		totalRounds = 1;
		roundsCount = 1;
		finalLevel = false;	
		sceneNames = GameObject.FindGameObjectWithTag("Manager").GetComponent<ReadSceneNames>();
		GO = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOver>();
		centreRounds.enabled = false;
		centreTotalRoundsText.enabled = false;
		bonusRoundText.enabled = false;
		gameOverText.enabled = false;
		congratulationsText.enabled = false;
		pausedText.enabled = false;
		powerupText.enabled = false;
		
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
		
	public void managerRestart()
	{
		Destroy(this.gameObject);
		Destroy(player.gameObject);
		Destroy(rounds.gameObject);
		Destroy(totalRoundsText.gameObject);
		Destroy(scoreGUI.gameObject);
		Destroy(scoreText.gameObject);
		Destroy(weapon.gameObject);
		Destroy(weaponHeat.gameObject);
		Destroy(healthBackground.gameObject);
		Destroy(health.gameObject);
		Destroy(centreRounds.gameObject);
		Destroy(centreTotalRoundsText.gameObject);
		Destroy(bonusRoundText.gameObject);
		Destroy(gameOverText.gameObject);
		Destroy(congratulationsText.gameObject);
		Destroy(pausedText.gameObject);	
		Destroy(powerupText.gameObject);	
				
		totalRounds = 1;
		roundsCount = 1;
		finalLevel = false;	
		sceneNames = GameObject.FindGameObjectWithTag("Manager").GetComponent<ReadSceneNames>();
		centreRounds.enabled = false;
		centreTotalRoundsText.enabled = false;
		bonusRoundText.enabled = false;
		gameOverText.enabled = false;
		congratulationsText.enabled = false;
		pausedText.enabled = false;
		powerupText.enabled = false;
	}
	
	void Update () 
	{			
		scoreText.text = score.ToString();
		
		if(centerTextVisibleCounter > 0.0f && centreRounds.enabled == true || centerTextVisibleCounter > 0.0f && bonusRoundText.enabled == true || centerTextVisibleCounter > 0.0f && powerupText.enabled == true )
		{
			centerTextVisibleCounter -= Time.deltaTime;
		}
		
		if(centerTextVisibleCounter < 0.0f)
		{
			bonusRoundText.enabled = false;
			gameOverText.enabled = false;
			centreRounds.enabled = false;
			centreTotalRoundsText.enabled = false;
			powerupText.enabled = false;
			centerTextVisibleCounter = 1.0f;
		}
		if(finalLevel == false)
		{		
			//check all spawns are in active				
			for(int i = 0; i < 8; i++)
			{
				if(redSpawnPoints[0] != null)
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
				if(i < 6)
				{
					if(greenSpawnPoints[0] != null)
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
				if(i < 4)
				{
					if(blueSpawnPoints[0] != null)
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
			}
			
			#region 
			if(aliveCount == 0)
			{			
				if(roundComplete == true)
				{
					//print (redBossDEAD + "readBossDEAD");
					roundComplete = false;			
					print ("ROUND COMPLETE!!!!!!!!!!!");
					
					// Play round complete sound audio clip at volume 0.7						
					audio.PlayOneShot(roundCompletionSound, 0.7f);
					
					if(roundsCount < 5)
					{	
						roundsCount +=1;
						print ("rounds count = " + roundsCount);
						reset ();
						totalRounds +=1;
						totalRoundsText.text = totalRounds.ToString(); 
						centreRounds.enabled = true;
						centreTotalRoundsText.enabled = true;
						centreTotalRoundsText.text = totalRounds.ToString(); 
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
#endregion
		}
		
		
		if(finalLevel == true)
		{	
			// Load the level named "BonusLevel".
			Application.LoadLevel ("BonusLevel");
			BLM = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<BonusLevelManager>();
			redBossDEAD = false;
			greenBossDEAD = false; 
			blueBossDEAD = false;
			bonusRoundText.enabled = true;	
		}
	}
}