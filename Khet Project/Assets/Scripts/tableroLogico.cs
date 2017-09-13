using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableroLogico {

    private FichaLogica[,] matrizlogicafichas;
    private FichaLogica FichaSeleccionada;
    //private FichaLogica fichaslogicasactivas;
    private ArrayList fichaslogicasactivas=new ArrayList();


    public TableroLogico()
    {
        Debug.Log("se inicializo el tablero logico");
        matrizlogicafichas = new FichaLogica[10, 8];
        GenerarNivel1();
        insertarMatrizLogica();

    }
    void Awake()
    {
       
    }
    // Use this for initialization
    void Start() {
        Debug.Log("SI ENTRO");      
    }

    // Update is called once per frame
    void Update() {
       
    }
	
    public ArrayList getFichasActivas()
    {
        return fichaslogicasactivas;
    }

    private void colocarFichas(int indice, int x, int y) {
		
    }
	
 
    //clasico
    public void GenerarNivel1() {//jugador 1 rojas, jugador 2 blancas
       
        FichaLogica faraonR = new Faraon(0, 1, 1, 5, 7); fichaslogicasactivas.Add(faraonR);
        FichaLogica faraonB = new Faraon(0, 6, 2, 4, 0); fichaslogicasactivas.Add(faraonB);
        
        //piramides rojas
        FichaLogica piramideR1 = new Piramide(0, 3, 1, 7, 7); fichaslogicasactivas.Add(piramideR1);
        FichaLogica piramideR2 = new Piramide(0, 3, 1, 2, 6); fichaslogicasactivas.Add(piramideR2);
        FichaLogica piramideR3 = new Piramide(0, 3, 1, 0, 4); fichaslogicasactivas.Add(piramideR3);
        FichaLogica piramideR4 = new Piramide(0, 3, 1, 7, 4); fichaslogicasactivas.Add(piramideR4);
        FichaLogica piramideR5 = new Piramide(0, 3, 1, 0, 3); fichaslogicasactivas.Add(piramideR5);
        FichaLogica piramideR6 = new Piramide(0, 3, 1, 7, 3); fichaslogicasactivas.Add(piramideR6);
        FichaLogica piramideR7 = new Piramide(0, 3, 2, 3, 5); fichaslogicasactivas.Add(piramideR7);       

        //piramides blancas
        FichaLogica piramideB1 = new Piramide(0, 8, 2, 7, 1); fichaslogicasactivas.Add(piramideB1);
        FichaLogica piramideB2 = new Piramide(0, 8, 2, 2, 3); fichaslogicasactivas.Add(piramideB2);
        FichaLogica piramideB3 = new Piramide(0, 8, 2, 9, 3); fichaslogicasactivas.Add(piramideB3);
        FichaLogica piramideB4 = new Piramide(0, 8, 2, 2, 4); fichaslogicasactivas.Add(piramideB4);
        FichaLogica piramideB5 = new Piramide(0, 8, 2, 9, 4); fichaslogicasactivas.Add(piramideB5);
        FichaLogica piramideB6 = new Piramide(0, 8, 1, 6, 2); fichaslogicasactivas.Add(piramideB6);
        FichaLogica piramideB7 = new Piramide(0, 8, 2, 2, 0); fichaslogicasactivas.Add(piramideB7);
        //Generador Rojo
        FichaLogica generadorR = new Generador(0, 0, 1, 0, 7); fichaslogicasactivas.Add(generadorR);
        //Generador Blanco
        FichaLogica generadorB = new Generador(0, 5, 2, 9, 0); fichaslogicasactivas.Add(generadorB);
        //Escarabajo Rojo
        FichaLogica escarabajoR1 = new Escarabajo(0, 4, 1, 4, 4); fichaslogicasactivas.Add(escarabajoR1);
        FichaLogica escarabajoR2 = new Escarabajo(0, 4, 1, 5, 4); fichaslogicasactivas.Add(escarabajoR2);
        //Escarabajo Blanco
        FichaLogica escarabajoB1 = new Escarabajo(0, 9, 2, 4, 3); fichaslogicasactivas.Add(escarabajoB1);
        FichaLogica escarabajoB2 = new Escarabajo(0, 9, 2, 5, 3); fichaslogicasactivas.Add(escarabajoB2);
        //Torre Roja
        FichaLogica torreR1 = new Torre(0, 2, 1, 4, 7); fichaslogicasactivas.Add(torreR1);
        FichaLogica torreR2 = new Torre(0, 2, 1, 6, 7); fichaslogicasactivas.Add(torreR2);
        //Torre Blanca
        FichaLogica torreB1 = new Torre(0, 7, 2, 3, 0); fichaslogicasactivas.Add(torreB1);
        FichaLogica torreB2 = new Torre(0, 7, 2, 5, 0); fichaslogicasactivas.Add(torreB2);

    }

    public void insertarMatrizLogica()
    {
        ArrayList listaFichasAux = getFichasActivas();
        FichaLogica ficha;

        for (int i = 0; i < listaFichasAux.Count; i++)
        {
            ficha = (FichaLogica)listaFichasAux[i];
            matrizlogicafichas[ficha.getActualX(), ficha.getActualY()] = ficha;
        }
    }

    //defensivo
    public void GenerarNivel2()
    {
        

    }
    
    // ofensivo y defensivo
    public void GenerarNivel3() {
        
    }
    

    private void SeleccionarFicha(int x, int y) {
        /*if (fichas[x, y] == null) {
            return;

        }*/
		//if (fichas[x, y].esVerde != ScriptLogica.turnoJugadorVerde) {
			//return;
		//}
        /*	if (turnoJugadorVerde &&(fichas[x, y].EsVerde)) {
                FichaSeleccionada = fichas [x, y];
            } else {
                FichaSeleccionada = fichas [x, y];
            }*/
        //FichaSeleccionada = fichas[x, y];

    }

    private void MoverFicha(FichaLogica ficha,int px,int py) {
        ficha.SetPosicion(px,py);
        matrizlogicafichas[px, py] = matrizlogicafichas[ ficha.getActualX(), ficha.getActualY() ];
        matrizlogicafichas[ficha.getActualX(), ficha.getActualY()] = null;
    }

    public FichaLogica[,] getMatrizLogicaFichas()
    {
        return this.matrizlogicafichas;
    }

}
