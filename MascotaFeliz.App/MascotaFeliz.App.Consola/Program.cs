using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
       
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabajar con las tablas");

            //ListarDuenosFiltro();      
           // AddDueno();
            //BuscarDueno(1);
            
            //ListarDuenos();

            //ListarVeterinariosFiltro();
            //AddVeterinario();
            //BuscarVeterinario(1);
            //BuscarMascota(1);

            //AddMascota();
            //AsignarVeterinario();
            //AsignarDueno();
            //AsignarHistoria();

            //ListarMascotas();
            //ListarHistorias();
            
            //AddHistoria();
            //AsignarVisitaPyP(2);
            //ListarMascotas();

        }

        private static void AddDueno()
        {
            var dueno1 = new Dueno
            {
                Cedula = "10426579897",
                Nombres = " Sebastian",
                Apellidos = "Madrid",
                Direccion = "Envigado",
                Telefono = "304556844",
                Correo = "digui99@gmail.com"
            };
            var dueno2 = new Dueno
            {
                Cedula = "4566245",
                Nombres = "Oscar",
                Apellidos = "Alvarez",
                Direccion = "Itagui",
                Telefono = "32245554",
                Correo = "oscar32245@gmail.com"
            };
            _repoDueno.AddDueno(dueno1);
             _repoDueno.AddDueno(dueno2);
        
        }
        
    
    

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Cedula = "10426548798",
                Nombres = "Vanessa",
                Apellidos = "Lopez",
                Direccion = "caldas cr50 #99-18",
                Telefono = "3151155587",
                TarjetaProfesional = "TP00015"
            };
            _repoVeterinario.AddVeterinario(veterinario);

        }

        private static void AddMascota()
        {
            var mascota1 = new Mascota
            {
                Nombre = "Chachara",
                Color = "negro - blanco",
                Especie = "felino",
                Raza = "criollo"
            };
 

            var mascota2 = new Mascota
            {
                Nombre = "Lupe",
                Color = "Cafe",
                Especie = "Canino",
                Raza = "Labrador"
            };
         

            var mascota3 = new Mascota
            {
                Nombre = "Ragnar",
                Color = "negro",
                Especie = "Canino",
                Raza = "Lobo siberiano"
            };
            _repoMascota.AddMascota(mascota1);
            _repoMascota.AddMascota(mascota2);
            _repoMascota.AddMascota(mascota3);


        }

        private static void AddHistoria()
        {
            var historia = new Historia
            {
                FechaInicial = new DateTime(2020, 01, 01)
                

            };
            _repoHistoria.AddHistoria(historia);
        }

        private static void AsignarVisitaPyP(int idHistoria)
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                if (historia.VisitasPyP != null)
                {
                    historia.VisitasPyP.Add(new VisitaPyP { FechaVisita = new DateTime(1000, 09, 21), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema"});
                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>{
                        new VisitaPyP{FechaVisita = new DateTime(2000, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema" }
                    };
                }
                _repoHistoria.UpdateHistoria(historia);
            }
        }

        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Cedula + " " + dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
        }

        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Dueno.Nombres);        
        }

        private static void ListarDuenosFiltro()
        {
            var duenosM = _repoDueno.GetDuenosPorFiltro("Ped");
            foreach (Dueno p in duenosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

        private static void ListarDuenos()
        {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno d in duenos)
            {
                Console.WriteLine(d.Nombres + " " + d.Apellidos);
            }
        }

        private static void ListarMascotas()
        {
            var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascotas)
            {
                Console.WriteLine(m.Nombre + " " + m.Raza + " le pertenece a " + m.Dueno.Nombres + " " + m.Dueno.Apellidos+ " y lo atiende " + m.Veterinario.Nombres);
            }

        }

        private static void ListarHistorias()
        {
            var historias = _repoHistoria.GetAllHistorias();
            foreach (Historia h in historias)
            {
                Console.WriteLine(h.Id + " Este es el id de la historia");
            }
        }

        private static void ListarVeterinariosFiltro()
        {
            var veterinariosM = _repoVeterinario.GetVeterinariosPorFiltro("e");
            foreach (Veterinario p in veterinariosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

        private static void AsignarVeterinario()
        {
            var veterinario = _repoMascota.AsignarVeterinario(1, 2);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void AsignarDueno()
        {
            var dueno = _repoMascota.AsignarDueno(1, 4);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos);
        }

        private static void AsignarHistoria()
        {
            var historia = _repoMascota.AsignarHistoria(1,1);
        }


    }
}
