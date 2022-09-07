using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        LevelsManager.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
