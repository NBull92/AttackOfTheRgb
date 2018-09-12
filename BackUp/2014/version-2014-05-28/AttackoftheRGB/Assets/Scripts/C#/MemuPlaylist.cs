using UnityEngine;
using System.Collections;

public class MemuPlaylist : MonoBehaviour 
{	
	//menu playlist audio
	public AudioClip Impasse;
	public AudioClip TheSkyFell;
	public AudioClip TheCalm;
	public AudioClip Arisen;
	public AudioClip Overflow;
	
	int randomNumber;
	int currentSong;
	
	roundsAndEnemyManager manager;
	
	// Use this for initialization
	
	void Awake () 
	{
		PickRandomNumber();
	}
	
	void Start () 
	{				
		PickRandomNumber();	
		//chooseNextSong(randomNumber);		
		currentSong = randomNumber;
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
	}
	
	private void PickRandomNumber()
	{
		//yield WaitForSeconds(2);
		randomNumber = Random.Range(0,5);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(audio.isPlaying == false)
		{
			currentSong++;
			//chooseNextSong(currentSong);
		}		
	}	
	
	private void chooseNextSong(int s)
	{
		int songChoice = s;
		switch (songChoice)
		{
		    case 1:
				//audio.PlayOneShot(Impasse, 0.5f);
				print(randomNumber);
			break;
		    case 2:
				//audio.PlayOneShot(TheSkyFell, 0.5f);
				print(randomNumber);
			break;
		    case 3:
				//audio.PlayOneShot(TheCalm, 0.5f);
				print(randomNumber);
			break;
		    case 4:
				//audio.PlayOneShot(Arisen, 0.5f);
				print(randomNumber);
			break;
		    case 5:
				//audio.PlayOneShot(Overflow, 0.5f);
				print(randomNumber);
			break;
			default:
				//audio.PlayOneShot(Impasse, 0.5f);
				print(randomNumber);
			break;
		}		
	}
}
