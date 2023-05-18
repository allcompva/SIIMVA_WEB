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
    public class TramiteService : ITramiteService
    {
        public Tramite getByPk(int ID)
        {
            try
            {
                return Tramite.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tramite> read()
        {
            try
            {
                return Tramite.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tramite obj)
        {
            try
            {
                return Tramite.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tramite obj)
        {
            try
            {
                Tramite.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Tramite obj)
        {
            try
            {
                Tramite.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

