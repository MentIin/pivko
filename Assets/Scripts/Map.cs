using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int height=5;

    public int weight=5;

    [SerializeField] private GameObject stone;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMap()
    {
        for (int z=0; z < height; z++)
        {
            for (int x=0; x < weight; x++)
            {
                Vector3 pos = new Vector3(x, 0, z);
                GameObject block = Instantiate(stone, pos, Quaternion.identity);
            }
        }
    }
}
