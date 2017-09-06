using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichaLogica
{
    protected int ActualX;
    protected int ActualY;
    protected int jugador;
    protected int tipo;
    protected int indiceprefab;
    protected int rotacion;//1 si la ficha ve hacia la izq, 2 si ve hacia abajo, 3 a la derecha y 4 arriba.


    ~FichaLogica()
    {
        FichaLogica ficha = this;
        ficha = null;


    }
    
    public int getIndicePrefab()
    {
        return indiceprefab;
    }
    public void setIndicePrefab(int indice)
    {
        indiceprefab = indice;
    }
    public int getJugador()
    {
        return jugador;
    }
    public void setJugador(int pjug)
    {
        jugador = pjug;
    }
    public int getTipo()
    {
        return tipo;
    }
    public void setTipo(int t)
    {
        tipo = t;
    }
    public int getActualX()
    {
        return ActualX;
    }
    public int getActualY()
    {
        return ActualY;
    }
    public void setActualX(int x)
    {
        ActualX = x;
    }

    public void setActualY(int y)
    {
        ActualY = y;
    }
    public void SetPosicion(int x, int y)
    {
        ActualX = x;
        ActualY = y;
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
