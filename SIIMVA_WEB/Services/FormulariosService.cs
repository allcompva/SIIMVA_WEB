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
    public class FormulariosService : IFormulariosService
    {
        public Formularios getByPk(int id)
        {
            try
            {
                return Formularios.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Formularios getByIdPasos(int id_pasos)
        {
            try
            {
                return Formularios.getByIdPasos(id_pasos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Formularios> read()
        {
            try
            {
                return Formularios.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Formularios obj)
        {
            try
            {
                return Formularios.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Formularios obj)
        {
            try
            {
                Formularios.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Formularios obj)
        {
            try
            {
                Formularios.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

