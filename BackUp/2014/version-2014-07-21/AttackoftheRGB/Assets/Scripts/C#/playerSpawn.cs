using UnityEngine;
using System.Collections;

public class playerSpawn : MonoBehaviour 
{
	Transform player;

	private void Start () 
	{
		player = (Transform)Instantiate(player, transform.position, Quaternion.identity);
		player.gameObject.tag = "Player";
	}

	private void Update () 
	{
		//print("Score:	" + score);
	}
}