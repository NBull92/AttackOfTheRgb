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
	
	// Use this for initialization
	void Start () 
	{
		LookAtTarget = GameObject.FindWithTag("Player").transform;	//target the player
	}
	
	// Update is called once per frame
	void Update () 
	{
		int seconds = (int)Time.time;
		
		//if round = 5 then isActive = true
		
		if(isActive && count == 0)
		{
			Spawn(seconds);
		}
		if(count >0)
		{
			isActive = false;
			isComplete = true;
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
