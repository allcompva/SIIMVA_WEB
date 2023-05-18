using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IRespuesta_formularioService
    {
        public List<Respuesta_formulario> read(int id_formularios);
        public Respuesta_formulario getByPk();
        public int insert(Respuesta_formulario obj);
        public void update(Respuesta_formulario obj);
        public void delete(Respuesta_formulario obj);
    }
}

