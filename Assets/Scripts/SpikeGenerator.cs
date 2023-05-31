using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    void Awake()
    {
        currentSpeed = minSpeed;
        GenereteSpike();
    }


    public void GenereteSpike()
    {
        GameObject spikeInstance = Instantiate(spike, transform.position, transform.rotation);
        spikeInstance.GetComponent<SpikeScript>().spikeGenerator = this;
    }
}
