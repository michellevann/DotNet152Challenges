﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim (int claimId, string claimType, string description, decimal claimAmount, 
            string dateOfIncident, string dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public Claim()
        {
        }
    }
}
