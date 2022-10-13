
using System.Collections;
using UnityEngine;

public class Dialig_Newtu : MonoBehaviour
{
   
   private bool isPlayerInRange; //principalmente creamos un buleano nos indicara si está cerc del npc
   
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision)  // si se toca el npc se diaparará el ontritriger
    {
      if (collision.gameObject.CompareTag("Player"))
      {
         isPlayerInRange = true; 
         Debug.Log("Se puede iniciar un dialogo");
      }
      
    }

     private void OnTriggerExit2D(Collider2D collision)  // si se sale del npc el ontritriger
     {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;   
            Debug.Log("No se puede iniciar un dialogo");
        }
       

     }

}

