using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float damageRate;
    public GameObject HealthText;
    public Text HealthBar;

    public float Health = 100;
    private float _currentHealth;



    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = Health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            Health -= damageRate * Time.deltaTime;
            HealthBar.GetComponent<Text>().text = "Health" + _currentHealth;

        }
    }

}
