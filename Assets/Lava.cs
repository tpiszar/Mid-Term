using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject camera;
    public float startDelay = 5f;
    private float startTime;
    public float speed = 1.5f;

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
        if (this.transform.position.y >= camera.transform.position.y - 1)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
