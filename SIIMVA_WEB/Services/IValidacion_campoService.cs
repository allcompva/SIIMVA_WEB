using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IValidacion_campoService
    {
        public List<Validacion_campo> read();
        public Validacion_campo getByPk(int ID);
        public int insert(Validacion_campo obj);
        public void update(Validacion_campo obj);
        public void delete(Validacion_campo obj);
    }
}

