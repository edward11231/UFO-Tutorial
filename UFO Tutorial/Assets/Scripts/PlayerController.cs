using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public int scoreGoal = 12;

    private Rigidbody2D rigidbody2;
    private int count;

    public Text scoreText;
    public Text winText;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody2.AddForce(movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Game Quit");
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
            {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            }
    }

    void SetCountText()
    {
        scoreText.text = "Score " + count.ToString();
        if(count >= scoreGoal)
        {
            winText.text = "You win! Game created by Edward Tavarez";
        }
    }
}
