using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private int obgN=0;
    private Collider _collider;
    [SerializeField]private ParticleSystem[] particles;

    private string[] tags = {"Player1", "Box"};
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        GameEvents.current.OnNextTurn += ActiveUpdate;
        SetActive(Check());
    }

    // Update is called once per frame
    private void ActiveUpdate()
    {
        SetActive(Check());
        StartCoroutine(ActiveUpdate2());
    }

    private IEnumerator ActiveUpdate2()
    {
        yield return new WaitForSeconds(0.05f);
        SetActive(Check());
    }


    private bool Check()
    {
        Collider[] colliders = Physics.OverlapSphere(_collider.bounds.center, 0.1f);
 
        foreach (var col in colliders)
        {
            if (tags.Contains(col.tag))
            {
                return false;
            }
        }
        return true;
    }



    private void SetActive(bool act)
    {
        foreach (var partc in particles)
        {
            if (act && partc.isStopped)
            {
                partc.Play();
            }
            else if (!act)
            {
                partc.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            SetActive(false);
        }
    }

    

  

    
}
