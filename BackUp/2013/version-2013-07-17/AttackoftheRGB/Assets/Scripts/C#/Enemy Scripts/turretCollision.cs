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
		enemiesAlive = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<roundsAndEnemyManager>();
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
			print ("alive count = " + enemiesAlive.aliveCount);			
			playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
			print("enemies killed = " + playerScript.enemiesKilled);
			Destroy(gameObject);
		}				
	}
}