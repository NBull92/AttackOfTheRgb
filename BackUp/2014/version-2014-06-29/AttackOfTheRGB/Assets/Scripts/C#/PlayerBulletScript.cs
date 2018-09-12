using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour 
{
	public Transform explosion;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "Enemy")
		{			
			//print ("destroyed player projectile");
			Destroy(this.gameObject);
		}
	}
}