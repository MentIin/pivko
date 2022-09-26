using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Player.current.Die();
        }else if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Die();
        }
        else if (other.gameObject.CompareTag("Box"))
        {
            other.gameObject.GetComponent<Box>().Die();
        }
    }
}
