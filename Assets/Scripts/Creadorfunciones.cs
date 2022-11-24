using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creadorfunciones : MonoBehaviour
{
    public GameObject funcion;
    [SerializeField] private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject funcion1=Instantiate(funcion,spawnPoint.position,spawnPoint.rotation);
        funcion1.transform.SetParent(spawnPoint,true);
        funcion1.transform.localScale= Vector3.one;
        funcion1.transform.position+=new Vector3(0.5f,0,0);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
