using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface ICampos_x_formularioService
    {
        public List<campos_x_formulario> read(int idFormulario);
        public campos_x_formulario getByPk(int ID);
        public int insert(campos_x_formulario obj);
        public void update(campos_x_formulario obj);
        public void delete(campos_x_formulario obj);
    }
}

