﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById
{
    public class AdminUserByIdVm
    {
        public Guid User_ID { get; set; }
        public string User_Name { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public bool Status { get; set; }
    }
}
