using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		Screen.lockCursor = false;
		UnityEngine.Cursor.visible = true;

		if(GUI.Button(new Rect(Screen.width/2 -(buttonWidth/2),(2*Screen.height/9)-(buttonHeight/2),buttonWidth,buttonHeight),"Start Solo !"))
		{
			SceneManager.LoadScene("JeuLocal");
		}
		if(GUI.Button(new Rect(Screen.width/2 -(buttonWidth/2),(2*Screen.height/9)-(buttonHeight/2) + 2* buttonHeight,buttonWidth,buttonHeight),"Start Survival !"))
		{
			SceneManager.LoadScene("map 2");

		}
		if(GUI.Button(new Rect(Screen.width/2 -(buttonWidth/2),(2*Screen.height/9)-(buttonHeight/2) + 4 * buttonHeight,buttonWidth,buttonHeight),"Quit"))
		{
			Application.Quit();
		}
	}

}
