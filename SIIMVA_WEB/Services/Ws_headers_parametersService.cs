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
    public class Ws_headers_parametersService : IWs_headers_parametersService
    {
        public Ws_headers_parameters getByPk(int ID)
        {
            try
            {
                return Ws_headers_parameters.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ws_headers_parameters> read()
        {
            try
            {
                return Ws_headers_parameters.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ws_headers_parameters obj)
        {
            try
            {
                return Ws_headers_parameters.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ws_headers_parameters obj)
        {
            try
            {
                Ws_headers_parameters.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ws_headers_parameters obj)
        {
            try
            {
                Ws_headers_parameters.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

