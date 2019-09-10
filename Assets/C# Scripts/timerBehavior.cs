using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerBehavior : MonoBehaviour
{
    Image timerBar;
    public float maxTimer = 5f;
    float timeLeft;
    private float halfwayTimer = 2f;
    public GameObject halfwayText;
    public GameObject speedUpText;
    
    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTimer;
        halfwayText.SetActive(false);
        speedUpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTimer;
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            SceneManager.LoadScene (1); //if time runs out, go to end screen
        }

        if (timeLeft <= maxTimer / 2)
        {
            halfwayText.SetActive(true);
            speedUpText.SetActive(true);
            halfwayTimer -= Time.deltaTime;
            if (halfwayTimer <= 0)
            {
                halfwayText.SetActive(false);
                speedUpText.SetActive(false);
            }
        }
    }
}
