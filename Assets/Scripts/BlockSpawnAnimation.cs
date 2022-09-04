using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockSpawnAnimation : MonoBehaviour
{
    private float height=17;
    private float speed;
    private float targetHeight;
    private void Awake()
    {
        targetHeight = transform.position.y;
        transform.position = transform.position + Vector3.up * height;
        speed = Random.value * 3 + 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Cos(Time.timeSinceLevelLoad / 5 * speed) * height;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        //transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= targetHeight)
        {
            transform.position = new Vector3(transform.position.x, targetHeight, transform.position.z);
            DestroyImmediate(this);
        }
    }
}
