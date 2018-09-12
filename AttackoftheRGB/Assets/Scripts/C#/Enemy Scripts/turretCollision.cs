using UnityEngine;
using System.Collections;

public class turretCollision : MonoBehaviour 
{
	public Transform explosion;

	public MoveAround playerScript;
	public bool isCollided = false;
	
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
			
			if(gameObject.name == "RedBasic(Clone)" || gameObject.name == "RedBasic" )
			{
				enemiesAlive.score += 10;
				//print("red");
			}
			
			else if(gameObject.name == "GreenBasic(Model)(Clone)"|| gameObject.name == "GreenBasic(Model)" )
			{
				enemiesAlive.score += 15;
				//print("green");
			}
			
			else if(gameObject.name == "BlueBasic(Model)(Clone)"|| gameObject.name == "BlueBasic(Model)" )
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
			enemiesAlive.aliveCount -=1;
		}
	}
}