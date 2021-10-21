using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPlat : MonoBehaviour
{
    public GameObject platform;
    public GameObject scoreChecker;
    private Score score;
    public float nextHeight = 3;
    public AudioSource pointSnd;

    void Start()
    {
        if (scoreChecker != null)
        {
            score = scoreChecker.GetComponent<Score>();
        }
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Lava")
        {
            pointSnd.Play();
            score.score += 1;
            GameObject newPlat = Instantiate(platform, new Vector3(Random.Range(-4f, 4f), this.transform.position.y + nextHeight, Random.Range(-4f, 4f)), Quaternion.identity);
            newPlat.GetComponent<NextPlat>().score = score;
            Destroy(this);
        }
    }
}
