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
    public class AdjuntoService : IAdjuntoService
    {
        public Adjunto getByPk(int ID)
        {
            try
            {
                return Adjunto.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Adjunto> read()
        {
            try
            {
                return Adjunto.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Adjunto obj)
        {
            try
            {
                return Adjunto.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Adjunto obj)
        {
            try
            {
                Adjunto.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Adjunto obj)
        {
            try
            {
                Adjunto.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

