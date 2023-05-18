using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface ITramiteService
    {
        public List<Tramite> read();
        public Tramite getByPk(int ID);
        public int insert(Tramite obj);
        public void update(Tramite obj);
        public void delete(Tramite obj);
    }
}

