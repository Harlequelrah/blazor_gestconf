﻿using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class Administrator : User
    {
        private readonly IAdministratorService _administratorService;

        // public Administrator(IAdministratorService administratorService) : base()
        // {
        //     _administratorService = administratorService;
        // }
        public Administrator() : base()
        {
        }
    }
}
