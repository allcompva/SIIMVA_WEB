using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using MOTOR_WORKFLOW.Entities;

namespace MOTOR_WORKFLOW.Services
{
    public class Ws_web_serviceService : IWs_web_serviceService
    {
        public Ws_web_service getByPk(int ID)
        {
            try
            {
                return Ws_web_service.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ws_web_service> read()
        {
            try
            {
                return Ws_web_service.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ws_web_service obj)
        {
            try
            {
                return Ws_web_service.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ws_web_service obj)
        {
            try
            {
                Ws_web_service.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ws_web_service obj)
        {
            try
            {
                Ws_web_service.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

