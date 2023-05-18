using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IWs_headers_parametersService
    {
        public List<Ws_headers_parameters> read();
        public Ws_headers_parameters getByPk(int ID);
        public int insert(Ws_headers_parameters obj);
        public void update(Ws_headers_parameters obj);
        public void delete(Ws_headers_parameters obj);
    }
}

