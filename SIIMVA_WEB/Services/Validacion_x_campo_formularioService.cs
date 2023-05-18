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
    public class Validacion_x_campo_formularioService : IValidacion_x_campo_formularioService
    {
        public Validacion_x_campo_formulario getByPk(int ID)
        {
            try
            {
                return Validacion_x_campo_formulario.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Validacion_x_campo_formulario> read()
        {
            try
            {
                return Validacion_x_campo_formulario.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Validacion_x_campo_formulario obj)
        {
            try
            {
                return Validacion_x_campo_formulario.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Validacion_x_campo_formulario obj)
        {
            try
            {
                Validacion_x_campo_formulario.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Validacion_x_campo_formulario obj)
        {
            try
            {
                Validacion_x_campo_formulario.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

