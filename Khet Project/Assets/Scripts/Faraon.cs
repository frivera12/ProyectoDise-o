using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faraon : FichaLogica
{


    public Faraon(int numjug)
    {
        this.tipo = 1;
        this.jugador = numjug;
    }
    public Faraon(int numjug, int x, int y)
    {
        this.tipo = 1;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
    }

    public Faraon(int pindiceprefab, int numjug, int x, int y)
    {
        this.tipo = 4;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
        this.indiceprefab = pindiceprefab;
    }
    public Faraon(int protacion, int pindiceprefab, int numjug, int x, int y)
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

