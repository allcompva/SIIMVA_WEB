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
    public class OficinasService : IOficinasService
    {
        public Oficinas getByPk(int codigo_oficina)
        {
            try
            {
                return Oficinas.getByPk(codigo_oficina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Oficinas> read()
        {
            try
            {
                return Oficinas.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Oficinas obj)
        {
            try
            {
                return Oficinas.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Oficinas obj)
        {
            try
            {
                Oficinas.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Oficinas obj)
        {
            try
            {
                Oficinas.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

