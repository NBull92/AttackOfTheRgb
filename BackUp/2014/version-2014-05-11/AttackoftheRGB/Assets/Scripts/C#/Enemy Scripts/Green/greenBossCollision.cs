using UnityEngine;
using System.Collections;

public class greenBossCollision : MonoBehaviour 
{
	public Transform explosion;
	public MoveAround playerScript;
	bool isCollided = false;
	public GreenBossHealth health;
	public bool isDead = false;		
	public roundsAndEnemyManager enemiesAlive;
	public BonusLevelManager BLM;	
	public Transform ally;
	public GameOver GO;
	//public greenBossControl shuttleControl;	
		
	public int hitcount = 0;
	
	public Transform greenBossTransform;	//current transform data of this enemy - DELETE THIS WHEN HAS REAL MODEL
	
	// Use this for initialization
	void Start () 
	{
		playerScript = GameObject.FindWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance		
		health = GameObject.FindGameObjectWithTag("greenEnemyHealth").GetComponent<GreenBossHealth>();	
		enemiesAlive = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
		enemiesAlive.aliveCount = 1;
		BLM = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<BonusLevelManager>();
		health.background.guiTexture.enabled = true;
		GO = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOver>();
		//shuttleControl = gameObject.GetComponent<greenBossControl>();
		greenBossTransform  = GameObject.FindGameObjectWithTag("GreenBoss").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(BLM.greenBossDEAD == true)
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
				health.health -= 25;
				health.transform.localScale -= new Vector3(0,0.01f,0);
				
				if(Application.loadedLevelName == "BonusLevel")
				{
					enemiesAlive.score += 15;
				}
				
				if(health.health == 0)
				{
					health.health = 0;	
					health.transform.localScale = new Vector3(0,0,0);
					Destroy(this.gameObject);
					playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
						print("enemies killed = " + playerScript.enemiesKilled);			
						print ("GREEN BOSS DEAD");
					health.background.guiTexture.enabled = false;
					enemiesAlive.greenBossDEAD = true;
					enemiesAlive.aliveCount = 0;
					enemiesAlive.score += 20;
					playerScript.shotCapMultiplier = 4;
					playerScript.shotCap = 40;				
					Transform AllyInstant = (Transform)Instantiate(ally,transform.position, Quaternion.identity);
					AllyInstant.tag = "Ally";
					AllyInstant.gameObject.GetComponent<Ally>().greenBossDEAD = true;
					BLM.greenBossDEAD = true;
					
					if(Application.loadedLevelName == "BonusLevel")
					{
						int timerBonus = Mathf.FloorToInt(BLM.timer);;
						enemiesAlive.score += (timerBonus * 20);
						enemiesAlive.congratulationsText.enabled = true;
						GO.GameEnd = true;
					}
				
				}					
			}	
			else
			{
				Destroy(greenBossTransform.gameObject);
			}		
			Destroy(hit.gameObject);	
		}
		isCollided = false;
	}			
}
