using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    [SerializeField]
    private float startDelay = 2, repeatRate = 2;

    private void OnTriggerEnter(Collider other)
    {
        //Instantiate(obstaclePrefab, this.gameObject.transform.position, obstaclePrefab.transform.rotation);
    }
}
