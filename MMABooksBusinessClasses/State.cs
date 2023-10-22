/* Author:  LindyStewart
 * Changes: Eric Robinson L00709820
 * Date:    10/17/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Define State object.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class State
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them

        // Default constructor
        public State() { }

        // Full constructor
        public State(string code, string name)
        {
            StateCode = code;
            StateName = name;
        }

        // this is an auto implemented property
        // it effectively creates a private instance variable
        // and creates "the usual" getter and setter
        // You can't use it when you're doing validation on a property
        public string StateName { get; set; }

        private string stateCode;
        public string StateCode { 
            get
            {
                return stateCode;
            }
            set
            {
                // this would normally be == 2 but there's some bad data in the database
                // I didn't realize that until I wrote the test for GetStates in StateDB
                if (value.Length <= 2)
                    stateCode = value.ToUpper();
                else
                    throw new ArgumentOutOfRangeException("The state code must be exactly 2 characters.");
            }
        } // end public string StateCode

        public override string ToString()
        {
            return StateCode + ", " + StateName;
        }
    } // end class State
} // end namespace MMABooksBusinessClasses
