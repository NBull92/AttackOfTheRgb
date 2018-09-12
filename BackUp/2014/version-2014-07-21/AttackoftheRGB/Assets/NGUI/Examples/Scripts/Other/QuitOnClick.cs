using UnityEngine;
using System.Collections;

[AddComponentMenu("NGUI/Examples/Quit On Click")]
public class QuitOnClick : MonoBehaviour {

	void OnClick ()
	{	
		Application.Quit();		
	}
}
