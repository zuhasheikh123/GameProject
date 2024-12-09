using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConditionalTriggerEvents : MonoBehaviour {


    public UnityEvent OnTriggerEvent;

    public void OnEvent()
    {
        if (OnTriggerEvent != null)
        {
            OnTriggerEvent.Invoke();
        }
    }


 
}
