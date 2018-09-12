using UnityEngine;
using System.Collections;

public class turretCollision : MonoBehaviour 
{
	public Transform explosion;

	public MoveAround playerScript;
	bool isCollided = false;
	
	public roundsAndEnemyManager enemiesAlive;
	
	private void Awake()
	{
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance
		enemiesAlive = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
	}
	
	private void Start()
	{
	}
	
	private void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "playerProjectile" && !isCollided)
		{			
			isCollided = true;
			enemiesAlive.aliveCount = enemiesAlive.aliveCount -=1;	
			playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
			
			if(gameObject.name == "redEnemy(Basic)(Clone)" || gameObject.name == "redEnemy(Basic)" )
			{
				enemiesAlive.score += 10;
				//print("red");
			}
			
			else if(gameObject.name == "greenEnemy(basic)(Clone)"|| gameObject.name == "greenEnemy(basic)" )
			{
				enemiesAlive.score += 15;
				//print("green");
			}
			
			else if(gameObject.name == "blueEnemy(basic)(Clone)"|| gameObject.name == "blueEnemy(basic)" )
			{
				enemiesAlive.score += 20;
				//print("blue");
			}
						
			Destroy(gameObject);
		}	
		if(hit.gameObject.tag == "Asteroid")
		{
			Destroy(gameObject);						
			Destroy(hit.gameObject);
		}
	}
}