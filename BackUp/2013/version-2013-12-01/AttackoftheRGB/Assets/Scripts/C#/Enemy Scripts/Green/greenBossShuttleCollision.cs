using UnityEngine;
using System.Collections;

public class greenBossShuttleCollision : MonoBehaviour 
{
	public bool isDestroyed = false;
	bool isCollided = false;	
	public int hitcount = 0;
	public GreenBossHealth health;
	public greenBossCollision head;
	public MoveAround playerScript;
	public roundsAndEnemyManager enemiesAlive;
	public greenBossControl shuttleControl;
		
	// Use this for initialization
	void Start () 
	{
		head = GameObject.FindGameObjectWithTag("EnemyBoss").GetComponent<greenBossCollision>();
		playerScript = GameObject.FindWithTag("Player").GetComponent<MoveAround>();
		enemiesAlive = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<roundsAndEnemyManager>();
		health = GameObject.FindGameObjectWithTag("greenEnemyHealth").GetComponent<GreenBossHealth>();	
		shuttleControl = GameObject.FindGameObjectWithTag("EnemyBoss").GetComponent<greenBossControl>();		
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(head == null)
//		{
//			head = GameObject.FindGameObjectWithTag("EnemyBoss").GetComponent<greenBossCollision>();
//		}
//		if(shuttleControl == null)
//		{
//			shuttleControl = GameObject.FindGameObjectWithTag("EnemyBoss").GetComponent<greenBossControl>();
//		}
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
						head.isDead = true;
					}								
				}
			
			Destroy(hit.gameObject);	
		}
		isCollided = false;
	}			
}
