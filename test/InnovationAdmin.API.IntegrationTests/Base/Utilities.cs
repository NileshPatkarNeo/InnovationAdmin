﻿using InnovationAdmin.Domain.Entities;
using InnovationAdmin.Persistence;
using System;

namespace InnovationAdmin.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext context)
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

           

            context.SaveChanges();
        }
    }
}
