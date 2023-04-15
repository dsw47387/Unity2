using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 1;

    void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.UpdateScore();
        Destroy(gameObject);
    }
    
}
