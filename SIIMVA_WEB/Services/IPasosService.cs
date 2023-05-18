using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IPasosService
    {
        public List<Pasos> read(int id_tramites);
        public Pasos getByPk(int id);
        public int insert(Pasos obj);
        public void update(Pasos obj);
        public void delete(Pasos obj);
    }
}

