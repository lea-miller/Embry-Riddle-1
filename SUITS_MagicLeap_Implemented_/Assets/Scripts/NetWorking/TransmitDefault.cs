using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicLeapTools;


public class TransmitDefault : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StringMessage myMessage = new StringMessage("Hello World");
        Transmission.Send(myMessage);
        //Transmission.Instance.OnStringMessage.AddListener(HandleStringMessage);
    }

   
    private void HandleStringMessage(StringMessage stringMessage)
    {
        Debug.Log(stringMessage);
    }    
    
}
