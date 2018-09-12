#pragma strict

var lifeTime = 1.0;

function Start () 
{

}

function Awake () 
{
	Destroy (gameObject, lifeTime);
}