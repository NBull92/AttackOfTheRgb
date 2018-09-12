#pragma strict
//moving around
var speed = 3.0;
var x : float;
//var y : float;

//dying
static var dead = false;

function Start () 
{

}

function Update () 
{
	var controller : CharacterController = GetComponent(CharacterController);
	
	x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
	//y = Input.GetAxis("Jump") * speed * Time.deltaTime;  
	transform.Translate(x, 0, 0); 
	
}