﻿using System;

namespace Domain.Common
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
