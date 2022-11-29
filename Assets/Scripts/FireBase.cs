using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine.UI;
using TMPro;
using System;
public class FireBase : MonoBehaviour
{
    FirebaseFirestore db;
     [SerializeField] public TMP_InputField registronombre      = null;
     [SerializeField] private TMP_InputField registroEmail     = null;
     [SerializeField] private TMP_InputField registroPass  = null;
     [SerializeField] private TMP_InputField registroPass2 = null;
     [SerializeField] private Text       REGISTROERROR         = null;

     // login
     [SerializeField] public TMP_InputField loginnombre = null;
     [SerializeField] private TMP_InputField loginPass  = null;
     [SerializeField] private Text loginerror  = null;
     [SerializeField] private Text nombreplayer ;
    [SerializeField] public GameObject zonaPlayer;
    [SerializeField] public GameObject zonaIniciar; 
        int i;
     public string nombreactual="0";
    void Start()
    {
         db = FirebaseFirestore.DefaultInstance;
        if(nombreactual==""){
            zonaIniciar.SetActive(true);
        }
        else{
            zonaPlayer.SetActive(true);
            nombreplayer.text="Bienvenido "+nombreactual;
        }        

    }
    public void addData(){
    REGISTROERROR.text="Procesando...";
    CollectionReference coleccionreference= db.Collection("usuarios");
      
        
        
    DocumentReference docRef = db.Collection("usuarios").Document(i.ToString());
    Dictionary<string, object> user = new Dictionary<string, object>
    {
            { "Nombre", registronombre.text },
            { "Correo", registroEmail.text },
            { "Password", registroPass.text },
            
    };
    docRef.SetAsync(user).ContinueWithOnMainThread(task => {
            Debug.Log("Registro añadido exitosamente");
            REGISTROERROR.text="¡Registro Completo! por favor inicie sesion";  
    });    
    }
    public void SubmitRegister(){

        if (registroPass.text == registroPass2.text)//si clave 1 es igual a clave 2
        {
                addData();
        }
        
        else
        {
        REGISTROERROR.text ="Error  contraseña no coincide";
        }
    }
    public void getSizeplusone(){
        i= 0;
        CollectionReference colref=db.Collection("usuarios");
        colref.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
        QuerySnapshot snapshot = task.Result;
        foreach (DocumentSnapshot document in snapshot.Documents)
        {

                Debug.Log(String.Format("User: {0}", document.Id)); 
                
                Dictionary<string,object> documentdict=document.ToDictionary();
                if(loginnombre.text==documentdict["Nombre"].ToString()&&loginPass.text!=documentdict["Password"].ToString()){
                        loginerror.text="La contraseña ingresada es incorrecta";
                        Debug.Log("contraeña X");
                } 
                if (loginPass.text==documentdict["Password"].ToString()&&loginnombre.text==documentdict["Nombre"].ToString()) {
                        nombreactual=documentdict["Nombre"].ToString();
                        Debug.Log("El nombre está en la base de datos");
                        Debug.Log("La contraseña está en la base de datos");
                }
                else if(loginPass.text!=documentdict["Password"].ToString()&&loginnombre.text!=documentdict["Nombre"].ToString()){
                        loginerror.text="No se encuentra registrado";
                }

                Debug.Log(String.Format("Nombre: {0}",documentdict["Nombre"]));

                i++;
                Debug.Log(i);
        }
        i=i+1;
        
        
        
        });
        Debug.Log(i);

    }
    public void login(){

    }
}