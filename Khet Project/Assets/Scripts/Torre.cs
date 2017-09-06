using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : FichaLogica
{


    public Torre(int numjug)
    {
        this.tipo = 2;
        this.jugador = numjug;
    }
    public Torre(int numjug, int x, int y)
    {
        this.tipo = 2;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
    }
    public Torre(int pindiceprefab, int numjug, int x, int y)
    {
        this.tipo = 4;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
        this.indiceprefab = pindiceprefab;
    }
    public Torre(int protacion, int pindiceprefab, int numjug, int x, int y)
    {
        this.tipo = 4;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
        this.indiceprefab = pindiceprefab;
        this.rotacion = protacion;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

