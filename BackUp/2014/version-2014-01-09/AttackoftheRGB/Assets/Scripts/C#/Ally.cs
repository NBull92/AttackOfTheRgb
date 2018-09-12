using UnityEngine;
using System.Collections;

public class Ally : MonoBehaviour 
{
	public string[] powerUps = new string[] {"Shield","No Weapon Cap","Weapon Spray","Extra Health","Invincible"};
	public string powerUp;
	
	int randomNumber;
	public Transform myTransform;	//current transform data of this enemy
	public int moveSpeed = 5;
	
	public bool backwards = false;
	public bool forward = false;
	public bool left = false;
	public bool right = false;	
	public bool startPosFound = false;
	
	public int boundsHit = 0;
	
	private void Awake()
	{
		myTransform = transform;	//cache transform data for easy access/performance
	}

	// Use this for initialization
	void Start () 
	{
		randomNumber = Random.Range(0,5);
		powerUp = powerUps[randomNumber];
	}
	
	private void OnTriggerEnter(Collider hit)
	{
		//if collided with level bound left
		if(hit.gameObject.tag == "floor-left" && startPosFound == false)
		{
			right = true;	//move right
			startPosFound = true;	//start trigger found
		}
		
		//if collided with level bound right
		if(hit.gameObject.tag == "floor-right" && startPosFound == false)
		{
			left = true;	//move left
			startPosFound = true;	//start trigger found
		}
		
		//if collided with level bound top
		if(hit.gameObject.tag == "floor-top" && startPosFound == false)
		{
			backwards = true;	//move backwards
			startPosFound = true;	//start trigger found
		}
		
		//if collided with level bound bottom
		if(hit.gameObject.tag == "floor-bottom" && startPosFound == false)
		{
			forward = true;	//move forward
			startPosFound = true;	//start trigger found
		}
		
		//if collided with level bound left increase bounds hit
		if(hit.gameObject.tag == "levelBounds-Left")
		{
			boundsHit++;
		}
		
		//if collided with level bound right increase bounds hit
		if(hit.gameObject.tag == "levelBounds-Right")
		{
			boundsHit++;
		}
		
		//if collided with level bound top increase bounds hit
		if(hit.gameObject.tag == "levelBounds-Top")
		{
			boundsHit++;
		}
		
		//if collided with level bound bottom increase bounds hit
		if(hit.gameObject.tag == "levelBounds-Bottom")
		{
			boundsHit++;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if(left == true)
		{
			myTransform.position -= myTransform.right * moveSpeed * Time.deltaTime;
		}
		if(right == true)
		{
			myTransform.position += myTransform.right * moveSpeed * Time.deltaTime;
		}
		if(backwards == true)
		{
			myTransform.position -= myTransform.forward * moveSpeed * Time.deltaTime;
		}
		if(forward == true)
		{
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		
		//if hit bounds twice, meaning the ally is no longer in play - then delete it
		if(boundsHit >= 2)
		{
			Destroy(transform.gameObject);
		}
	}
}
