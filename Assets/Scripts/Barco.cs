using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barco : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount =100;
    

    // Start is called before the first frame update


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
}
