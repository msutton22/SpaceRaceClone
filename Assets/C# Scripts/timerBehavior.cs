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
    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTimer;
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
    }
}
