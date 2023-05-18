using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IIngresos_x_pasoService
    {
        public List<ingresos_x_paso> read(int idPaso);
        public ingresos_x_paso getByPk(int ID);
        public int insert(ingresos_x_paso obj);
        public void update(ingresos_x_paso obj);
        public void delete(ingresos_x_paso obj);
    }
}

