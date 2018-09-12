using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour 
{
	public bool isActive  = false; 		//	is spawn active
	public AsteroidSpawn AST1;
	public AsteroidSpawn AST2;
	public AsteroidSpawn AST3;
	public AsteroidSpawn AST4;
	public AsteroidSpawn AST5;
	public AsteroidSpawn AST6;
	public AsteroidSpawn AST7;
	public roundsAndEnemyManager manager;
		
	int asteroidSpawns; //This count decides how many asteroids will spawn range of 1 - 7
	
	void Awake () 
	{
		PickRandomNumber();
	}
	
	private void PickRandomNumber()
	{
		//yield WaitForSeconds(2);
		asteroidSpawns = Random.Range(0,5);
		isActive  = true;
	}
	
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isActive && (manager.roundsCount == 4 || manager.roundsCount == 5))
		{
			switch (asteroidSpawns)
			{
			    case 1:
					//Launch 2 asteroids
					AST1.isActive = true;
					AST2.isActive = true;
					isActive  = false;
				break;
			    case 2:
					//Launch 3 asteroids
					AST1.isActive = true;
					AST2.isActive = true;
					AST3.isActive = true;
					isActive  = false;				
				break;
			    case 3:
					//Launch 4 asteroids
					AST1.isActive = true;
					AST2.isActive = true;
					AST3.isActive = true;
					AST4.isActive = true;
					isActive  = false;				
				break;
			    case 4:
					//Launch 5 asteroids
					AST1.isActive = true;
					AST2.isActive = true;
					AST3.isActive = true;
					AST4.isActive = true;
					AST5.isActive = true;
					isActive  = false;				
				break;
			    case 5:
					//Launch 6 asteroids
					AST1.isActive = true;
					AST2.isActive = true;
					AST3.isActive = true;
					AST4.isActive = true;
					AST5.isActive = true;
					AST6.isActive = true;	
					isActive  = false;			
				break;
				default:
					//Launch 7 asteroids
					AST1.isActive = true;
					AST2.isActive = true;
					AST3.isActive = true;
					AST4.isActive = true;
					AST5.isActive = true;
					AST6.isActive = true;
					AST7.isActive = true;	
					isActive  = false;			
				break;
			}		
		}
	}
}
