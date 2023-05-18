using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IWs_url_parametersService
    {
        public List<Ws_url_parameters> read();
        public Ws_url_parameters getByPk(int ID);
        public int insert(Ws_url_parameters obj);
        public void update(Ws_url_parameters obj);
        public void delete(Ws_url_parameters obj);
    }
}

