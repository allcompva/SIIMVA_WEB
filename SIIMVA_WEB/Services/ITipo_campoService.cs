using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface ITipo_campoService
    {
        public List<Tipo_campo> read();
        public Tipo_campo getByPk(int ID);
        public int insert(Tipo_campo obj);
        public void update(Tipo_campo obj);
        public void delete(Tipo_campo obj);
    }
}

