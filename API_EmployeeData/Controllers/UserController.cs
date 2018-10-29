using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web.Http;
using API_EmployeeData.Models;

namespace API_EmployeeData.Controllers
{
    public class UserController : ApiController
    {
        private GetData data = new GetData();


        #region DEP

        [Route("getdeplist")]
        public ObservableCollection<Department> Get()
        {
            return data.GetListDep();
        }

        [Route("getdepid/{id}")]
        public Department Get(int id)
        {
            return data.GetDepartmentId(id);
        }

        [HttpPost]
        [Route("adddep")]
        public HttpResponseMessage PostAddDep([FromBody] Department value)
        {
            if (data.AddDepartment(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("deldep/{id}")]
        public bool DeleteDepartment(int id)
        {
            return data.DeleteDepartment(id);
        }

        #endregion

        #region EMP

        [HttpGet]
        [Route("getemplist")]
        public ObservableCollection<Employee> GetListEmp()
        {
            return data.GetListEmp();
        }

        [HttpPost]
        [Route("addemp")]
        public HttpResponseMessage PostAddEmp([FromBody] Employee value)
        {
            if (data.AddEmployee(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("delemp/{id}")]
        public bool DeleteEmployee(int id)
        {
            return data.DeleteEmployee(id);
        }

        [HttpPost]
        [Route("adddeptoemp")]
        public HttpResponseMessage PostAddDepToEmp([FromBody] Employee value)
        {
            if (data.AddDepToEmp(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("deldepfromemp")]
        public HttpResponseMessage DelDepFromEmp([FromBody] Employee value)
        {
            if (data.AddDepToEmp(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        #endregion

    }
}
