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
    public class Validacion_campoService : IValidacion_campoService
    {
        public Validacion_campo getByPk(int ID)
        {
            try
            {
                return Validacion_campo.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Validacion_campo> read()
        {
            try
            {
                return Validacion_campo.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Validacion_campo obj)
        {
            try
            {
                return Validacion_campo.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Validacion_campo obj)
        {
            try
            {
                Validacion_campo.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Validacion_campo obj)
        {
            try
            {
                Validacion_campo.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

