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
    public class Tipo_campoService : ITipo_campoService
    {
        public Tipo_campo getByPk(int ID)
        {
            try
            {
                return Tipo_campo.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tipo_campo> read()
        {
            try
            {
                return Tipo_campo.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tipo_campo obj)
        {
            try
            {
                return Tipo_campo.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tipo_campo obj)
        {
            try
            {
                Tipo_campo.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Tipo_campo obj)
        {
            try
            {
                Tipo_campo.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

