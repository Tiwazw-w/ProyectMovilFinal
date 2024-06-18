using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Evento : ScriptableObject
{
    public abstract void ElEvento(GameObject x, Action action);
}
