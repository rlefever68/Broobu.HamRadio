using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using Broobu.Contact.Contract.Agent;
using Broobu.Contact.Contract.Domain;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Contact.Contract.Test
{
    /// <summary>
    /// Class ContactTestFixture.
    /// </summary>
    [TestClass]
    public class ContactTestFixture
    {
        /// <summary>
        /// The namespace string
        /// </summary>
        private const string NamespaceString = "Pms.Contact.Contract.Domain.";


        /// <summary>
        /// Tries the generate media.
        /// </summary>
        [TestMethod]
        public void TryGenerateMedia()
        {
            
        }

        /// <summary>
        /// Tries the transaction scope.
        /// </summary>
        [TestMethod]
        public void TryTransactionScope()
        {
            int count;

            TryDeleteAllTestData();

            var countryItems = GetCountryItems();

            var documentItems = new List<DocumentItem>
                                                    {
                                                        GetDocumentItem(ContactTestFixtureData.Keys.Document[1]),
                                                        GetDocumentItem(ContactTestFixtureData.Keys.Document[2]),
                                                        GetDocumentItem(ContactTestFixtureData.Keys.Document[3])
                                                    };

            var addressItems = new List<AddressItem>
                                                 {
                                                     GetAddressItem(ContactTestFixtureData.Keys.Address[1]),
                                                     GetAddressItem(ContactTestFixtureData.Keys.Address[2]),
                                                     new AddressItem()
                                                 };
            try
            {

                var countryItemsSaved = new List<CountryItem>(countryItems.Count);

                count = countryItems.Count;
                for (var i = 0; i < count; i++)
                {
                    CountryItem countryItemSaved = ContactAgentFactory
                        .CreateCountryAgent()
                        .SaveCountryItem(countryItems[i]);
                    Debug.WriteLineIf(countryItemSaved.HasErrors, "Error saving countryitem " + (i + 1) + " / " + count + "\n\t" + countryItemSaved.Errors);
                    countryItemsSaved.Add(countryItemSaved);
                }

                using (var scope = new TransactionScope())
                {
                    var addressItemsSaved = new List<AddressItem>(addressItems.Count);
                    var documentItemsSaved = new List<DocumentItem>(documentItems.Count);

                    count = documentItems.Count;
                    for (var i = 0; i < count; i++)
                    {
                        DocumentItem documentItemSaved = ContactAgentFactory
                            .CreateDocumentAgent()
                            .SaveDocumentItem(documentItems[i]);
                        documentItemsSaved.Add(documentItemSaved);
                    }

                    count = addressItems.Count;
                    for (var i = 0; i < count; i++)
                    {
                        AddressItem addressItemSaved = ContactAgentFactory
                            .CreateAddressAgent()
                            .SaveAddressItem(addressItems[i]);
                        Debug.WriteLineIf(addressItemSaved.HasErrors, "Error saving AddressItem " + (i + 1) + " / " + count + "\n\tError = " + GetErrorString(addressItemSaved.Errors));
                        addressItemsSaved.Add(addressItemSaved);
                    }

                    bool succes = !(from i in documentItemsSaved where i.HasErrors select i).Any() & !(from i in addressItemsSaved where i.HasErrors select i).Any();

                    if (succes)
                    {
                        scope.Complete();
                        Debug.WriteLine("OK");
                    }
                    else
                    {
                        throw new ApplicationException(GetErrorString(addressItemsSaved.ToArray()) + GetErrorString(documentItemsSaved.ToArray()));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error(s) occured.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Tries the delete all test data.
        /// </summary>
        [TestMethod]
        public void TryDeleteAllTestData()
        {
            /*
             * Delete in following order:
             * ==========================
             * 1. Delete Contact.RelationAddress
             * 2. Delete Contact.RelationDocument
             * 3. Delete Contact.Relation
             * 4. Delete Contact.[Address]
             * 5. Delete Contact.Document
             * 6. Delete Contact.Country
             */



            foreach (string id in ContactTestFixtureData.Keys.RelationAddress.Values)
            {
                Result item =  ContactAgentFactory
                    .CreateContactAgent()
                    .DeleteRelationAddressItem(id);
                ErrorStringDelete(item, "RelationAddressItem", id);
            }

            foreach (string id in ContactTestFixtureData.Keys.RelationDocument.Values)
            {
                Result item = agent.DeleteRelationDocumentItem(id);
                ErrorStringDelete(item, "RelationDocumentItem", id);
            }

            foreach (string id in ContactTestFixtureData.Keys.Relation.Values)
            {
                Result item = agent.DeleteRelationItem(id);
                ErrorStringDelete(item, "RelationItem", id);
            }

            foreach (string id in ContactTestFixtureData.Keys.Address.Values)
            {
                Result item = agent.DeleteAddressItem(id);
                ErrorStringDelete(item, "AddressItem", id);
            }

            foreach (string id in ContactTestFixtureData.Keys.Document.Values)
            {
                Result item = agent.DeleteDocumentItem(id);
                ErrorStringDelete(item, "DocumentItem", id);
            }

            foreach (string id in ContactTestFixtureData.Keys.Country.Values)
            {
                Result item = agent.DeleteCountryItem(id);
                ErrorStringDelete(item, "CountryItem", id);
            }
        }

        /// <summary>
        /// Tries the get relation addresses.
        /// </summary>
        [TestMethod]
        public void TryGetRelationAddresses()
        {
            IContactAgent agent = ContactAgentFactory.CreateContactAgent();

            List<DocumentItem> documentItemsSaved;
            List<AddressItem> addressItemsSaved;
            RelationItem relationItemSaved;
            List<RelationAddressItem> relationAddressItemsSaved;
            List<RelationDocumentItem> relationDocumentItemsSaved;
            List<CountryItem> countryItemsSaved;
            AddressItem[] addressItems;
            int count = 0;

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    Debug.WriteLine("Creating all objects on " + DateTime.Now);
                    List<AddressItem> addressItemsNew                        = GetAddressItems(2);
                    List<CountryItem> countryItemsNew                        = GetCountryItems(2);
                    List<DocumentItem> documentItemsNew                      = GetDocumentItems(2);
                    RelationItem relationItemNew                             = GetRelationItem();
                    List<RelationAddressItem> relationAddressItemsNew        = GetRelationAddressItems(2);
                    List<RelationDocumentItem> relationDocumentItemsNew      = GetRelationDocumentItems(2);

                    Debug.WriteLine("All objects in memory on {0}", DateTime.Now);

                    Debug.WriteLine("Saving all objects");

                    count = countryItemsNew.Count;
                    countryItemsSaved = new List<CountryItem>(count);
                    Debug.WriteLine("Saving countries objects");
                    for (int i = 0; i < count; i++)
                    {
                        CountryItem countryItemSaved = agent.SaveCountryItem(countryItemsNew[i]);
                        Debug.WriteLine("CountryItem {0} / {1} saved {2}on {3}", (i + 1), count, (countryItemSaved.HasErrors ? "with errors " : ""), DateTime.Now);
                        countryItemsSaved.Add(countryItemSaved);
                    }

                    count = documentItemsNew.Count;
                    documentItemsSaved = new List<DocumentItem>(count);
                    Debug.WriteLine("Saving documents objects");
                    for (int i = 0; i < count; i++)
                    {
                        DocumentItem documentItemSaved = agent.SaveDocumentItem(documentItemsNew[i]);
                        Debug.WriteLine("DocumentItem {0} / {1} saved {2}on {3}", (i + 1), count, (documentItemSaved.HasErrors ? "with errors " : ""), DateTime.Now);
                        documentItemsSaved.Add(documentItemSaved);
                    }

                    relationItemSaved = agent.SaveRelationItem(relationItemNew);
                    Debug.WriteLine("AddressItem saved {0}on {1}", (relationItemSaved.HasErrors ? "with errors " : ""), DateTime.Now);

                    count = addressItemsNew.Count;
                    addressItemsSaved = new List<AddressItem>(count);
                    Debug.WriteLine("Saving addresses objects");
                    for (int i = 0; i < count; i++)
                    {
                        AddressItem addressItemSaved = agent.SaveAddressItem(addressItemsNew[i]);
                        Debug.WriteLine("CountryItem {0} / {1} saved {2}on {3}", (i + 1), count, (addressItemSaved.HasErrors ? "with errors " : ""), DateTime.Now);
                        addressItemsSaved.Add(addressItemSaved);
                    }

                    count = relationAddressItemsNew.Count;
                    relationAddressItemsSaved = new List<RelationAddressItem>(count);
                    Debug.WriteLine("Saving RelationAddress objects");
                    for (int i = 0; i < count; i++)
                    {
                        RelationAddressItem relationAddressItemSaved = agent.SaveRelationAddressItem(relationAddressItemsNew[i]);
                        Debug.WriteLine("RelationAddressItem {0} / {1} saved {2}on {3}", (i + 1), count, (relationAddressItemSaved.HasErrors ? "with errors " : ""), DateTime.Now);
                        relationAddressItemsSaved.Add(relationAddressItemSaved);
                    }

                    count = relationDocumentItemsNew.Count;
                    relationDocumentItemsSaved = new List<RelationDocumentItem>(count);
                    Debug.WriteLine("Saving RelationDocument objects");
                    for (int i = 0; i < count; i++)
                    {
                        RelationDocumentItem relationDocumentItemSaved = agent.SaveRelationDocumentItem(relationDocumentItemsNew[i]);
                        Debug.WriteLine("RelationDocumentItem {0} / {1} saved {2}on {3}", (i + 1), count, (relationDocumentItemSaved.HasErrors ? "with errors " : ""), DateTime.Now);
                        relationDocumentItemsSaved.Add(relationDocumentItemSaved);
                    }

                    Debug.WriteLine("All objects saved");

                    Debug.WriteLine("Before commiting transaction");
                    scope.Complete();
                    Debug.WriteLine("Commit transaction completed");
                }
                addressItems = agent.GetAddressItemsForRelation(ContactTestFixtureData.Keys.Relation[1]);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error(s) occured\n" + e.Message);
            }
        }

        #region Address methods
        /// <summary>
        /// Gets the address item.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.AddressItem.</returns>
        [Ignore]
        private AddressItem GetAddressItem()
        {
            return GetAddressItem(ContactTestFixtureData.Keys.Address[1]);
        }

        /// <summary>
        /// Gets the address item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.AddressItem.</returns>
        [Ignore]
        private AddressItem GetAddressItem(string id)
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetAddressItem(id);
        }

        /// <summary>
        /// Gets the address items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>System.Collections.Generic.List{Broobu.Contact.Contract.Domain.AddressItem}.</returns>
        [Ignore]
        private List<AddressItem> GetAddressItems(int count, bool includeNullGuid = false)
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetAddressItems(count, includeNullGuid).ToList();
        }

        /// <summary>
        /// Gets the addresses for relation.
        /// </summary>
        /// <returns>System.Collections.Generic.List{Broobu.Contact.Contract.Domain.AddressItem}.</returns>
        [Ignore]
        private List<AddressItem> GetAddressesForRelation()
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetAddressItemsForRelation(ContactTestFixtureData.Keys.RelationAddress[1]).ToList();
        }
        #endregion

        #region Country methods

        /// <summary>
        /// Gets the country item.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem.</returns>
        [Ignore]
        private CountryItem GetCountryItem()
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetCountryItem(ContactTestFixtureData.Keys.Country[1]);
        }

        /// <summary>
        /// Gets the country items.
        /// </summary>
        /// <returns>System.Collections.Generic.List{Broobu.Contact.Contract.Domain.CountryItem}.</returns>
        [Ignore]
        private List<CountryItem> GetCountryItems()
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetCountryItems().ToList();
        }

        /// <summary>
        /// Gets the country items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>System.Collections.Generic.List{Broobu.Contact.Contract.Domain.CountryItem}.</returns>
        [Ignore]
        private List<CountryItem> GetCountryItems(int count, bool includeNullGuid = false)
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetCountryItems(count, includeNullGuid).ToList();
        }
        #endregion

        #region Document methods
        /// <summary>
        /// Gets the document item.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem.</returns>
        [Ignore]
        private DocumentItem GetDocumentItem()
        {
            return GetDocumentItem(ContactTestFixtureData.Keys.Document[1]);
        }

        /// <summary>
        /// Gets the document item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem.</returns>
        [Ignore]
        private DocumentItem GetDocumentItem(string id)
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetDocumentItem(id);
        }

        /// <summary>
        /// Gets the document items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>System.Collections.Generic.List{Broobu.Contact.Contract.Domain.DocumentItem}.</returns>
        [Ignore]
        private List<DocumentItem> GetDocumentItems(int count, bool includeNullGuid = false)
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetDocumentItems(count, includeNullGuid).ToList();
        }
        #endregion

        #region Relation
        /// <summary>
        /// Gets the relation item.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.RelationItem.</returns>
        [Ignore]
        private RelationItem GetRelationItem()
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetRelationItem(ContactTestFixtureData.Keys.Relation[1]);
        }
        #endregion

        #region RelationAddress
        /// <summary>
        /// Gets the relation address item.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.RelationAddressItem.</returns>
        [Ignore]
        private RelationAddressItem GetRelationAddressItem()
        {
            return GetRelationAddressItem(ContactTestFixtureData.Keys.RelationAddress[1]);
        }

        /// <summary>
        /// Gets the relation address item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationAddressItem.</returns>
        [Ignore]
        private RelationAddressItem GetRelationAddressItem(string id)
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetRelationAddressItem(id);
        }

        /// <summary>
        /// Gets the relation address items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>System.Collections.Generic.List{Broobu.Contact.Contract.Domain.RelationAddressItem}.</returns>
        [Ignore]
        private List<RelationAddressItem> GetRelationAddressItems(int count, bool includeNullGuid = false)
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetRelationAddressItems(count, includeNullGuid).ToList();
        }

        #endregion

        #region RelationDocument methods
        /// <summary>
        /// Gets the relation document item.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.RelationDocumentItem.</returns>
        private RelationDocumentItem GetRelationDocumentItem()
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetRelationDocumentItem(ContactTestFixtureData.Keys.RelationDocument[1]);
        }

        /// <summary>
        /// Gets the relation document items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>System.Collections.Generic.List{Broobu.Contact.Contract.Domain.RelationDocumentItem}.</returns>
        [Ignore]
        private List<RelationDocumentItem> GetRelationDocumentItems(int count, bool includeNullGuid = false)
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetRelationDocumentItems(count, includeNullGuid).ToList();
        }

        /// <summary>
        /// Gets all relation document items.
        /// </summary>
        /// <returns>System.Collections.Generic.List{Broobu.Contact.Contract.Domain.RelationDocumentItem}.</returns>
        [Ignore]
        private List<RelationDocumentItem> GetAllRelationDocumentItems()
        {
            ContactTestFixtureData testdata = new ContactTestFixtureData();
            return testdata.GetRelationDocumentItems().ToList();
        }
        #endregion

        /// <summary>
        /// Gets the error string.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>System.String.</returns>
        [Ignore]
        private string GetErrorString(object[] o)
        {
            int counter = 0;
            string errors = String.Empty;
            switch (o.GetType().ToString())
            {
                case (NamespaceString + "AddressItem[]"):
                    AddressItem[] addressItems = (AddressItem[])o;
                    foreach (AddressItem addressItem in addressItems)
                    {
                        if (addressItem.HasErrors)
                            errors += "AddressItem[" + counter + "] = " + GetErrorStrings(addressItem.Errors) + "\n";
                        counter++;
                    }
                    break;
                case (NamespaceString + "CountryItem[]"):
                    CountryItem[] countryItems = (CountryItem[])o;
                    foreach (CountryItem countryItem in countryItems)
                    {
                        if (countryItem.HasErrors)
                            errors += "CountryItem[" + counter + "] = " + GetErrorStrings(countryItem.Errors) + "\n";
                        counter++;
                    }
                    break;
                case (NamespaceString + "DocumentItem[]"):
                    DocumentItem[] documentItems = (DocumentItem[])o;
                    foreach (DocumentItem documentItem in documentItems)
                    {
                        if (documentItem.HasErrors)
                            errors += "DocumentItem[" + counter + "] = " + GetErrorStrings(documentItem.Errors) + "\n";
                        counter++;
                    }
                    break;
                case (NamespaceString + "RelationAddressItem[]"):
                    RelationAddressItem[] relationAddressItems = (RelationAddressItem[])o;
                    foreach (RelationAddressItem relationAddressItem in relationAddressItems)
                    {
                        if (relationAddressItem.HasErrors)
                            errors += "RelationAddressItem[" + counter + "] = " + GetErrorStrings(relationAddressItem.Errors) + "\n";
                        counter++;
                    }
                    break;
                case (NamespaceString + "RelationItem[]"):
                    RelationItem[] relationItems = (RelationItem[])o;
                    foreach (RelationItem relationItem in relationItems)
                    {
                        if (relationItem.HasErrors)
                            errors += "RelationItem[" + counter + "] = " + GetErrorStrings(relationItem.Errors) + "\n";
                        counter++;
                    }
                    break;
            }
            return errors;
        }

        /// <summary>
        /// Gets the error strings.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>System.String.</returns>
        [Ignore]
        private string GetErrorStrings(IEnumerable<string> error)
        {
            if (error.Count() == 0)
                return String.Empty;
            var output = error.Aggregate(String.Empty, (current, s) => current + (", " + s));
            return output.Substring(2);
        }

        /// <summary>
        /// Errors the string delete.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        [Ignore]
        private void ErrorStringDelete(object o, string entity = "", string id = "")
        {
            var r = (Result)o;
            if (o == null)
            {
                Debug.WriteLine(entity + " with Id = '" + id + "' not found.");
            }
            else
            {
                entity = r.GetType().ToString().Substring(NamespaceString.Length);
                Debug.WriteLine(r.HasErrors
                                    ? String.Format("Error deleting {0} with Id = '{1}'.", entity, id)
                                    : String.Format("{0} with Id = '{1}' deleted.", entity, id));
            }
        }
    }
}
