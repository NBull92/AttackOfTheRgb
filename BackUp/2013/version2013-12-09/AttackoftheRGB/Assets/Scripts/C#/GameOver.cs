using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
    public GUISkin myskin;	

    private Rect windowRect;
    public bool GameEnd = false;
	private bool waited = true;

    private void Start()
    {
        windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);
    }

    private void waiting()
    {
        waited = true;
    }

    private void Update()
    {
	        if (GameEnd)
			{
	            //GameEnd = false;
			}
	
	        waited = false;
	        Invoke("waiting",0.3f);
		
          

        if (GameEnd)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    private void OnGUI()
    {
        if (GameEnd)
            windowRect = GUI.Window(0, windowRect, windowFunc, "Game Over");
    }

    private void windowFunc(int id)
    {
        if (GUILayout.Button("Quit"))
        {
			Application.LoadLevel(0);
        }
    }
}
