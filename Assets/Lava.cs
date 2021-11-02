using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float startDelay = 5f;
    private float startTime;
    public float speed = 1.5f;
    public AudioSource destroySnd;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        startDelay = startDelay + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > startDelay)
        {
            Vector3 temp = this.transform.position;
            temp.y += speed * Time.deltaTime;
            this.transform.position = temp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 particleSpawnPoint = other.transform.position;
        Instantiate(explosionEffect, particleSpawnPoint, Quaternion.identity);
        destroySnd.Play();
        Destroy(other.gameObject);
    }
}
