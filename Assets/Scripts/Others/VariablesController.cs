using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariablesController 
{
    private static bool muerto = false;
    private static bool nivel2 = false;
    private static bool nivel3 = false;

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

    public static bool Nivel2
    {
        get
        {
            return nivel2;
        }
        set
        {
            nivel2 = value;
        }
    }

    public static bool Nivel3
    {
        get
        {
            return nivel3;
        }
        set
        {
            nivel3 = value;
        }
    }

}
