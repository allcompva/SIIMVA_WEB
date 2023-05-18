using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IAdjuntoService
    {
        public List<Adjunto> read();
        public Adjunto getByPk(int ID);
        public int insert(Adjunto obj);
        public void update(Adjunto obj);
        public void delete(Adjunto obj);
    }
}

