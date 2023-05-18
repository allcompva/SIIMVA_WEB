using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IFormulariosService
    {
        public List<Formularios> read();
        public Formularios getByPk(int id);
        public Formularios getByIdPasos(int id_pasos);
        public int insert(Formularios obj);
        public void update(Formularios obj);
        public void delete(Formularios obj);
    }
}

