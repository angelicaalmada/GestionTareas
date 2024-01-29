using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionTareas.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://gestiontareas-97b1b-default-rtdb.firebaseio.com/Tareas");
    }
}
