using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    PlayerCollision playerCollision;
    // Start is called before the first frame update
    void Start()
    {
        playerCollision = FindObjectOfType<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        playerCollision.victory = true;
    }
}
