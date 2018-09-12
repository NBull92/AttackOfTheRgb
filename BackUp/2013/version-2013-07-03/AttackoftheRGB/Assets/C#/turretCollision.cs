using UnityEngine;
using System.Collections;

public class turretCollision : MonoBehaviour 
{
	public Transform explosion;

	public MoveAround playerScript;
	bool isCollided = false;
	
	private void Awake()
	{
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveAround>();	//cache transform data for easy access/performance
	}
	
	private void Start()
	{
	}
	private void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "playerProjectile" && !isCollided)
		{
			isCollided = true;
			playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
			Destroy(gameObject);
		}				
	}
}