using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    int animalSelected = 0;

    public void StartGame()
    {
        if (animalSelected < 1)
        {
            Debug.Log("Please select an animal first");
        }
        else
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
        
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

        #else
        Application.Quit();

        #endif
    }

    public void DropDownValue(int value)
    {
        animalSelected = value;
        MainManager.instance.playerAnimal = value;
       
        Debug.Log("Valor selecionado : " + value);
    }
}
