using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWall : MonoBehaviour
{
    public GameObject wall;
    public GameObject camera;

    void Update()
    {
        if (camera.transform.position.y >= this.transform.position.y + 15)
        {
            Instantiate(wall, new Vector3(0, this.transform.position.y + 30, 0), Quaternion.identity);
            Destroy(this);
        }
    }
}
