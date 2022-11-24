using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Creadorfunciones : MonoBehaviour
{
    [SerializeField] public Transform spawnPoint0;
    [SerializeField] public Transform spawnPoint1;
    [SerializeField] public Transform spawnPoint2;
    
    GameObject[] prefabstrigonometricas;
    // Start is called before the first frame update
    void Start()
    {
        
            int i =0;
            //carga los prefrabs en una lista
            prefabstrigonometricas = Resources.LoadAll<GameObject>("Prefabs") as GameObject[];
             foreach(GameObject prefab in prefabstrigonometricas){
                Debug.Log(i+" "+prefab);
                i++;
            }
        var rand= new System.Random();
        int i1=rand.Next(0,prefabstrigonometricas.Count());
        int i2=rand.Next(0,prefabstrigonometricas.Count());
        int i3=rand.Next(0,prefabstrigonometricas.Count());
        instanciarFuncion(i1,spawnPoint0);
        //verifica que la funcion 1 no sea igual a la funcion 2
        if(i1==i2){
            Boolean soniguales=true;
            while(soniguales){
                i2=rand.Next(0,prefabstrigonometricas.Count());
                if(i1!=i2){
                    instanciarFuncion(i2,spawnPoint1);
                    soniguales=false;
                }
            }
        }
        else{
            instanciarFuncion(i2,spawnPoint1);
        }
        if(i3==i1||i3==i2){
            while(i3==i1||i3==i2){
                i3=rand.Next(0,prefabstrigonometricas.Count());
                if(i3!=i1&&i3!=i2){
                    instanciarFuncion(i3,spawnPoint2);
                    break;
                }
            }
        }
        else{
            instanciarFuncion(i3,spawnPoint2);
        }
    }
                            
    // Update is called once per frame
    void Update()
    {
        
    }
    void instanciarFuncion(int i,Transform spawnPoint){
        GameObject funcion1=Instantiate(prefabstrigonometricas[i],spawnPoint.position,spawnPoint.rotation);
        funcion1.transform.SetParent(spawnPoint,true);
        funcion1.transform.localScale= Vector3.one;
        funcion1.transform.position+=new Vector3(0.5f,0,0);
        //obtiene el objeto graph y lo modifica para que quede en 0 en y 
        GameObject graph = funcion1.transform.GetChild(1).gameObject;
        graph.transform.position=graph.transform.position+(new Vector3(-1,0f-graph.transform.position.y,0));
    }
}
