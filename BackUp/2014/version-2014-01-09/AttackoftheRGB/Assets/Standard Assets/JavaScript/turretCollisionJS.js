#pragma strict

var explosion : Transform;

var playerScript : MoveAroundJS;
function Start () 
{

}

function Update () 
{
}

function OnTriggerEnter(hit : Collider)
{
	if(hit.gameObject.tag == "playerProjectile")
	{
		playerScript.enemiesKilled = playerScript.enemiesKilled + 1;
		Destroy(gameObject);
	}
}