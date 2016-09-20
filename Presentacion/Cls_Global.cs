using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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

        static bool _mostrar_msg_demora;
        public static bool mostrar_msg_demora
        {
            get
            {
                return _mostrar_msg_demora;
            }
            set
            {
                _mostrar_msg_demora = value;
            }
        }

        static bool _mostrar_ancho_xgrid;
        public static bool mostrar_ancho_xgrid
        {
            get
            {
                return _mostrar_ancho_xgrid;
            }
            set
            {
                _mostrar_ancho_xgrid = value;
            }
        }





    }

    public class TaskbarVista
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hwnd, int command);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(
               IntPtr parentHwnd,
               IntPtr childAfterHwnd,
               IntPtr className,
               string windowText);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        public static void Show()
        {
            SetVisibility(true);
        }
        public static void Hide()
        {
            SetVisibility(false);
        }

        private static void SetVisibility(bool show)
        {
            //Muestra u ocula la barra de tareas:
            IntPtr hwndTaskBar = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwndTaskBar, show ? SW_SHOW : SW_HIDE);

            //Muesta u ocula el botón de inicio ("Orbe") (Windows Wista / 7)
            IntPtr hwndOrb = FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);
            ShowWindow(hwndOrb, show ? SW_SHOW : SW_HIDE);
        }

    }


}
