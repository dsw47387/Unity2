using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    public float repeatRate = 1;
    private float timer = 0;
    public float pipeHeightRange = 3;
    public float coinHeightRange = 1;
    public GameObject prefabPipeGreen;
    public GameObject prefabPipeRed;
    public GameObject coinPrefab;

    // Update is called once per frame
    void Update()
    {
        if (timer > repeatRate)
        {
            timer = 0;
            SpawnPipe();
            SpawnCoin();
        }

        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        bool is_pipe_red = Random.Range(0, 2) == 1;
        GameObject newPipe = is_pipe_red ? Instantiate(prefabPipeGreen) : Instantiate(prefabPipeRed);
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-pipeHeightRange, pipeHeightRange), 0);
        Destroy(newPipe, 10f);
    }
    
    private void SpawnCoin()
    {
        bool is_coin_generated = Random.Range(0, 10) <= 7;

        if (!is_coin_generated) return;
        
        GameObject newCoin = Instantiate(coinPrefab);
        newCoin.transform.position = transform.position + new Vector3(2, Random.Range(-coinHeightRange, coinHeightRange), 0);
        Destroy(newCoin, 10f);
    }
}
