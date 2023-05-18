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
    public class Ws_url_parametersService : IWs_url_parametersService
    {
        public Ws_url_parameters getByPk(int ID)
        {
            try
            {
                return Ws_url_parameters.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ws_url_parameters> read()
        {
            try
            {
                return Ws_url_parameters.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ws_url_parameters obj)
        {
            try
            {
                return Ws_url_parameters.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ws_url_parameters obj)
        {
            try
            {
                Ws_url_parameters.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ws_url_parameters obj)
        {
            try
            {
                Ws_url_parameters.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

