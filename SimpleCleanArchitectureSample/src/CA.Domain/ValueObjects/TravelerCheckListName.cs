﻿using CA.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.ValueObjects
{
    public record TravelerCheckListName
    {
        public string Value { get; }

        public TravelerCheckListName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new TravelerCheckListNameException();
            }

            Value = value.Trim();
        }


        public static implicit operator string(TravelerCheckListName name)
            => name.Value;

        public static implicit operator TravelerCheckListName(string name)
            => new(name);
    }
}
