using UnityEngine;
using System.Collections;

public class redBossCollision : MonoBehaviour 
{
	public Transform explosion;
	public MoveAround playerScript;
	bool isCollided = false;
	public redBossHealth health;
	public bool isDead = false;		
	public roundsAndEnemyManager enemiesAlive;
	public BonusLevelManager BLM;
	public Transform ally;
	public GameOver GO;
	
	public Transform redBossTransform;	//current transform data of this enemy - DELETE THIS WHEN HAS REAL MODEL
	
	
	private void Start()
	{
		playerScript = GameObject.FindWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance		
		health = GameObject.FindGameObjectWithTag("redEnemyHealth").GetComponent<redBossHealth>();	
		enemiesAlive = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
		enemiesAlive.aliveCount = 1;
		BLM = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<BonusLevelManager>();
		health.background.guiTexture.enabled = true;
		GO = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOver>();
		redBossTransform  = GameObject.FindGameObjectWithTag("RedBoss").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(BLM.redBossDEAD == true)
		{
			Destroy(this.gameObject);
		}
	}
	
	private void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "playerProjectile" && !isCollided)
		{		
				isCollided = true;				
				if(health.health > 0)
				{
					health.health -= 50;
					health.transform.localScale -= new Vector3(0,0.02f,0);
				
					if(Application.loadedLevelName == "BonusLevel")
					{
						enemiesAlive.score += 10;
					}
				
					if(health.health == 0)
					{
						if(Application.loadedLevelName == "BonusLevel")
						{
							int timerBonus = Mathf.FloorToInt(BLM.timer);
							enemiesAlive.score += (timerBonus * 10);
							enemiesAlive.congratulationsText.enabled = true;
							BLM.redBossDEAD = true;
							GO.GameEnd = true;
						}
					
						health.health = 0;	
						health.transform.localScale = new Vector3(0,0,0);
						playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
							print("enemies killed = " + playerScript.enemiesKilled);			
							print ("RED BOSS DEAD");
						health.background.guiTexture.enabled = false;
						enemiesAlive.redBossDEAD = true;
						enemiesAlive.aliveCount = 0;
						enemiesAlive.score += 15;
						playerScript.shotCapMultiplier = 2;
						playerScript.shotCap = 20;
						Transform AllyInstant = (Transform)Instantiate(ally,transform.position, Quaternion.identity);
						AllyInstant.tag = "Ally";
						AllyInstant.gameObject.GetComponent<Ally>().redBossDEAD = true;																
					}
				}	
				else
				{
					Destroy(redBossTransform.gameObject);
				}
			Destroy(hit.gameObject);
		}
		isCollided = false;
	}
}