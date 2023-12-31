﻿using ProjekatASP.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.Queries
{
    public interface IAuditLogsQuery : IQuery<AuditLogsSearchDto, PagedResponse<AuditLogsDto>>
    {
    }
}
