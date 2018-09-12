#pragma strict

var bullitPrefab : Transform;
var savedTime = 0;
var seconds : int;
function Start () 
{

}

function Update () 
{
	seconds = Time.time;
	var oddEven = (seconds % 2);
}

