public class Escarabajo : FichaLogica
{




    public Escarabajo(int numjug)
    {
        this.tipo = 4;
        this.jugador = numjug;
    }
    public Escarabajo(int numjug, int x, int y)
    {
        this.tipo = 4;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
    }
    public Escarabajo(int pindiceprefab,int numjug, int x, int y)
    {
        this.tipo = 4;
        this.jugador = numjug;
        this.ActualX = x;
        this.ActualY = y;
        this.indiceprefab = pindiceprefab;
    }
    public Escarabajo(int protacion,int pindiceprefab, int numjug, int x, int y)
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
