﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.DAL.Data.Entities
{
    public  enum EntityStateEnum
    {
        Loaded = 0,

        New = 1,

        Updated = 2,

        Deleted = 3,

        Shallow = 4

    }
}
