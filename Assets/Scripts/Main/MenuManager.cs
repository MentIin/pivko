using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
 
    public static MenuManager S;

    
    // Start is called before the first frame update
    void Awake()
    {
        S = this;
        LevelsManager.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
