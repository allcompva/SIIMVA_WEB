using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IAdjuntosService
    {
        public List<Adjuntos> read();
        public Adjuntos getByPk(int id);
        public Adjuntos getByIdPasos(int id);
        public int insert(Adjuntos obj);
        public void update(Adjuntos obj);
        public void delete(Adjuntos obj);
    }
}

