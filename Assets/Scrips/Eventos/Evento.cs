using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public  class Evento : ScriptableObject
{
    public virtual void ElEvento(GameObject x, UnityEvent action)
    {

    }
}
