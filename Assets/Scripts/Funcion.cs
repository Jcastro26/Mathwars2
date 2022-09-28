using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Funcion :MonoBehaviour
{
    	[SerializeField]
	Transform PointPrefab;
    public float dominio;
    public float resolucion;
    //public float step;
   // public var scale;
    // public var position;

    //constructor
    public Funcion(float dominio,float resolucion){
        this.dominio=dominio;
        this.resolucion=resolucion;

    }
    //metodos
    public void graficar(){
            float step =dominio/resolucion;
            var scale = Vector3.one*step;
            var position = Vector3.zero;
                    for (int i = 0; i<resolucion;i++){
            Transform point=  Instantiate(PointPrefab);
            //vector3.right mirando a la derecha (1,0,0) dividido pro 5 f para que se junten, +0.5 para llenar y -1f para moverlo en el eje x
            //  si a step se le resta la mitad del dominio ej:-1.5f grafica a la izquierda y derecha del orgigen, sino grafica desde ese punto a la derecha
            position.x = (i + 0.5f)*step ; 
            
            // hace una funcion lineal f(x)=y=x 
            //nota mental= aca se puede poder un metodo que modifique la funcion dependiendo de un parametro
            position.y= (float)Math.Sin( Math.PI*position.x); //SENO
            //position.y=position.x; // funcion lineal y=x

            //asigna el vector posicion a el punto 
            point.localPosition = position;
            //modifica la escala del punto *2f hace que sea mas grandes los cubos
            point.localScale = scale*3f;
            //hace que el padre sea el objeto graph (atra vez del atributo transform)
            point.SetParent(transform,false);
            }
       }
    }




