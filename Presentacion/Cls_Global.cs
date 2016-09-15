using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
   public static class Cls_Global
    {
            static string _id_usuario;
            public static  string id_usuario
        {
            get
            {
                return _id_usuario;
            }
            set
            {
                _id_usuario = value;
            }
        }


        static string _empresa;
        public static string empresa
        {
            get
            {
                return _empresa;
            }
            set
            {
                _empresa = value;
            }
        }


        static string _skinName;
        public static string skinName
        {
            get
            {
                return _skinName;
            }
            set
            {
                _skinName = value;
            }
        }

        static bool _mosrtra_msg_demora;
        public static bool mostrar_msg_demora
        {
            get
            {
                return _mosrtra_msg_demora;
            }
            set
            {
                _mosrtra_msg_demora = value;
            }
        }






    }
}
