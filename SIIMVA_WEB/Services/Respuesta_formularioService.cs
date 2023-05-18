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
    public class Respuesta_formularioService : IRespuesta_formularioService
    {
        public Respuesta_formulario getByPk()
        {
            try
            {
                return Respuesta_formulario.getByPk();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Respuesta_formulario> read(int id_formularios)
        {
            try
            {
                return Respuesta_formulario.read(id_formularios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Respuesta_formulario obj)
        {
            try
            {
                return Respuesta_formulario.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Respuesta_formulario obj)
        {
            try
            {
                Respuesta_formulario.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Respuesta_formulario obj)
        {
            try
            {
                Respuesta_formulario.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

