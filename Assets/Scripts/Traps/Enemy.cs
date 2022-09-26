﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
