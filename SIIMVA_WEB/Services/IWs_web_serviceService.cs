using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;
namespace MOTOR_WORKFLOW.Services
{
    public interface IWs_web_serviceService
    {
        public List<Ws_web_service> read();
        public Ws_web_service getByPk(int ID);
        public int insert(Ws_web_service obj);
        public void update(Ws_web_service obj);
        public void delete(Ws_web_service obj);
    }
}

