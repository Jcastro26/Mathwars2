using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;
public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform PointPrefab;
    //crea un slider ( por el rango) en la interfaz del script que modifica la resolucion
    //en otras palabras la cantidad de cuadrados que se dibujasn
    [SerializeField,Range(10,500)]
    int resolution = 10;
    [SerializeField]
    float dominio = 2f;
    public String funcion="seno";
    public Button btnClick;
    public TMP_InputField amplitudfield;
    public float amplitud;
    public TMP_InputField periodofield;
    public float periodo;
    public TMP_InputField movhozfield;
    public float movhoz;
    // void Awake(){
    //     Graficar();
    // }
    //funciona onlick() unity interfaz
    // void onEnable(){
        
    //     //Graficar(this.funcion);
    // }
    private void Start(){
        //listener click
        btnClick.onClick.AddListener(Graficar);
    }
    public void GetInput(){
        Debug.Log("Log input: "+amplitudfield.text);
    } 
    public void Graficar(){
        //EditorUtility.DisplayDialog("a","Aguacate","sssas");  <-- dialogo de unity que se puede usar para avisar de errores al hacer input
                //3f es el dominio de la funcion , la funcion se muestra de 
        // si no se ha ingresado nada en el input field se pone en 1 por default        
            if( amplitudfield.text==null ||amplitudfield.text==""){
     
          amplitudfield.text = "1";  
          }
          if( periodofield.text==null ||periodofield.text==""){
     
          periodofield.text = "1";  
          }
          if( movhozfield.text==null ||movhozfield.text==""){
     
          movhozfield.text = "0";  
          }
                
                
            this.amplitud=float.Parse(amplitudfield.text);      
            this.movhoz=float.Parse(movhozfield.text);    
            this.periodo=float.Parse(periodofield.text);
        if(amplitud>=3){
            resolution=900;
        }
        float step = dominio/resolution;
        //vector.one= (1,1,1)
        var scale = Vector3.one*step;
        var position= Vector3.zero;
        //cantidad de cubos
        for (int i = 0; i<resolution;i++){
            
            Transform point=  Instantiate(PointPrefab);
            //vector3.right mirando a la derecha (1,0,0) dividido pro 5 f para que se junten, +0.5 para llenar y -1f para moverlo en el eje x
            //  si a step se le resta la mitad del dominio ej:-1.5f grafica a la izquierda y derecha del orgigen, sino grafica desde ese punto a la derecha
            position.x = (i + 0.5f)*step ; 

            // hace una funcion lineal f(x)=y=x 
            //nota mental= aca se puede poder un metodo que modifique la funcion dependiendo de un parametro
            switch(funcion){
                case "seno":
                    position.y= amplitud*seno(periodo*position.x);
                    break;
                case "coseno":
                    position.y= coseno(position.x);
                    break;
                case "cuadratica":
                    position.y= (( (cuadratica(position.x ) )/5)-1)*-1;
                    break;
                case "tangente":
                    position.y= (( (tangente(position.x ) )));
                    break;
            }
   
            //position.y=position.x; // funcion lineal y=x

            //asigna el vector posicion a el punto 
            point.localPosition = position;
            //modifica la escala del punto *2f hace que sea mas grandes los cubos

            point.localScale = scale*3f;
            //hace que el padre sea el objeto graph (atra vez del atributo transform)
            point.SetParent(transform,false);
 
        }
    }
    //hacer objeto de cada uno con sus atributos
    public float seno(double x){
        //Math.Sin((Math.PI*x)-((Math.PI*0.5)));
        return (float) Math.Sin((Math.PI*x)+((Math.PI*movhoz)/2));
    }
    public float cuadratica(double x){
        return (float) Math.Pow(x,2);
    }
    public float coseno(double x){
        return (float) Math.Cos(Math.PI*x);
    }
    public float tangente(double x){
        return (float) Math.Tan(Math.PI*x);
    }
    // idea nueva funcion return (float) 1/x proporcionalidad inversa
    // radical raiz y mirar como tomar solo los valores positivos o algo pro el estilo 
    //exponencial falta agregar
    //logaritmica 

}
