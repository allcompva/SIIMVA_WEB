using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IDdjjsService
    {
        public List<Ddjjs> read();
        public Ddjjs getByPk(int id);
        public Ddjjs getByIdPasos(int id_pasos);
        public int insert(Ddjjs obj);
        public void update(Ddjjs obj);
        public void delete(Ddjjs obj);
    }
}

