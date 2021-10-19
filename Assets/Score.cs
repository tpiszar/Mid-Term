using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public int score;
    private int prevScore = -1;

    // Start is called before the first frame update
    void Start()
    {
        score = -1;
        text.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (score != prevScore)
        {
            prevScore = score;
            text.text = "Score: " + score.ToString();
        }
    }
}
