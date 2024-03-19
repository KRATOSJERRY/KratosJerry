using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public int speed;
    public int score;
    public int health;
    public int jumpforce;
    private Rigidbody2D rigidbody;
    public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        health=100;
        rigidbody=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
     void OnCollisionEnter2D(Collision2D colloider)
    {
        if(colloider.gameObject.tag == "coin")
        {
            score++;
            Destroy(colloider.gameObject);
        }
        else if(colloider.gameObject.tag == "spike")
        {
            health-=10;
            if(health<=0)
            {
                Destroy(gameObject);
            }
        }
    }
    void jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
    }
}