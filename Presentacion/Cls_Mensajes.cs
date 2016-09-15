using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public static class Cls_Mensajes
    {
       
    static string error;
        public static string error_sistema {  get { return error = " Ocurrio un problema comuníquese con sistemas."; }
            set { error = value; }
        }

    static string ventana; 
        public static string titulo_ventana { get { return ventana="Aviso"; }
            set { ventana = value; }
        }

    static string previo;
        public static string titulo_previo  { get { return previo = "Se procedera a grabar los datos, desea continuar?"; }
            set { previo = value; }
        }

    static string exito;
        public static string titulo_exito { get { return exito = "Datos Grabados."; }
            set { exito = value; }
        }

    static string todos;
        public static string titulo_todos { get { return todos = "Esta tarea puede demorar ya que se mostraran todos los registros, desea continuar?."; }
            set { todos = value; }
        }

    }



}
