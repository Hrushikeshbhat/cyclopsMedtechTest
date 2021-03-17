using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Animator anime;
    [HideInInspector] public int points = 0;
    public Text scoreCounter;
    public Text scoreCounterFinal;
    public GameObject Death;
    public GameObject Pause;

    Rigidbody rb;
    bool isRunning = false;
    bool isDead = false;
    bool isPaused = false;
    Quaternion right = Quaternion.Euler(0, 90, 0);
    Quaternion left = Quaternion.Euler(0, 270, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            isRunning = Input.GetAxis("Horizontal") != 0 ? true : false;
            if (Input.GetAxis("Horizontal") < 0)
                transform.GetChild(1).transform.rotation = left;
            else if (Input.GetAxis("Horizontal") > 0)
                transform.GetChild(1).transform.rotation = right;
            anime.SetBool("Run", isRunning);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce);
                anime.SetTrigger("Jump");
            }

            scoreCounter.text = "Points = " + points;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                resumeGame();
            else
                pauseGame();
        }
    }


    public void pauseGame()
    {
        isPaused = true;
        Pause.SetActive(true);
        scoreCounter.enabled = false;
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        isPaused = false;
        scoreCounter.enabled = true;
        Pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {        
        Application.Quit();
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(!isDead)
        {
            if (other.tag == "kill" || other.tag == "car")
            {
                isDead = true;
                anime.SetTrigger("isDead");
                scoreCounter.enabled = false;
                scoreCounterFinal.text = "Score = " + points;
                Death.SetActive(true);
            }

            if (other.tag == "Points")
            {
                points++;
                other.GetComponent<BoxCollider>().enabled = false;
            }
        }        
    }
}
