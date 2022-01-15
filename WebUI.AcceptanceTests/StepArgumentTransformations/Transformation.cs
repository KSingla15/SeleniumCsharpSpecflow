using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebUI.Domain.Models;

namespace WebUI.AcceptanceTests.StepArgumentTransformations
{
    [Binding]
    public class Transformation
    {
        [StepArgumentTransformation]
        public Numbers NumbersTransform(Table numbersTable)
        {
            return numbersTable.CreateInstance<Numbers>();
        }

        [StepArgumentTransformation]
        public UserRegistrationEntity UserRegistrationEntityTransform(Table userRegistrationDetails)
        {
            return userRegistrationDetails.CreateInstance<UserRegistrationEntity>();
        }
    }
}
