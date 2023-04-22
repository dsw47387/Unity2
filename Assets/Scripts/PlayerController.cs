using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float strength = 1;

    private Rigidbody2D rb;

    private void ShowRandomBirdColor()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        
        int randomChild = Random.Range(0,transform.childCount);
        transform.GetChild(randomChild).gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowRandomBirdColor();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(new Vector2(0, strength), ForceMode2D.Impulse);
            rb.velocity = Vector2.up * strength;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.Instance.OnGameOver();
    }
}
