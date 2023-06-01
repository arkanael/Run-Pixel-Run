using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float speedMultiplier;
    void Awake()
    {
        minSpeed = 4;
        currentSpeed = minSpeed;
        GenereteSpikeWithGap();
    }

    public void Update()
    {
        if (currentSpeed < maxSpeed) 
        {
            currentSpeed += speedMultiplier;
        }
    }
    public void GenereteSpikeWithGap() 
    {
        float randowWait = Random.Range(0.1f, 1.5f);
        Invoke("GenerateSpike", randowWait);
    }

    private void GenerateSpike()
    {
        GameObject spikeInstance = Instantiate(spike, transform.position, transform.rotation);
        spikeInstance.GetComponent<SpikeScript>().spikeGenerator = this;
    }
}
