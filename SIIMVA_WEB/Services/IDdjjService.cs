using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOTOR_WORKFLOW.Entities;

namespace MOTOR_WORKFLOW.Services
{
    public interface IDdjjService
    {
        public List<ddjj> read();
        public ddjj getByPk(int ID);
        public int insert(ddjj obj);
        public void update(ddjj obj);
        public void delete(ddjj obj);
    }
}

