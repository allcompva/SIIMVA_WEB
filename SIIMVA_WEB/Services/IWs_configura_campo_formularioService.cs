using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IWs_configura_campo_formularioService
    {
        public List<Ws_configura_campo_formulario> read();
        public Ws_configura_campo_formulario getByPk(int ID);
        public int insert(Ws_configura_campo_formulario obj);
        public void update(Ws_configura_campo_formulario obj);
        public void delete(Ws_configura_campo_formulario obj);
    }
}

