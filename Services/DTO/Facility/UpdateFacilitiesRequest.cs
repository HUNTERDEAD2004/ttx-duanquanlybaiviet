﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Facility
{
    public class UpdateFacilitiesRequest
    {
        public int FacilityId { get; set; }

        public string Name { get; set; }
    }
}
