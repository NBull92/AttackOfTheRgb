#pragma strict

var player : Transform;

function Start () 
{
	player = Instantiate(player, transform.position, Quaternion.identity);
	player.gameObject.tag = "Player";
}

function Update () 
{
	//print("Score:	" + score);
}