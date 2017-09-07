using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piramide : FichaLogica
{

    /*
    public Piramide(int numjug)
    {
        this.tipo = 3;
        this.jugador = numjug;
    }
    public Piramide(int numjug, int x, int y)
    {
        this.tipo = 3;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
    }
    public Piramide(int pindiceprefab, int numjug, int x, int y)
    {
        this.tipo = 4;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
        this.indiceprefab = pindiceprefab;
    }*/
    public Piramide(int protacion, int pindiceprefab, int numjug, int x, int y)
    {
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

