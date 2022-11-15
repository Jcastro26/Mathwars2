using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registro : MonoBehaviour
{
     [SerializeField] private ImputField m_userNameImputd      = null;
     [SerializeField] private ImputField m_userEmailImputd     = null;
     [SerializeField] private ImputField m_userPasswortImputd  = null;
     [SerializeField] private ImputField m_userPasswort2Imputd = null;

     [SerializeField] private Text       m_errorText          = null;


     [SerializeField] private GameObject m_registroUi          = null;
     [SerializeField] private GameObject m_LoginUI             = null;


     private NetworkManager m_networkManager = null;

     private void Awake()
     {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
     }

     public void Subitlogin ()
     {
     
       if (m_userPasswortImputd.text == m_userPasswort2Imputd.text)
      {
          m_errorText="Procesando......";
          m_networkManager.CreateUser(m_userNameImputd.text,m_userEmailImputd.text,m_userPasswortImputd.text,delegade(Response response)
        {
     
          m_errorText.text = response.message;
      });
      
     }
      else
      {
          m_errorText="Error = contraseña no conside";
      }


     }
   
    public void ShowLogin()
    {
     m_registroUi.SetActive(false);//para NO mostrar la ui Registro
     m_LoginUI.SetActive(true);//para mostrar la ui de Login
     
     }

    public void ShowRegister() 
    {

     m_registroUi.SetActive(true);//para mostrar la ui de Registro
     m_LoginUI.SetActive(false);;//para NO mostrar la ui usuario

     }

}