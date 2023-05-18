using MOTOR_WORKFLOW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOTOR_WORKFLOW.Services
{
    public interface IOficinasService
    {
        public List<Oficinas> read();
        public Oficinas getByPk(int codigo_oficina);
        public int insert(Oficinas obj);
        public void update(Oficinas obj);
        public void delete(Oficinas obj);
    }
}

