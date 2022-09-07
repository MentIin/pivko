using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public bool Completed = false;
    public int Stars = 0;
    public bool Locked = true;
    

    public void Complete()
    {
        this.Completed = true;
    }

    public void Complete(int stars)
    {
        this.Completed = true;
        this.Stars = stars;
    }

    public void Lock()
    {
        this.Locked = true;
    }

    public void Unlock()
    {
        this.Locked = false;
    }
}
