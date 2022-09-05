using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] levelPrefabs;
    public int level=0;

    [SerializeField] private bool debug=false;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.HasKey("levelId") && !debug)
        {
            level = PlayerPrefs.GetInt("levelId");
        }
        else
        {
            
        }

        Instantiate(levelPrefabs[level]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
