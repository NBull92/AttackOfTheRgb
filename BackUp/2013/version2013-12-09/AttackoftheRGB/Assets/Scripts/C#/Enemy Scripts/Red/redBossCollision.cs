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
			
	private void Start()
	{
		playerScript = GameObject.FindWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance		
		health = GameObject.FindGameObjectWithTag("redEnemyHealth").GetComponent<redBossHealth>();	
		enemiesAlive = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<roundsAndEnemyManager>();
		enemiesAlive.aliveCount = 1;
		BLM = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<BonusLevelManager>();
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
					health.transform.localScale -= new Vector3(0.01f, 0,0);
					if(health.health == 0)
					{
						health.health = 0;	
						Destroy(this.gameObject);
						playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
							print("enemies killed = " + playerScript.enemiesKilled);			
							print ("RED BOSS DEAD");
						enemiesAlive.redBossDEAD = true;
						enemiesAlive.aliveCount = 0;
						BLM.redBossDEAD = true;
					}
				}				
			Destroy(hit.gameObject);
		}
		isCollided = false;
	}
}
