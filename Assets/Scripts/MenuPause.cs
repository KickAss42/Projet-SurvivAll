using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

	private bool isPaused = false;
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Escape))
			isPaused = !isPaused;
		if (isPaused)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1.0f;
	}

	void OnGUI()
	{
		if (isPaused) 
		{
			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 - 20, 80, 40), "Continuer")) 
			{
				isPaused = false;
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Quitter")) 
			{
				SceneManager.LoadScene ("Menu");
				Screen.lockCursor = false;
				UnityEngine.Cursor.visible = true;
			}

		}
	}
}
