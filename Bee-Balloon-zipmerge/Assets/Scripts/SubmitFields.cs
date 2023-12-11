using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitFields : MonoBehaviour
{
    public Text status;
    public TextMeshProUGUI username;
    public TextMeshProUGUI feedback;
    public TMP_InputField nameField;
    public TMP_InputField feedbackField;

    public void Submit()
    {
        username.text = nameField.text;
        feedback.text = feedback.text;
        //status.text = "Thanks for playing!";

        Main.GenerateReport(name: username.text, feedback: feedback.text);

    }

    
    
   
}
