using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; }
    public int playerAnimal;

    float gravityModifier = 10;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Physics.gravity *= gravityModifier;
        instance = this;
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);               
    }
}
