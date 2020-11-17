using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject HealthText;
    public float speed;
    public float rotatespeed;
    public float damagerate = 10.0f;
    //public float health = 100.0f;
    public float JumpForce;
    public Text currentHealthLabel;
    Rigidbody playerRb;
    public float maxHealth = 10.0f; 
    public float currentHealth;
    bool IsDead = false;
    public Animator PlayerAnimation;
    //private int score;
    //public Text ScoreText;
    // private float _currentHealth;



    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
        // _currentHealth = health;
        float currentHealth = maxHealth;
        UpdateGUI();

        HealthText.GetComponent<Text>().text = "Health: " + currentHealth;
    }
    void UpdateGUI()
    {
        currentHealthLabel.text = currentHealth.ToString();
    }
    public void AlterHealth(int amount)
    {
        currentHealth += amount;
       currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateGUI();
    }








    // Update is called once per frame
    void Update()
    {


        //scoreText.GetComponent<Text>().text = "SpaceBar: " + score;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //   score = score + 1;

        // }


        if (IsDead == false)
        {

            float Inputvertical = Input.GetAxis("Vertical");
            float Inputhorizontal = Input.GetAxis("Horizontal");


            transform.Translate(Vector3.forward * Time.deltaTime * Inputvertical * speed);
            transform.Translate(Vector3.right * Time.deltaTime * Inputhorizontal * speed);








            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerAnimation.SetBool("IsMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                PlayerAnimation.SetBool("IsMove", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * -speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                PlayerAnimation.SetBool("IsMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                PlayerAnimation.SetBool("IsMove", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.right * Time.deltaTime * -speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                PlayerAnimation.SetBool("IsMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                PlayerAnimation.SetBool("IsMove", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                PlayerAnimation.SetBool("IsMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                PlayerAnimation.SetBool("IsMove", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerAnimation.SetTrigger("IsAttack");
            }



        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (IsDead == false)
        {



            if (other.gameObject.tag == "Fire")
            {

                maxHealth -= damagerate * Time.deltaTime;
                currentHealthLabel.GetComponent<Text>().text = "Health" + maxHealth.ToString("0");

            }
            if (maxHealth == 0)
            {
                PlayerAnimation.SetTrigger("IsDead");
                IsDead = true;
            }
        }
    }

}