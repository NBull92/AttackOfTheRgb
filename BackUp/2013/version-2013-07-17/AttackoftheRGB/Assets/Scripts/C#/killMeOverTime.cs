using UnityEngine;
using System.Collections;

public class killMeOverTime : MonoBehaviour 
{
	float LifeTime = 1.0f;

	private void Start()
	{
	}

	private void Awake()
	{
		Destroy(gameObject, LifeTime);
	}
}