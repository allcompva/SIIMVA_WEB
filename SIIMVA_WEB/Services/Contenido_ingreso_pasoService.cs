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
    public class Contenido_ingreso_pasoService : IContenido_ingreso_pasoService
    {
        public contenido_ingreso_paso getByPk(int ID)
        {
            try
            {
                return contenido_ingreso_paso.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<contenido_ingreso_paso> read(int idIngresoPaso)
        {
            try
            {
                return contenido_ingreso_paso.read(idIngresoPaso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(contenido_ingreso_paso obj)
        {
            try
            {
                return contenido_ingreso_paso.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(contenido_ingreso_paso obj)
        {
            try
            {
                contenido_ingreso_paso.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(contenido_ingreso_paso obj)
        {
            try
            {
                contenido_ingreso_paso.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

