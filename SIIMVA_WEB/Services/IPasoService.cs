using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IPasoService
    {
        public List<Paso> read(int idTramite);
        public List<Paso> readBackEnd(int idTramite);
        public Paso getByPk(int ID);
        public int insert(PasoModel obj);
        public void update(PasoModel obj);
        public void delete(Paso obj);
    }
}

