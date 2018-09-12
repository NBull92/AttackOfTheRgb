using UnityEngine;
using System.Collections;

public class blueBossCollision : MonoBehaviour 
{
	public Transform explosion;
	public MoveAround playerScript;
	bool isCollided = false;
	public BlueBossHealth health;
	public bool isDead = false;		
	public roundsAndEnemyManager enemiesAlive;
	public GameOver GO;
		
	public int hitcount = 0;
	public BonusLevelManager BLM;
	
	public Transform blueBossTransform;	//current transform data of this enemy - DELETE THIS WHEN HAS REAL MODEL
	// Use this for initialization
	void Start () 
	{
		playerScript = GameObject.FindWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance		
		health = GameObject.FindGameObjectWithTag("blueEnemyHealth").GetComponent<BlueBossHealth>();	
		enemiesAlive = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
		BLM = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<BonusLevelManager>();		
		health.background.guiTexture.enabled = true;
		GO = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOver>();
		blueBossTransform  = GameObject.FindGameObjectWithTag("BlueBoss").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(BLM != null)
		{
			if(BLM.blueBossDEAD == true)
			{
				Destroy(this.gameObject);
			}
		}
	}
	
	private void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "playerProjectile" && !isCollided)
		{		
			isCollided = true;	
			if(health.health > 0)
			{					
				health.health -= 12.5;
				health.transform.localScale -= new Vector3(0.0025f, 0,0);
				
				if(Application.loadedLevelName == "BonusLevel")
				{
					enemiesAlive.score += 20;
				}
				
				if(health.health == 0)
				{
					health.health = 0;	
					Destroy(this.gameObject);
					playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
						print("enemies killed = " + playerScript.enemiesKilled);			
						print ("BLUE BOSS DEAD");
					health.background.guiTexture.enabled = false;
					enemiesAlive.blueBossDEAD = true;
					enemiesAlive.aliveCount = 0;
					enemiesAlive.roundComplete = true;					
					enemiesAlive.score += 25;
					
					if(Application.loadedLevelName == "BonusLevel")
					{
						int timerBonus = Mathf.FloorToInt(BLM.timer);
						enemiesAlive.score += (timerBonus * 25);
						enemiesAlive.congratulationsText.enabled = true;
						GO.GameEnd = true;
					BLM.blueBossDEAD = true;
						print ("AHHHH");
//						Destroy(GameObject.FindGameObjectWithTag("EnemyBoss"));
//						Destroy(GameObject.FindGameObjectWithTag("EnemyBoss"));
					}
					else
					{
						enemiesAlive.finalLevel = true;
					}
				
					//print ("final level");
				}					
			}					
			else
			{
				Destroy(blueBossTransform.gameObject);
			}	
			Destroy(hit.gameObject);	
		}
		isCollided = false;
	}			
}
