﻿using Repositories.DataBaseConnection;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class RepositoryTarefa: IRespositoryTarefa
    {
        private ApiContext _context;
    }
}
