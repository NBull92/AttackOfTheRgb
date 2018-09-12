using UnityEngine;
using System.Collections;

public class greenBossSpawn : MonoBehaviour 
{
	public Transform boss;
	public int count = 0;
	public Transform LookAtTarget;
	public float damp = 6.0f;
	
	public Transform myTransform;	//current transform data of this enemy
	public double savedTime = 0;
	public bool isActive = false;
	public bool isComplete = false;
	
	public roundsAndEnemyManager roundComplete;
	
	// Use this for initialization
	void Start () 
	{
		LookAtTarget = GameObject.FindWithTag("Player").transform;	//target the player
		roundComplete = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(roundComplete.greenBossDEAD == false)
		{
			int seconds = (int)Time.time;
			
			if(isActive && count == 0)
			{
				Spawn(seconds);
				roundComplete.totalRounds = 10;
			}
			if(count >0)
			{
				isActive = false;
				isComplete = true;
				roundComplete.greenBossDEAD = true;
				//roundComplete.roundComplete = true;
			}
		}
	}
	
	private void Spawn(int seconds)
	{		
		if(seconds != savedTime)
		{			
			Transform BOSS = (Transform)Instantiate(boss, transform.position, Quaternion.identity);
			BOSS.gameObject.tag = "EnemyBoss";
			count++;
			savedTime = seconds;
			isActive = false;
		}
	}
}
