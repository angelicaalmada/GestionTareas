using GestionTareas.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using GestionTareas.Conexion;
using Firebase.Database.Query;
using System.Linq;

namespace GestionTareas.Datos
{
    public class Dtareas
    {
        public async Task InsertarTarea(TareasModel parametros)
        {
            try
            {
                await Cconexion.firebase
                .Child("Tareas")
                .PostAsync(new TareasModel()
                {
                    IdTareas= Guid.NewGuid(),
                    Nombre = parametros.Nombre,
                    Descripcion = parametros.Descripcion,
                    Status = parametros.Status,
                }
                );
            }
            catch ( Exception ex )
            {

            }         
        }
        public async Task ModificarTareas(TareasModel datosActualizados)
        {
            var actualizar = (await Cconexion
                .firebase.Child("Tareas")
                .OnceAsync<TareasModel>())
                .Where(a => a.Object.IdTareas == datosActualizados.IdTareas).FirstOrDefault();

            await Cconexion.firebase
                .Child("Tareas")
                .Child(actualizar.Key)
                .PutAsync(new TareasModel()
                {
                    Nombre = datosActualizados.Nombre,
                    Descripcion = datosActualizados.Descripcion,
                    Status = datosActualizados.Status,
                    IdTareas = datosActualizados.IdTareas
                });
        }
        public async Task BorrarTarea(Guid idtareas)
        {
            var tareaBorrar = (await Cconexion.firebase
                .Child("Tareas")
                .OnceAsync<TareasModel>()).Where(a => a.Object.IdTareas == idtareas).FirstOrDefault();

            await Cconexion.firebase.Child("Tareas").Child(tareaBorrar.Key).DeleteAsync();
        }


        public async Task<ObservableCollection<TareasModel>> MostrarTareas()
        {
            var data = await Task.Run(() => Cconexion.firebase
                .Child("Tareas")
                .AsObservable<TareasModel>()
                .AsObservableCollection());
            return data;
        }

    }
    
}
