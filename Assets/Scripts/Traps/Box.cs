using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    
    private Collider _collider;
    private Animator _animator;
    [SerializeField] private GameObject boxModel;
    [SerializeField] private ParticleSystem destroyParticles;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Move(int x, int y)
    {
        float rot = 0f;
        if (x == 1) rot = -90f;
        if (x == -1) rot = 90f;
        if (y == 1) rot = 180f;
        if (y == -1) rot = 0f;
        
        transform.rotation = Quaternion.Euler(0f, rot, 0f);
        boxModel.transform.rotation = Quaternion.Euler(0f, 0f, 0f);;
        if (!CheckToward(x, y))
        {
            transform.position = transform.position + new Vector3(x, 0, y);
            _animator.SetTrigger("move");
            return true;

        }

        return false;



    }
    private bool CheckToward(int x, int y)
        {
            Vector3 center = _collider.bounds.center;
            RaycastHit info;
            Physics.BoxCast(center, transform.localScale / 2.1f, -transform.forward, out info, Quaternion.identity, 1);
    
            if (info.collider)
            {
                if (info.collider.CompareTag("Wall"))
                {
                    return true;
                }
    
                if (info.collider.CompareTag("Box") || info.collider.CompareTag("Enemy"))
                {
                    //return !info.collider.GetComponent<Box>().Move(x, y);
                    return true;
                }
                if (info.collider.CompareTag("Collectibles") || info.collider.CompareTag("Target"))
                {
                    //return !info.collider.GetComponent<Box>().Move(x, y);
                    return true;
                }
                
            }
            return false;
        }

    public void Die()
    {
        destroyParticles.transform.parent = null;
        destroyParticles.Play();
        Destroy(destroyParticles.gameObject, 5f);
        Destroy(this.gameObject);
    }
}
