using UnityEngine;
using System.Collections;

public class BonusLevelManager : MonoBehaviour 
{
	
	public Transform redBossSpawn;
	public bool redBossDEAD = false;
	public Transform greenBossSpawn;
	public bool greenBossDEAD = false;
	public Transform blueBossSpawn;
	public bool blueBossDEAD = false;
	
	public bool roundComplete = false;
	public GameOver GameOver;
	public roundsAndEnemyManager manager;
	
	public float timer;
	// Use this for initialization
	void Start () 
	{	
		redBossSpawn.GetComponent<redBossSpawn>().isActive = true;
		greenBossSpawn.GetComponent<greenBossSpawn>().isActive = true;
		blueBossSpawn.GetComponent<blueBossSpawn>().isActive = true;
		GameOver = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOver>();
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
		manager.finalLevel = false;
		manager.redBossDEAD = false;
		manager.greenBossDEAD = false;
		manager.blueBossDEAD = false;	
		timer = 120.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if(redBossDEAD == true || greenBossDEAD == true || blueBossDEAD == true)
		{
			//Application.LoadLevel ("MainLevel");	
			redBossDEAD = true;
			greenBossDEAD = true;
			blueBossDEAD = true;
			GameOver.GameEnd = true;
		}
	
	}
}
