using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SceneManager2 : MonoBehaviour
{
     [SerializeField] public TMP_InputField m_userNameInput      = null;
     [SerializeField] private TMP_InputField m_userEmailInput     = null;
     [SerializeField] private TMP_InputField m_userPasswortInput  = null;
     [SerializeField] private TMP_InputField m_userPasswort2Input = null;
     [SerializeField] private Text       m_errorText          = null;
     [SerializeField] private GameObject m_registroUi          = null;
     [SerializeField] private GameObject m_LoginUI             = null;

     private NetworkManager m_networkManager = null;

     private void Awake()
     {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
     }

    
     public void SubnitRegister(){
    
       if (m_userPasswortInput.text == m_userPasswort2Input.text)//si clave 1 es igual a clave 2
      {
          m_errorText.text="Procesando......";

          m_networkManager.CreateUser(m_userNameInput.text,m_userEmailInput.text,m_userPasswortInput.text,delegate(Response response)//creando Usuario
          {
           m_errorText.text=response.message;
          });
        }
      
      else
      {
          m_errorText.text ="Error = contraseña no conside";
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