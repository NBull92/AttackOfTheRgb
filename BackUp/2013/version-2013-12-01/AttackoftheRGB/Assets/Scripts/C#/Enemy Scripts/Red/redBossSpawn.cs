using UnityEngine;
using System.Collections;

public class redBossSpawn : MonoBehaviour 
{
	public Transform boss;
	public int count = 0;
	public Transform LookAtTarget;
	public float damp = 6.0f;
	
	public Transform myTransform;	//current transform data of this enemy
	public double savedTime = 0;
	public bool isActive = false;
	public bool isComplete = false;
	
	public healthBarScript redBosshealth;
	
	public roundsAndEnemyManager roundComplete;
	
	// Use this for initialization
	void Start () 
	{
		LookAtTarget = GameObject.FindWithTag("Player").transform;	//target the player
		roundComplete = GameObject.FindGameObjectWithTag("mainFloor").GetComponent<roundsAndEnemyManager>();		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(roundComplete.redBossDEAD == false)
		{
			int seconds = (int)Time.time;
			
			if(isActive && count == 0)
			{
				Spawn(seconds);
				roundComplete.totalRounds = 5;
				//print (roundComplete.totalRounds);
			}
			if(count >0)
			{
				isActive = false;
				isComplete = true;
				roundComplete.redBossDEAD = true;
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
