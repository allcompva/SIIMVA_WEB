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
    public class Ws_contenido_campo_formularioService : IWs_contenido_campo_formularioService
    {
        public Ws_contenido_campo_formulario getByPk()
        {
            try
            {
                return Ws_contenido_campo_formulario.getByPk();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ws_contenido_campo_formulario> read()
        {
            try
            {
                return Ws_contenido_campo_formulario.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ws_contenido_campo_formulario obj)
        {
            try
            {
                return Ws_contenido_campo_formulario.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ws_contenido_campo_formulario obj)
        {
            try
            {
                Ws_contenido_campo_formulario.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ws_contenido_campo_formulario obj)
        {
            try
            {
                Ws_contenido_campo_formulario.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

