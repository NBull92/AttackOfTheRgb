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
	//public greenBossControl shuttleControl;	
		
	public int hitcount = 0;
	
	// Use this for initialization
	void Start () 
	{
		playerScript = GameObject.FindWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance		
		health = GameObject.FindGameObjectWithTag("greenEnemyHealth").GetComponent<GreenBossHealth>();	
		enemiesAlive = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<roundsAndEnemyManager>();
		enemiesAlive.aliveCount = 1;
		BLM = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<BonusLevelManager>();
		//shuttleControl = gameObject.GetComponent<greenBossControl>();
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
				health.transform.localScale -= new Vector3(0.005f, 0,0);
				if(health.health == 0)
				{
					health.health = 0;	
					Destroy(this.gameObject);
					playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
						print("enemies killed = " + playerScript.enemiesKilled);			
						print ("GREEN BOSS DEAD");
					enemiesAlive.greenBossDEAD = true;
					enemiesAlive.aliveCount = 0;
				}					
			}		
			Destroy(hit.gameObject);	
		}
		isCollided = false;
	}			
}
