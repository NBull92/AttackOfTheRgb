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
	public BonusLevelManager BLM;
		
	public int hitcount = 0;
	
	// Use this for initialization
	void Start () 
	{
		playerScript = GameObject.FindWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance		
		health = GameObject.FindGameObjectWithTag("blueEnemyHealth").GetComponent<BlueBossHealth>();	
		enemiesAlive = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<roundsAndEnemyManager>();
		BLM = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<BonusLevelManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(BLM.blueBossDEAD == true)
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
				health.health -= 12.5;
				health.transform.localScale -= new Vector3(0.0025f, 0,0);
				if(health.health == 0)
				{
					health.health = 0;	
					Destroy(this.gameObject);
					playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
						print("enemies killed = " + playerScript.enemiesKilled);			
						print ("BLUE BOSS DEAD");
					enemiesAlive.blueBossDEAD = true;
					enemiesAlive.aliveCount = 0;
					enemiesAlive.roundComplete = true;
					enemiesAlive.finalLevel = true;
					//print ("final level");
				}					
			}		
			Destroy(hit.gameObject);	
		}
		isCollided = false;
	}			
}
