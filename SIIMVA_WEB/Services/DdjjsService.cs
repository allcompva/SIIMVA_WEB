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
    public class DdjjsService : IDdjjsService
    {
        public Ddjjs getByPk(int id)
        {
            try
            {
                return Ddjjs.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Ddjjs getByIdPasos(int id_pasos)
        {
            try
            {
                return Ddjjs.getByIdPasos(id_pasos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ddjjs> read()
        {
            try
            {
                return Ddjjs.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ddjjs obj)
        {
            try
            {
                return Ddjjs.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ddjjs obj)
        {
            try
            {
                Ddjjs.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ddjjs obj)
        {
            try
            {
                Ddjjs.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

