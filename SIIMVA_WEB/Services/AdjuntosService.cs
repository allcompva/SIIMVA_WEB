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
    public class AdjuntosService : IAdjuntosService
    {
        public Adjuntos getByPk(int id)
        {
            try
            {
                return Adjuntos.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Adjuntos getByIdPasos(int id_pasos)
        {
            try
            {
                return Adjuntos.getByIdPasos(id_pasos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Adjuntos> read()
        {
            try
            {
                return Adjuntos.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Adjuntos obj)
        {
            try
            {
                return Adjuntos.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Adjuntos obj)
        {
            try
            {
                Adjuntos.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Adjuntos obj)
        {
            try
            {
                Adjuntos.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

