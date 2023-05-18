using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IContenido_ingreso_pasoService
    {
        public List<contenido_ingreso_paso> read(int idIngresoPaso);
        public contenido_ingreso_paso getByPk(int ID);
        public int insert(contenido_ingreso_paso obj);
        public void update(contenido_ingreso_paso obj);
        public void delete(contenido_ingreso_paso obj);
    }
}

