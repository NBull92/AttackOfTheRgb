#pragma strict
var health1 : Texture2D;	//one life left
var health2 : Texture2D;	//two lives left
var health3 : Texture2D;	//full health
var KO : Texture2D; 		//ko texture

//var bodyPart1 : Transform;
//var bodyPart2 : Transform;

static var LIVES = 3;
static var HITS = 0;

function Start () 
{

}

function Update () 
{

	//print("Lives: "+LIVES+" Hits: "+HITS); //Lives: 3 Hits: 0
	
	switch(LIVES)
	{
		case 3:
			guiTexture.texture = health3;
		break;
		
		case 2:
			guiTexture.texture = health2;
		break;
		
		case 1:
			guiTexture.texture = health1;
		break;
		
		case 0:
			transform.position = Vector2(0.5,0.5);	
			transform.localScale = Vector3(0.2,0.2,0);		
			guiTexture.texture = KO;
		break;			
	}
	
	switch(HITS)
	{
		//case 1: 
		//disable bodyPart2
		//	bodyPart2.renderer.enabled = false;
		//break;
		//case 2: 
		//disable bodyPart1
		//	bodyPart1.renderer.enabled = false;
		//	bodyPart2.renderer.enabled = false;	//here just incase of error
		//break;
		case 1: 
			LIVES -=1;
			HITS = 0;
			MoveAroundJS.dead = true;
			//bodyPart1.renderer.enabled = true;
			//bodyPart2.renderer.enabled = true;	//here just incase of error
		break;
	}
}