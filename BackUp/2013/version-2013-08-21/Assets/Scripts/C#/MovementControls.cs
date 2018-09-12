using UnityEngine;
using System.Collections;

public class MovementControls : MonoBehaviour
{
	//moving around
	float speed = 3.0f;
	float x = 0.0f;

	//dying
	static bool dead = false;

	private void Start()
	{
	}

	private void Update()
	{
		CharacterController controller = new CharacterController();
		
		x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		//y = Input.GetAxis("Jump") * speed * Time.deltaTime;  
		transform.Translate(x, 0, 0); 
	}
}
