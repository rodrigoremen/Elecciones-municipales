public class TestCandidatos
{
    private const string PASSWORD = "1234";
    private static int intentos = 3;
    private static Candidato[] candidatos = new Candidato[3];

    public static void Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Introduce el nombre del candidato " + (i + 1) + ": ");
            string nombre = Console.ReadLine();
            candidatos[i] = new Candidato(nombre);
        }

        bool casillaAbierta = true;
        while (casillaAbierta)
        {
            Console.WriteLine("\n1. Votar por candidato " + candidatos[0].Nombre);
            Console.WriteLine("2. Votar por candidato " + candidatos[1].Nombre);
            Console.WriteLine("3. Votar por candidato " + candidatos[2].Nombre);
            Console.WriteLine("4. Cerrar casilla");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                case "2":
                case "3":
                    candidatos[int.Parse(opcion) - 1].Votar();
                    break;
                case "4":
                    Console.Write("Introduce la contraseña: ");
                    string pass = Console.ReadLine();

                    if (pass == PASSWORD)
                    {
                        casillaAbierta = false;
                    }
                    else
                    {
                        intentos--;
                        if (intentos == 0)
                        {
                            casillaAbierta = false;
                        }
                        else
                        {
                            Console.WriteLine("Contraseña incorrecta. Tienes " + intentos + " intentos restantes.");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        int totalVotos = candidatos[0].Votos + candidatos[1].Votos + candidatos[2].Votos;
        if (totalVotos == 0)
        {
            Console.WriteLine("Urna vacía");
            return;
        }

        if (candidatos[0].Votos == candidatos[1].Votos || candidatos[0].Votos == candidatos[2].Votos || candidatos[1].Votos == candidatos[2].Votos)
        {
            Console.WriteLine("Se cayó el sistema");
            return;
        }

        Candidato ganador = candidatos[0];
        if (candidatos[1].Votos > ganador.Votos)
        {
            ganador = candidatos[1];
        }
        if (candidatos[2].Votos > ganador.Votos)
        {
            ganador = candidatos[2];
        }

        Console.WriteLine("\nGanador: " + ganador.Nombre + " con " + ganador.Votos + " votos (" + ((double)ganador.Votos / totalVotos * 100) + "%)");

        for (int i = 0; i < 3; i++)
        { 
                    Console.WriteLine(candidatos[i].Nombre + ": " + candidatos[i].Votos + " votos (" + ((double)candidatos[i].Votos / totalVotos * 100) + "%)");
        }
    }
}