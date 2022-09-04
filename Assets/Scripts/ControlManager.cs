using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    [SerializeField] private Player player;

    private float verInp = 0f;

    private float horInp = 0f;
    
    
    // touch controls
    private Vector2 starTouchPos;
    private float sensetive = 15f;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verInp = Input.GetAxis("Vertical");
        if (Input.GetKeyDown( KeyCode.UpArrow))
        {
            player.Move(0, 1);
        }else if (Input.GetKeyDown( KeyCode.DownArrow))
        {
            player.Move(0, -1);
        }else if (Input.GetKeyDown( KeyCode.RightArrow))
        {
            player.Move(1, 0);
        }else if (Input.GetKeyDown( KeyCode.LeftArrow))
        {
            player.Move(-1, 0);
        }


        if (Input.GetMouseButtonDown(0))
        {
            starTouchPos = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(0))
        {
            
            Vector2 pos = Input.mousePosition;
            Vector2 delta = starTouchPos - pos;
            if (delta.y < -sensetive && delta.x < -sensetive)
            {
                player.Move(0, -1);
            }
            else if (delta.y > sensetive && delta.x > sensetive)
            {
                player.Move(0, 1);
            }
            else if (delta.y < -sensetive && delta.x > sensetive)
            {
                player.Move(1, 0);
            }
            else if (delta.y > sensetive && delta.x < -sensetive)
            {
                player.Move(-1, 0);
            }
        }
        
    }
    
}
