using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI livescore;
    public float scoreCount;
    public float scorePersecond;
    public bool scoreIncreasing;

    public Text Hiscore;
    public float HiscoreCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += scorePersecond * Time.deltaTime;
        }
        if (scoreCount > HiscoreCount)
        {
            livescore.text = "  " + Mathf.Round(scoreCount);
        }
    }
}
