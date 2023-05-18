using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IWs_form_data_parametersService
    {
        public List<Ws_form_data_parameters> read();
        public Ws_form_data_parameters getByPk(int ID);
        public int insert(Ws_form_data_parameters obj);
        public void update(Ws_form_data_parameters obj);
        public void delete(Ws_form_data_parameters obj);
    }
}

