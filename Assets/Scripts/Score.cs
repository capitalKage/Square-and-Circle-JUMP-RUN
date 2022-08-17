using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public AudioClip scoreClip;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(scoreClip);
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        
    }
}
