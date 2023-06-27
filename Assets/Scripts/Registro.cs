using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Registro : MonoBehaviour
{
    private Dictionary<string, string> registeredUsers;

    [SerializeField] public TMP_InputField registronombre = null;
    [SerializeField] private TMP_InputField registroEmail = null;
    [SerializeField] private TMP_InputField registroPass = null;
    [SerializeField] private TMP_InputField registroPass2 = null;
    [SerializeField] private Text REGISTROERROR = null;

    // login
    [SerializeField] public TMP_InputField loginnombre = null;
    [SerializeField] private TMP_InputField loginPass = null;
    [SerializeField] private Text loginerror = null;
     [SerializeField] private GameObject m_LoginUI = null;
     [SerializeField] private GameObject canvasmenu = null;
     [SerializeField] private TMP_Text nombrejugador  = null;
     [SerializeField] private TMP_Text iniciarsesionbotontexto  = null;

    private string currentUsername;

    void Start()
    {
        registeredUsers = new Dictionary<string, string>();
    }

    public void RegisterUser()
    {
        REGISTROERROR.text="Procesando...";

        if (registroPass.text == registroPass2.text)
        {
            if (!registeredUsers.ContainsKey("Nombre"))
            {
                registeredUsers.Add("Nombre", registronombre.text);
                registeredUsers.Add("Correo", registroEmail.text);
                registeredUsers.Add("Password", registroPass.text);

                Debug.Log("Registro exitoso.");
                REGISTROERROR.text = "¡Registro Completo! por favor inicie sesión";
            }
            else
            {
                REGISTROERROR.text = "El usuario ya existe.";
            }
        }
        else
        {
            REGISTROERROR.text = "Error: la contraseña no coincide.";
        }
    }

    public void LoginUser()
    {
        
        
        if (registeredUsers.ContainsKey("Nombre"))
        {
            if (registeredUsers["Nombre"].ToString() == loginnombre.text && registeredUsers["Password"].ToString() == loginPass.text)
            {
                currentUsername = registeredUsers["Nombre"].ToString();
                Debug.Log("Inicio de sesión exitoso para el usuario: " + currentUsername);
                nombrejugador.text="Bienvenido "+currentUsername;
                //iniciarsesionbotontexto.text="Cambiar cuenta";
                m_LoginUI.SetActive(false);
                canvasmenu.SetActive(true);
                Debug.Log("El nombre está en la base de datos, puedes volver al menu principal");
                //Debug.Log("La contraseña está en la base de datos");
                loginerror.text = "Bienvenido!, ya puedes volver al menú inicial.";
            }
            else {
                loginerror.text="La contraseña ingresada es incorrecta";
                Debug.Log("contraeña X");
            }
            
        }
        else
        {
            loginerror.text = "El usuario no existe.";
        }
    }
}