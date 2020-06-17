using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public Rigidbody rb;

    public float velocity = 1;

    public int score;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Fly up
            rb.velocity = Vector3.up * velocity;

            thisAnimation.Play();

        }
    }

    public void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("GameOver");
            GameOverScore.score = GameManager.thisManager.Score;
        } 
    }

    public void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Cleared")
        {
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
