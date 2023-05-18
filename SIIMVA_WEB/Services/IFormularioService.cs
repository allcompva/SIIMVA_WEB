using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IFormularioService
    {
        public List<Formulario> read();
        public Formulario getByPk(int ID);
        public int insert(Formulario obj);
        public void update(Formulario obj);
        public void delete(Formulario obj);
    }
}

