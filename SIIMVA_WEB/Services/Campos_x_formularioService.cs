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
    public class Campos_x_formularioService : ICampos_x_formularioService
    {
        public campos_x_formulario getByPk(int ID)
        {
            try
            {
                return campos_x_formulario.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<campos_x_formulario> read(int idFormulario)
        {
            try
            {
                return campos_x_formulario.read(idFormulario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(campos_x_formulario obj)
        {
            try
            {
                return campos_x_formulario.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(campos_x_formulario obj)
        {
            try
            {
                campos_x_formulario.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(campos_x_formulario obj)
        {
            try
            {
                campos_x_formulario.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

