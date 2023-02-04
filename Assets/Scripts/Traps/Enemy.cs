using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator _animator;
    protected Collider _collider;
    protected string[] stopTags = {"Wall", "Player", "Box", "Target"};
    public virtual void Die()
    {
        Destroy(this.gameObject, 0f);
    }
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
    protected bool CheckToward(int x, int y)
    {
        Vector3 center = _collider.bounds.center;
        
        Vector3 dir = new Vector3(x, 0, y);
        RaycastHit info;
        Physics.BoxCast(center, transform.localScale / 5f,  dir, out info, Quaternion.identity, 1);

        if (info.collider)
        {
            if (info.collider.CompareTag("Player")) return false;
            
            if (stopTags.Contains(info.collider.tag) || info.collider.CompareTag("SpikeGate"))
            {
                return true;
            }

            if (info.collider.CompareTag("Box"))
            {
                return !info.collider.GetComponent<Box>().Move(x, y);
            }

            if (info.collider.CompareTag("Enemy"))
            {
                Enemy script = info.collider.GetComponent<Enemy>();
                return script.CheckToward(x, y);

            }
            
        }
        return false;
    }

    protected virtual void MakeTurn()
    {
        
    }
}
