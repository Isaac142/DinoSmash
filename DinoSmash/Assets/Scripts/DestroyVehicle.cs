using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyVehicle : MonoBehaviour
{

    public Text scoreText;
    public int score;

    public Text timeText;
    public float timer;

    public bool isOver = false;
    public GameObject isOverGO;
    public Text overText;

    public PlayerMovement PM;
    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        SetScoreText();
        timer = 30f;
        PM = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if(timer < 5)
        {
            timeText.text = "Time: " + timer.ToString("F2");
        }
        else
        {
            timeText.text = "Time: " + timer.ToString("F0");
        }

        if(timer <= 0)
        {
            isOverGO.SetActive(true);
            timer = 0f;
            PM.canMove = false;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if(isOver)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Car")
        {
            Destroy(col.gameObject);
            score = score + 100;
            SetScoreText();
        }

        if (col.gameObject.tag == "Truck")
        {
            Destroy(col.gameObject);
            score = score + 125;
            SetScoreText();
        }

        if (col.gameObject.tag == "Bike")
        {
            Destroy(col.gameObject);
            score = score + 25;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        overText.text = "YOUR FINAL SCORE: " + score.ToString();
    }
}
