using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zombie : Enemy
{
    
    [SerializeField] private ParticleSystem _dieParticles;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();

    }

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnNextTurn += MakeTurn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void MakeTurn()
    {
        Vector2Int dir = CheckAround();
        Move(dir.x, dir.y);
    }
    

    private void Move(int x, int y)
    {
        if (x == 0 && y == 0) return;
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("move")) return;
    
        float rot = 0f;
        if (x == 1) rot = -90f;
        if (x == -1) rot = 90f;
        if (y == 1) rot = 180f;
        if (y == -1) rot = 0f;
    
        transform.rotation = Quaternion.Euler(0f, rot, 0f);
        if (!CheckToward(x, y))
        {
            transform.position = transform.position + new Vector3(x, 0, y);
            _animator.SetTrigger("move");
            
        }

    }

    private RaycastHit Check(int x, int y, float distance)
    {
        Vector3 center = _collider.bounds.center;
        
        Vector3 dir = new Vector3(x, 0, y);
        RaycastHit[] hits = Physics.BoxCastAll(center, transform.localScale / 10f, dir, Quaternion.identity, distance);
        var sortedList = hits.Cast<RaycastHit>();
        sortedList = sortedList.OrderBy(item => item.distance);


        foreach (var hit in sortedList)
        {
            if (stopTags.Contains(hit.collider.tag))
            {
                return hit;
            }
        }
        RaycastHit info = new RaycastHit();
        return info;
    }

    private Vector2Int CheckAround()
    {
        for (int i = -2; i < 2; i++)
        {
            int x = i % 2;
            int y = (i + 1) % 2;
            RaycastHit info = Check(x, y, 10);
            if (info.collider)
            {
                if (info.collider.CompareTag("Player"))
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return Vector2Int.zero;
        

    }

    private void OnDestroy()
    {
        GameEvents.current.OnNextTurn -= MakeTurn;

        _dieParticles.transform.SetParent(null);
        _dieParticles.Play();
        Destroy(_dieParticles.gameObject, 3f);
        
    }
}
