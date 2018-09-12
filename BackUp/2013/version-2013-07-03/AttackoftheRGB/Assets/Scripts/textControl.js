#pragma strict
var isQuitButton = false;
var isTitle = false;
var r = false;
var g = false;
var b = false;
var exit = false;


function Start () 
{

}

function Update () 
{
	if(isTitle)
	{
		renderer.material.color = Color.yellow;
	}
	if(r)
	{
		renderer.material.color = Color.red;
	}
	if(g)
	{
		renderer.material.color = Color.green;
	}
	if(b)
	{
		renderer.material.color = Color.blue;
	}
	
}

function OnMouseEnter()
{
	renderer.material.color = Color.cyan;
}

function OnMouseExit()
{
	renderer.material.color = Color.white;
}

function OnMouseUp()
{
	if(isQuitButton)
	{
		Application.Quit();
	}
	if(isTitle || r || g || b)
	{
		//do nothing :P
	}
	if(exit)
	{
		Application.LoadLevel(0);
	}
	else
	{
		//load level
		Application.LoadLevel(1);
	}
}