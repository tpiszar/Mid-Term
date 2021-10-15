using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPlat : MonoBehaviour
{
    public GameObject platform;
    public float nextHeight = 3;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        GameObject newPlat = Instantiate(platform, new Vector3(Random.Range(-4f, 4f), this.transform.position.y + nextHeight, Random.Range(-4f, 4f)), Quaternion.identity);
        Destroy(this);
    }
}
