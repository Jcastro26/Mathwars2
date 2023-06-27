using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registro : MonoBehaviour
{
    FirebaseFirestore db;
    [SerializeField] public TMP_InputField registronombre = null;
    [SerializeField] private TMP_InputField registroEmail = null;
    [SerializeField] private TMP_InputField registroPass = null;
    [SerializeField] private TMP_InputField registroPass2 = null;
    [SerializeField] private Text REGISTROERROR = null;

    // login
    [SerializeField] public TMP_InputField loginnombre = null;
    [SerializeField] private TMP_InputField loginPass = null;
    [SerializeField] private Text loginerror = null;

    private CustomDictionary<string, object> usuarios;


    // Start is called before the first frame update
    void Start()
    {
        usuarios = new CustomDictionary<string, object>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
