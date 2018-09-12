using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{	    
	//GUI Styles
    public GUIStyle redbutton;	
	public GUIStyle greenbutton;
	public GUIStyle bluebutton;
	
    private Rect windowRect;
    public bool GameEnd = false;
	private bool waited = true;
	public roundsAndEnemyManager manager;

    private void Start()
    {
        windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 75, 200, 150);
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
    }

    private void waiting()
    {
        waited = true;
    }

    private void Update()
    {
		if (waited)
		{
			waited = false;
	    	Invoke("waiting",0.3f);	
		}

        if (GameEnd)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    private void OnGUI()
    {
        if (GameEnd)
		{
            windowRect = GUI.Window(0, windowRect, windowFunc, "",GUIStyle.none);
		}
    }

    private void windowFunc(int id)
    {
		if (GUI.Button(new Rect (10,60,178,30),"Restart",greenbutton))
        {
            Application.LoadLevel(1);
            GameEnd = false;
			manager.gameOverText.enabled = false;
			manager.congratulationsText.enabled = false;
			manager.managerRestart();
        }
        
        if (GUI.Button(new Rect (10,100,178,30),"Quit",bluebutton))
        {
            Application.LoadLevel(0);
            GameEnd = false;
			manager.gameOverText.enabled = false;
			manager.congratulationsText.enabled = false;
			manager.managerRestart();
        }
    }
}