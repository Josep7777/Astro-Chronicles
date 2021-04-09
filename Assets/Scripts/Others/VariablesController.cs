using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariablesController 
{
    private static bool muerto = false;

    public static bool Muerto
    {
        get
        {
            return muerto;
        }
        set
        {
            muerto = value;
        }
    }

}
