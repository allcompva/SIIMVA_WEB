using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IWs_contenido_campo_formularioService
    {
        public List<Ws_contenido_campo_formulario> read();
        public Ws_contenido_campo_formulario getByPk();
        public int insert(Ws_contenido_campo_formulario obj);
        public void update(Ws_contenido_campo_formulario obj);
        public void delete(Ws_contenido_campo_formulario obj);
    }
}

