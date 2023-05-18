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
    public class PasosService : IPasosService
    {
        public Pasos getByPk(int id)
        {
            try
            {
                return Pasos.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Pasos> read(int id_tramites)
        {
            try
            {
                return Pasos.read(id_tramites);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Pasos obj)
        {
            try
            {
                return Pasos.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Pasos obj)
        {
            try
            {
                Pasos.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Pasos obj)
        {
            try
            {
                Pasos.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

