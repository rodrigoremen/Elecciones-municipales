using System;

public class Candidato
{
    private string nombre;
    private int votos;

    public string Nombre { get { return nombre; } set { nombre = value; } }
    public int Votos { get { return votos; } private set { votos = value; } }

    public Candidato(string nombre)
    {
        this.nombre = nombre;
        this.votos = 0;
    }

    public void Votar()
    {
        this.votos++;
    }
}