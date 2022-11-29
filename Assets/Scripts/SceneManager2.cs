using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SceneManager2 : MonoBehaviour
{

     [SerializeField] private GameObject m_registroUi          = null;
     [SerializeField] private GameObject m_LoginUI             = null;
     [SerializeField] private GameObject Canvasmenu             = null;
     [SerializeField] private GameObject Canvaslogin            = null;


    public void ShowLogin()
    {
     m_registroUi.SetActive(false);//para  mostrar la ui Registro
     m_LoginUI.SetActive(true);//para NOmostrar la ui de Login
     
     }

    public void ShowRegister() 
    {

     m_registroUi.SetActive(true);//para mostrar la ui de Registro
     m_LoginUI.SetActive(false);;//para NO mostrar la ui usuario

     }
     public void ShowloginMenu(){
          
          Canvasmenu.SetActive(false);
          
          Canvaslogin.SetActive(true);
     } 
}