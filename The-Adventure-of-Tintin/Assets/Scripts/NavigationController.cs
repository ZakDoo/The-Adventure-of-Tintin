using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    
    public void GoToMainMenu()
    {
        Application.LoadLevel(0);
    }
    
    public void GoToIntroLevel()
    {
        Application.LoadLevel(1);
    }


    public void GoToGameOverScene()
    {
        Application.LoadLevel(9);
    }

    public void GoRoVictoryScene()
    {
        Application.LoadLevel(10);
    }

    public void GoToCredits()
    {
        Application.LoadLevel(11);
    }

    public void Quit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
