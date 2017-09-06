using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : FichaLogica
{


    public Generador(int numjug)
    {
        this.tipo = 0;
        this.jugador = numjug;
    }
    public Generador(int numjug, int x, int y)
    {
        this.tipo = 0;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
    }
    public Generador(int pindiceprefab, int numjug, int x, int y)
    {
        this.tipo = 4;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
        this.indiceprefab = pindiceprefab;
    }
    public Generador(int protacion, int pindiceprefab, int numjug, int x, int y)
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
