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
    public class FormularioService : IFormularioService
    {
        public Formulario getByPk(int ID)
        {
            try
            {
                return Formulario.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Formulario> read()
        {
            try
            {
                return Formulario.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Formulario obj)
        {
            try
            {
                return Formulario.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Formulario obj)
        {
            try
            {
                Formulario.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Formulario obj)
        {
            try
            {
                Formulario.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

