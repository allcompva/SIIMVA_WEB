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
    public class Ws_form_data_parametersService : IWs_form_data_parametersService
    {
        public Ws_form_data_parameters getByPk(int ID)
        {
            try
            {
                return Ws_form_data_parameters.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ws_form_data_parameters> read()
        {
            try
            {
                return Ws_form_data_parameters.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ws_form_data_parameters obj)
        {
            try
            {
                return Ws_form_data_parameters.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ws_form_data_parameters obj)
        {
            try
            {
                Ws_form_data_parameters.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ws_form_data_parameters obj)
        {
            try
            {
                Ws_form_data_parameters.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

