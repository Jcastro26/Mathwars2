using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barco : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount =100;
    

    // Start is called before the first frame update
    void Start(){
        TakeDamage(10);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E)){
            TakeDamage(20);
        }
    }


    

    public void TakeDamage(float damage){
        healthAmount-=damage;
        healthBar.fillAmount =healthAmount/100;
    }
    public void OnTriggerEnter2D(Collider2D other){
        this.TakeDamage(1);

    }
}


