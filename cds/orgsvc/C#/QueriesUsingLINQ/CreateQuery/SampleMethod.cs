using Microsoft.Xrm.Tooling.Connector;
using System;

namespace PowerApps.Samples
{
    public partial class CreateALinqQuery
    {
        private static bool prompt = true;
        /// <summary>
        /// Function to set up the sample.
        /// </summary>
        /// <param name="service">Specifies the service to connect to.</param>
        /// 
        private static void SetUpSample(CrmServiceClient service)
        {
            // Check that the current version is greater than the minimum version
            if (!SampleHelpers.CheckVersion(service, new Version("9.0.0.0")))
            {
                //The environment version is lower than version 9.0.0.0
                return;
            }

            CreateRequiredRecords(service);
        }

        private static void CleanUpSample(CrmServiceClient service)
        {
            DeleteRequiredRecords(service, prompt);
        }

        /// <summary>
        /// This method creates any entity records that this sample requires.
        /// Creates the email activity.
        /// </summary>
        public static void CreateRequiredRecords(CrmServiceClient service)
        {
            // Create 5 Accounts and 5 Contacts for the LINQ samples.
            Account account = new Account
            {
                Name = "Fourth Coffee",
                Address1_StateOrProvince = "Colorado",
            };
            _recordIds.Add(service.Create(account), Account.EntityLogicalName);
            account = new Account
            {
                Name = "School of Fine Art",
                Address1_StateOrProvince = "Illinois",
                Address1_County = "Lake County"
            };
            _recordIds.Add(service.Create(account), Account.EntityLogicalName);
            account = new Account
            {
                Name = "Tailspin Toys",
                Address1_StateOrProvince = "Washington",
                Address1_County = "King County",
            };
            _recordIds.Add(service.Create(account), Account.EntityLogicalName);
            account = new Account
            {
                Name = "Woodgrove Bank",
                Address1_StateOrProvince = "Washington"
            };
            _recordIds.Add(service.Create(account), Account.EntityLogicalName);
            account = new Account
            {
                Name = "Contoso, Ltd.",
                Address1_County = "Saint Louis County"
            };
            _recordIds.Add(service.Create(account), Account.EntityLogicalName);

            Contact contact = new Contact
            {
                FirstName = "Joe",
                Address1_City = "Redmond",
            };
            _recordIds.Add(service.Create(contact), Contact.EntityLogicalName);
            contact = new Contact
            {
                FirstName = "John",
                Address1_City = "Redmond",
            };
            _recordIds.Add(service.Create(contact), Contact.EntityLogicalName);
            contact = new Contact
            {
                FirstName = "John",
                Address1_City = "Cleveland",
            };
            _recordIds.Add(service.Create(contact), Contact.EntityLogicalName);
            contact = new Contact
            {
                FirstName = "Joe",
                Address1_City = "Redmond",
            };
            _recordIds.Add(service.Create(contact), Contact.EntityLogicalName);
            contact = new Contact
            {
                FirstName = "Jim",
                Address1_City = "Redmond",
            };
            _recordIds.Add(service.Create(contact), Contact.EntityLogicalName);

            Console.WriteLine("Required records have been created.\n");
        }


        /// <summary>
        /// Deletes the custom entity record that was created for this sample.
        /// <param name="prompt">Indicates whether to prompt the user 
        /// to delete the entity created in this sample.</param>
        /// </summary>
        public static void DeleteRequiredRecords(CrmServiceClient service, bool prompt)
        {
            bool deleteRecords = true;

            if (prompt)
            {
                Console.WriteLine("\nDo you want these entity records deleted? (y/n)");
                String answer = Console.ReadLine();

                deleteRecords = (answer.StartsWith("y") || answer.StartsWith("Y"));
            }

            if (deleteRecords)
            {
                foreach (var record in _recordIds)
                {
                    service.Delete(record.Value, record.Key);
                }
                Console.WriteLine("Entity records have been deleted.");
            }
        }

    }
}
