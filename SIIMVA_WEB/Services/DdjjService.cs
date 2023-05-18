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
    public class DdjjService : IDdjjService
    {
        public ddjj getByPk(int ID)
        {
            try
            {
                return ddjj.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ddjj> read()
        {
            try
            {
                return ddjj.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(ddjj obj)
        {
            try
            {
                return ddjj.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(ddjj obj)
        {
            try
            {
                ddjj.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(ddjj obj)
        {
            try
            {
                ddjj.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

