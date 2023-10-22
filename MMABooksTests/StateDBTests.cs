/* Author:  Eric Robinson L00709820
 * Date:    10/16/ 23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Test the StateDB class
 */

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

using MySql.Data.MySqlClient;

namespace MMABooksTests
{
    [TestFixture]
    public class StateDBTests
    {
        private State state;

        [SetUp]
        // This method gets called before EVERY test to recreate the state object.
        public void SetUp()
        {
            state = new State("NY", "New York"); 
        }

        [Test]
        public void TestGetStates()
        {
            List<State> states = StateDB.GetStates();
            Assert.AreEqual(53, states.Count);
            Assert.AreEqual("Alabama", states[0].StateName);
        }

        [Test]
        public void TestGetStatesDBUnavailable()
        {
            // Test that you get an error if unable to connect to database.
            // See 29:20 on the StateDB and CustomerDBClasses Video Part 1 (#5).
            Assert.Throws<MySqlException>(() => StateDB.GetStates());
        }

        [Test]
        public void TestStateConstructor()
        {
            State stateNull = new State(); 
            Assert.IsNotNull(stateNull);
            Assert.AreEqual(null, stateNull.StateCode);
            Assert.AreEqual(null, stateNull.StateName);

            // SetUp();
            string newCode = "NY";
            string newName = "New York";
            // State state1 = new State(newCode, newName);
            Assert.IsNotNull(state);
            Assert.AreEqual(newCode, state.StateCode);
            Assert.AreEqual(newName, state.StateName);
        }
        [Test]
        public void TestStateSettersOR()
        {
            // State state1 = new State("NY", "New York"); // This line can be replaced by using [SetUp].
            string newCode = "OR";
            string newName = "Oregon";
            // Call the setters.
            state.StateCode = newCode;
            state.StateName = newName;
            // Assert that the property returns the expected values.
            Assert.AreEqual(newCode, state.StateCode);
            Assert.AreEqual(newName, state.StateName);
        }

        [Test]
        public void TestStateSettersWA()
        {
            State state1 = new State("WA", "Washington"); 
            string newCode = "WA";
            string newName = "Washington";
            // Call the setters.
            state1.StateCode = newCode;
            state1.StateName = newName;
            // Assert that the property returns the values.
            Assert.AreEqual(newCode, state1.StateCode);
            Assert.AreEqual(newName, state1.StateName);
        }

        [Test]
        // This test seems to duplicate TestStateSettersOR and TestStateSettersWA.
        public void TestStateToString()
        {
            Assert.IsTrue(state.ToString().Contains("NY"));
            Assert.IsTrue(state.ToString().Contains("New York"));
        }

        [Test]
        public void TestSettersWithInvalidStateCode()
        {
            try
            {
                // State codes must be <= 2 chars so we will test a 3 char code.
                state.StateCode = "abc"; 
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

        [Test]
        public void TestStateGetters()
        {
            // We don't actually need a separate test here.
            // The 2 TestStateSettersXX won't pass if the StateGetters did not work correctly.
        }

    } // end public class StateDBTests
} // end namespace MMABooksTests
