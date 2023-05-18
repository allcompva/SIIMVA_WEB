using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IValidacion_x_campo_formularioService
    {
        public List<Validacion_x_campo_formulario> read();
        public Validacion_x_campo_formulario getByPk(int ID);
        public int insert(Validacion_x_campo_formulario obj);
        public void update(Validacion_x_campo_formulario obj);
        public void delete(Validacion_x_campo_formulario obj);
    }
}

