using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Punto : MonoBehaviour
{
    private float puntos;  //puntos que tendremos

    private TextMeshProUGUI textMesh;//controlar el componende texto

    Collider2D ccollider;
    Boolean entrareliminar;
  
    
    
    //funcion para detectar cuadno choca contra otro objeto
        //si se deja en other va a parecer que un unico punto está avanzando, se podria usar para una bala 
        public void OnTriggerEnter2D(Collider2D other){
            
            if (other.tag =="barcoenemigo"){
                ccollider=other;
                //forma de encontrar objetos con el tag, y se obtiene el script de esta forma
                var graficos = GameObject.FindGameObjectsWithTag("graph");
                foreach(GameObject grafico in graficos){
                    Graph graficoscript= grafico.GetComponent<Graph>();
                    graficoscript.entrargraf=false;
                    graficoscript.i=0;
                }

                
                
                
                 var puntos = GameObject.FindGameObjectsWithTag ("punto");
                
                
             }

         }
    private void Start() // 
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    // lo siguiente es para que a cada segundo vaya aunmentado pero de manera controlada


    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }

}
