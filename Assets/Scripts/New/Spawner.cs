using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    [SerializeField]
    private float startDelay = 2, repeatRate = 2;
    public GameObject player;

    public Vector3 defaultPosition;

    private void Start()
    {
        InvokeRepeating("SpawnerObjects", startDelay, repeatRate);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = defaultPosition;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, 9, 0), new Vector3(player.transform.position.x, 9, 0), 3* Time.deltaTime);
    }

    void SpawnerObjects()
    {
        Instantiate(obstaclePrefab, this.gameObject.transform.position, obstaclePrefab.transform.rotation);

    }
}
