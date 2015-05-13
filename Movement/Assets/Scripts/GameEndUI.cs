using UnityEngine;
using System.Collections;

public class GameEndUI : MonoBehaviour
{

    public GUISkin MyGUISkin;
    public Texture2D Background, Logo;

    public string[] CreditsTextLines = new string[0];

    public Rect WindowRect = new Rect((Screen.width / 2) - 100, Screen.height / 2, 200, 200);

    private string main = "main";
    
    private string textToDisplay = "Credits \n";

    private string menuState;

    private float volume = 1.0f;

    public float additionWidth;


    // Use this for initialization
    void Start()
    {

        menuState = main;

        for (int x = 0; x < CreditsTextLines.Length; x++)
        {
            textToDisplay += CreditsTextLines[x] + " \n";
        }
        textToDisplay += "Press Esc To Go Back";

    }

    private void OnGUI()
    {
        if (Background != null)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Background);
        }

        if (Logo != null)
        {
            GUI.DrawTexture(new Rect((Screen.width * .75f) + additionWidth, 30, 200, 200), Logo);
        }

        GUI.skin = MyGUISkin;

        if (menuState == main)
        {
            WindowRect = GUI.Window(0, WindowRect, menuFunc, "Game Over");
        }

       
    }



    private void menuFunc(int id)
    {
        if (GUILayout.Button("Return to Menu"))
        {
            Application.LoadLevel(0);
        }

       
        if (GUILayout.Button("Quit Game"))
        {
            Application.Quit();
        }
    }

   

    // Update is called once per frame
    void Update()
    {

       

    }


}