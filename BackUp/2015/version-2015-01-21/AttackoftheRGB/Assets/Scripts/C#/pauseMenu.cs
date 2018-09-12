using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour 
{
	
	//GUI Styles
    public GUIStyle redbutton;	
	public GUIStyle greenbutton;
	public GUIStyle bluebutton;

    private Rect windowRect;
    private bool paused = false , waited = true;
	public roundsAndEnemyManager manager;

    private void Start()
    {
        windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 35, 200, 150);
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<roundsAndEnemyManager>();
    }

    private void waiting()
    {
        waited = true;
    }

    private void Update()
    {
        if (waited)
            if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
            {
                if (paused)
				{
                    paused = false;
				}
                else
				{
                    paused = true;
				}

                waited = false;
                Invoke("waiting",0.3f);
            }

        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    private void OnGUI()
    {
        if (paused)
		{
			manager.pausedText.enabled = true;
            windowRect = GUI.Window(0, windowRect, windowFunc, "",GUIStyle.none);
		}
    }

    private void windowFunc(int id)
    {
        if (GUI.Button(new Rect (10,20,178,30),"Resume",redbutton))
        {
            paused = false;
			Time.timeScale = 1;
			manager.pausedText.enabled = false;
        }
        
        if (GUI.Button(new Rect (10,60,178,30),"Restart",greenbutton))
        {
            Application.LoadLevel(1);
            paused = false;
			manager.pausedText.enabled = false;
			manager.managerRestart();
        }
        
        if (GUI.Button(new Rect (10,100,178,30),"Quit",bluebutton))
        {
            Application.LoadLevel(0);
            paused = false;
			manager.pausedText.enabled = false;
			manager.managerRestart();
        }        
    }
}
