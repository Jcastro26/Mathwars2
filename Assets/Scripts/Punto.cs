using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punto : MonoBehaviour
{
    Collider2D ccollider;
    Boolean entrareliminar;
  
    int length;
    
    //funcion para detectar cuadno choca contra otro objeto
        //si se deja en other va a parecer que un unico punto está avanzando, se podria usar para una bala 
        public void OnTriggerEnter2D(Collider2D other){
            
            if (other.tag =="barcoenemigo"){
                ccollider=other;
                Graph grafico = GameObject.FindGameObjectWithTag("graphseno").GetComponent<Graph>();
                grafico.entrargraf=false;
                grafico.i=0;
                entrareliminar= true;
                length=0;
                
                 var puntos = GameObject.FindGameObjectsWithTag ("punto");
                length=puntos.Length;
                
             }

         }
    void Update(){

    }
}
