using UnityEngine;
using System.Collections;

public class greenBossCollision : MonoBehaviour 
{
	public Transform explosion;
	public MoveAround playerScript;
	bool isCollided = false;
	public redBossHealth health;
	public bool isDead = false;		
	public roundsAndEnemyManager enemiesAlive;
		
	int hitcount = 0;
	
	// Use this for initialization
	void Start () 
	{
		//playerScript = GameObject.FindWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance		
		//health = GameObject.FindGameObjectWithTag("redEnemyHealth").GetComponent<redBossHealth>();	
		enemiesAlive = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<roundsAndEnemyManager>();
		enemiesAlive.aliveCount = 1;
		//print("alive count" + enemiesAlive.aliveCount);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	private void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "playerProjectile" && !isCollided)
		{		
			
				//do collision code
				isCollided = true;	
				if(hitcount != 4)
				{
					hitcount++;
				}
				else
				{
					//green boss dead
					Destroy(this.gameObject);
					playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
						print("enemies killed = " + playerScript.enemiesKilled);			
						print ("GREEN BOSS DEAD");
					//enemiesAlive.greenBossDEAD = true;
					enemiesAlive.aliveCount = 0;
				}			
			Destroy(hit.gameObject);	
		}
		isCollided = false;
	}			
}
