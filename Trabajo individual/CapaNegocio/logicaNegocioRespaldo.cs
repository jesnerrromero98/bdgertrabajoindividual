using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
   public class logicaNegocioRespaldo
   {
        accesosDatosRespaldoBD rbd = new accesosDatosRespaldoBD;
        public int respaldarBD()
        {
            return rbd.respaldarBD();
        }
   }
}
