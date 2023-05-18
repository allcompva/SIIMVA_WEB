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
    public class Ingresos_x_pasoService : IIngresos_x_pasoService
    {
        public ingresos_x_paso getByPk(int ID)
        {
            try
            {
                return ingresos_x_paso.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ingresos_x_paso> read(int idPaso)
        {
            try
            {
                return ingresos_x_paso.read(idPaso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(ingresos_x_paso obj)
        {
            try
            {
                return ingresos_x_paso.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(ingresos_x_paso obj)
        {
            try
            {
                ingresos_x_paso.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(ingresos_x_paso obj)
        {
            try
            {
                ingresos_x_paso.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

