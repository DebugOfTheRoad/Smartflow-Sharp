﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
namespace Smartflow.Design
{
    internal class WorkflowDesignService : IWorkflowDesignService
    {
        protected IDbConnection Connection
        {
            get { return DapperFactory.CreateWorkflowConnection(); }
        }

        public void Persistent(WorkflowXml workflowXml)
        {
            string sql = "INSERT INTO T_FLOWXML(WFID,NAME,XML,IMAGE)  VALUES(@WFID,@NAME,@XML,@IMAGE)";
            Connection.Execute(sql, workflowXml);
        }

        public void Update(WorkflowXml workflowXml)
        {
            string sql = " UPDATE T_FLOWXML SET NAME=@NAME,XML=@XML,IMAGE=@IMAGE WHERE WFID=@WFID ";
            Connection.Execute(sql, workflowXml);
        }
    }
}