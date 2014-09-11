using System;
using System.Collections.Generic;
using System.Linq;
using Broobu.Contact.Contract.Domain;

namespace Broobu.Contact.Contract.Test
{
    /// <summary>
    /// Class ContactTestFixtureData.
    /// </summary>
    public class ContactTestFixtureData
    {
        /// <summary>
        /// Class Keys.
        /// </summary>
        public class Keys
        {   // RelationAddressType  => 1 = Domicilie, 2 = Leveradres, 3 = Facturatieadres
            // Gender               => 1 = Male, 2 = Female, 3 = Unknown
            // Country              => 1 = Duitsland, 2 = U.S., 3 = Frankrijk, 4 = Nederland, 5 = U.K., 6 = Luxemburg, 7 = België
            // State                => 6 = Limburg
            /// <summary>
            /// The null unique identifier
            /// </summary>
            public const string NullGuid                                     = "00000000-0000-0000-0000-000000000000";
            /// <summary>
            /// The address
            /// </summary>
            public static Dictionary<int, string> Address                    = new Dictionary<int, string> { { 0, NullGuid }, { 1, "8626B696-5660-4F15-A79F-4F727ACFF6F2" }, { 2, "1930DE25-1084-4738-B736-BA1BA75CCDE3" }, { 3, "BBB612EE-9237-4CD6-8EBB-22E4697754AB" }, { 4, "E3FA320A-7811-424A-9BB5-3DAB15346331" }, { 5, "474B7D9B-4F11-448F-91F2-D7111BE2BF78" }, { 6, "4BC05C90-0599-4C08-8123-630506ED89A4" }, { 7, "631A0E1E-A2EF-4C57-9E5A-912EE6FC2556" }, { 8, "E9F952DB-501A-4563-9937-9206A01A1C56" } };
            /// <summary>
            /// The address type
            /// </summary>
            public static Dictionary<int, string> AddressType                = new Dictionary<int, string> { { 0, NullGuid }, { 1, "7A6EC411-3A66-49D8-8ABC-17A4EA0A5529" }, { 2, "7A6EC411-3A66-49D8-8ABC-17A4EA0A5529" }, { 3, "7A6EC411-3A66-49D8-8ABC-17A4EA0A5529" } };
            /// <summary>
            /// The country
            /// </summary>
            public static Dictionary<int, string> Country                    = new Dictionary<int, string> { { 0, NullGuid }, { 1, "A5DDA65E-1EDD-4C76-802E-07741BC71999" }, { 2, "BD7CEEB9-7A51-4565-98A3-E6C71D41D2D2" }, { 3, "2B56D0F2-BD41-43EC-BB6E-9A0B21D877C7" }, { 4, "AEE7333D-FB6C-40E8-92D4-ECF6B2E857B3" }, { 5, "62FAED48-2C33-4DC4-A707-61A670CB0593" }, { 6, "DF6A7297-8789-4C68-AD5A-A8AAE8B5986A" }, { 7, "C010D202-D15A-48D2-8887-6AF18009207B" } };
            /// <summary>
            /// The document
            /// </summary>
            public static Dictionary<int, string> Document                   = new Dictionary<int, string> { { 0, NullGuid }, { 1, "3FCB3819-949E-4CE3-8E36-C9DEA0CA85A7" }, { 2, "36B95086-4A65-4D1E-BECD-578957A2266F" }, { 3, "05898722-F4A4-4542-B249-70309E9061BA" }, { 4, "CC21A9D1-8CAB-4DD2-8DBD-03991E66CA3C" }, { 5, "17CC2F67-0DBF-42AC-B653-A91BA37F2672" }, { 6, "6262A024-FCE9-4CA2-A372-C7EE14491BBD" } };
            /// <summary>
            /// The document type
            /// </summary>
            public static Dictionary<int, string> DocumentType               = new Dictionary<int, string> { { 0, NullGuid }, { 1, "D1AB411B-390A-4BBA-BB35-C94BEE6A4608" }, { 2, "1864611E-9A90-427B-B424-9291259B839A" }, { 3, "7CF839B0-20AA-4190-924D-C2A7B21C3C19" } };
            /// <summary>
            /// The gender
            /// </summary>
            public static Dictionary<int, string> Gender                     = new Dictionary<int, string> { { 0, NullGuid }, { 1, "CBAC0615-407A-407A-97D5-747036553766" }, { 2, "A5599B56-C894-4201-A899-2000D0EC2BAB" }, { 3, "1C244A44-5F59-4E73-93CA-22D3671499B4" } };
            /// <summary>
            /// The relation
            /// </summary>
            public static Dictionary<int, string> Relation                   = new Dictionary<int, string> { { 0, NullGuid }, { 1, "3676D335-B0CF-4D48-8AF5-1EACC4486A76" }, { 2, "57950E51-FED4-4C6E-AC16-32C8735B5CB9" }, { 3, "7917C199-B594-4C43-B28B-9397AEA5B0ED" }, { 4, "509CA1DB-C4A9-41D3-AFFB-0C8ADFDC60DA" }, { 5, "175E1155-54FA-4D71-A894-A2BA730DD96A" }, { 6, "C359C690-10E3-4ABC-88FE-C8D7F687D617" } };
            /// <summary>
            /// The relation address
            /// </summary>
            public static Dictionary<int, string> RelationAddress            = new Dictionary<int, string> { { 0, NullGuid }, { 1, "DC4C623E-4EF7-4F0F-AA36-D3ED1712DEBF" }, { 2, "41EF7248-D2E2-41F1-9B12-B48FAC97E94C" }, { 3, "29864537-2C98-44FB-B05F-622B74DD1D23" }, { 4, "F0D2F1BE-58F5-4784-9E64-630898E36C6F" }, { 5, "05FC3E0B-FBE0-490E-A83B-FC92C9A12DE4" }, { 6, "FD20F489-6436-439F-BE4A-9F2FAB6FFB5A" }, { 7, "6E1D49E8-8F6E-46A2-AD8A-E884D7948087" } };
            /// <summary>
            /// The relation address type
            /// </summary>
            public static Dictionary<int, string> RelationAddressType        = new Dictionary<int, string> { { 0, NullGuid }, { 1, "B855E04F-E5FB-40C6-8B7C-08FC74957ABF" }, { 2, "FF189DE0-E30B-4E24-A9C0-E689CB23E2D2" }, { 3, "3D09186F-05B7-4874-B2FE-D7B67DA2E374" } };
            /// <summary>
            /// The relation document
            /// </summary>
            public static Dictionary<int, string> RelationDocument           = new Dictionary<int, string> { { 0, NullGuid }, { 1, "9D55D09F-7863-4FF9-814B-B39F48C33C3C" }, { 2, "806A81A2-6CB6-4BE8-B56B-E87274EE2855" }, { 3, "9F7865CC-F858-4A11-A595-A27221D44A83" }, { 4, "2A001BAC-7D28-4705-8E66-84636F84FA64" }, { 5, "58B06BF3-817A-4EA7-9FE8-84E5F98A381C" }, { 6, "990DFA12-549F-4E73-B9BA-D11E53C6E727" }, { 7, "1D384C1B-3EB7-4C28-936E-F18568859E46" } };
            /// <summary>
            /// The relation document type
            /// </summary>
            public static Dictionary<int, string> RelationDocumentType       = new Dictionary<int, string> { { 0, NullGuid }, { 1, "F21240D5-1179-4F32-9E94-9EF9481C802D" }, { 2, "3AFDCE29-6FF7-4133-8B51-7CB160575094" }, { 3, "3B39AE45-AAD6-477F-87C1-84E83D35B144" } };
            /// <summary>
            /// The relation type
            /// </summary>
            public static Dictionary<int, string> RelationType               = new Dictionary<int, string> { { 0, NullGuid }, { 1, "ED4EF867-FE4B-44E7-8B10-FF1A280D80A7" }, { 2, "9571A201-394E-4293-ABBF-89A39532A57D" }, { 3, "6F4194BE-5A0C-40CA-B6E6-F93C7E454691" } };
            /// <summary>
            /// The state
            /// </summary>
            public static Dictionary<int, string> State                      = new Dictionary<int, string> { { 0, NullGuid }, { 1, "7C78392E-B4D6-4B88-A730-208CBC20BBDB" }, { 2, "6B6173D9-EED5-4E23-922F-1ECD173502C9" }, { 3, "635D60C2-E97A-4621-948E-5A2590F63173" }, { 4, "001ED31F-C07F-407C-8BE6-28018C205E44" }, { 5, "5374D07E-36FF-48BA-A64C-29D0234143A0" }, { 6, "D3E7DCF6-1640-4B1A-9A6A-D4840E5883F4" } };
        }

        /// <summary>
        /// The date time minimum value
        /// </summary>
        private static readonly DateTime DateTimeMinValue = new DateTime(1900, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

        /// <summary>
        /// Gets the address item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>AddressItem.</returns>
        public AddressItem GetAddressItem(string id)
        {
            var result = (from i in GetAddressItems()
                          where i.Id.Equals(id)
                          select i).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentOutOfRangeException("id", id, GetExceptionMessage(Keys.Address));
            }
            return result;
        }

        /// <summary>
        /// Gets the address items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>AddressItem[].</returns>
        public AddressItem[] GetAddressItems(int count, bool includeNullGuid)
        {
            if (count > Keys.Address.Count || count < 1) 
                throw new ArgumentOutOfRangeException(GetExceptionMessage(Keys.Address));
            var list = new List<AddressItem>();
            if(includeNullGuid) list.Add(GetAddressItem(Keys.Address[0]));
            for (int i = 0, key = 1 ; i < count; i++)
            {
                list.Add(GetAddressItem(Keys.Address[key++]));
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the address items.
        /// </summary>
        /// <returns>AddressItem[].</returns>
        public AddressItem[] GetAddressItems()
        {
            return new[] { new AddressItem { Id = Keys.Address[1], Address1 = "Tom Yorke A1",        Address2 = "Tom Yorke A2",          Number = "1",   Box = "B1", ZipCode = "ZIP 1", City = "Seatle",         StateId = Keys.State[1], CountryId = Keys.Country[1], TypeId = Keys.AddressType[1], Latitude = 47.606389, Longitude = 122.330556, AddressString = String.Empty },
                           new AddressItem { Id = Keys.Address[2], Address1 = "Eddie Vedder A1",     Address2 = "Eddie Vedder A2",       Number = "2",   Box = "B2", ZipCode = "ZIP 2", City = "Austin",         StateId = Keys.State[2], CountryId = Keys.Country[1], TypeId = Keys.AddressType[1], Latitude = 30.266667, Longitude = 197.742778, AddressString = String.Empty },
                           new AddressItem { Id = Keys.Address[3], Address1 = "Norah Jones A1",      Address2 = "Norah Jones A2",        Number = "3",   Box = "B3", ZipCode = "ZIP 3", City = "Pleasantville",  StateId = Keys.State[3], CountryId = Keys.Country[1], TypeId = Keys.AddressType[1], Latitude = 10.454878, Longitude = 187.742778, AddressString = String.Empty },
                           new AddressItem { Id = Keys.Address[4], Address1 = "Sabine Appelmans A1", Address2 = "Sabine Applemans A2",   Number = "4",   Box = "B4", ZipCode = "ZIP 4", City = "Erembodegem",    StateId = Keys.State[4], CountryId = Keys.Country[2], TypeId = Keys.AddressType[2], Latitude = 20.124471, Longitude = 177.742778, AddressString = String.Empty },
                           new AddressItem { Id = Keys.Address[5], Address1 = "Maria Sharapova A1",  Address2 = "Maria Sharapova A2",    Number = "5",   Box = "B5", ZipCode = "ZIP 5", City = "Moscou",         StateId = Keys.State[5], CountryId = Keys.Country[2], TypeId = Keys.AddressType[2], Latitude = 40.792415, Longitude = 167.742778, AddressString = String.Empty },
                           new AddressItem { Id = Keys.Address[6], Address1 = "Kim Clijsters A1.1",  Address2 = "Kim Clijsters A2.1",    Number = "6.1", Box = "B6", ZipCode = "ZIP 6", City = "Bree",           StateId = Keys.State[6], CountryId = Keys.Country[2], TypeId = Keys.AddressType[3], Latitude = 50.124565, Longitude = 157.742778, AddressString = String.Empty },
                           new AddressItem { Id = Keys.Address[7], Address1 = "Kim Clijsters A1.2",  Address2 = "Kim Clijsters A2.2",    Number = "6.2", Box = "B7", ZipCode = "ZIP 7", City = "Neeroeteren",    StateId = Keys.State[6], CountryId = Keys.Country[2], TypeId = Keys.AddressType[3], Latitude = 60.156741, Longitude = 147.742778, AddressString = String.Empty },
                           new AddressItem { Id = Keys.Address[8], Address1 = "Kim Clijsters A1.3",  Address2 = "Kim Clijsters A2.3",    Number = "6.3", Box = "B8", ZipCode = "ZIP 8", City = "Opoeteren",      StateId = Keys.State[6], CountryId = Keys.Country[2], TypeId = Keys.AddressType[3], Latitude = 70.152423, Longitude = 137.742778, AddressString = String.Empty }
                         };
        }

        /// <summary>
        /// Gets the country item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CountryItem.</returns>
        public CountryItem GetCountryItem(string id)
        {
            var result = (from c in GetCountryItems()
                          where c.Id.Equals(id)
                          select c).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentOutOfRangeException("id", id, GetExceptionMessage(Keys.Country));
            }
            return result;
        }

        /// <summary>
        /// Gets the country items.
        /// </summary>
        /// <returns>CountryItem[].</returns>
        public CountryItem[] GetCountryItems()
        {
            return new[] { new CountryItem{ Id = Keys.Country[1], DefaultName = "Germany"        , TwoLetterIsoRegionName = "DE", ThreeLetterIsoRegionName = "DEU" },
                           new CountryItem{ Id = Keys.Country[2], DefaultName = "United States"  , TwoLetterIsoRegionName = "US", ThreeLetterIsoRegionName = "USA" },
                           new CountryItem{ Id = Keys.Country[3], DefaultName = "France"         , TwoLetterIsoRegionName = "FR", ThreeLetterIsoRegionName = "FRA" },
                           new CountryItem{ Id = Keys.Country[4], DefaultName = "Netherlands"    , TwoLetterIsoRegionName = "NL", ThreeLetterIsoRegionName = "NLD" },
                           new CountryItem{ Id = Keys.Country[5], DefaultName = "United Kingdom" , TwoLetterIsoRegionName = "GB", ThreeLetterIsoRegionName = "GBR" },
                           new CountryItem{ Id = Keys.Country[6], DefaultName = "Luxembourg"     , TwoLetterIsoRegionName = "LU", ThreeLetterIsoRegionName = "LUX" },
                           new CountryItem{ Id = Keys.Country[7], DefaultName = "Belgium"        , TwoLetterIsoRegionName = "BE", ThreeLetterIsoRegionName = "BEL" }
                         };
        }

        /// <summary>
        /// Gets the country items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>CountryItem[].</returns>
        public CountryItem[] GetCountryItems(int count, bool includeNullGuid)
        {
            if (count > Keys.Country.Count || count < 1)
                throw new ArgumentOutOfRangeException(GetExceptionMessage(Keys.Country));
            var list = new List<CountryItem>();
            if (includeNullGuid)
                list.Add(GetCountryItem(Keys.Country[0]));
            for (int i = 0, key = 1; i < count; i++)
            {
                list.Add(GetCountryItem(Keys.Country[key++]));
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the address items for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>AddressItem[].</returns>
        public AddressItem[] GetAddressItemsForRelation(string relationId)
        {
            List<AddressItem> result = new List<AddressItem>();
            List<AddressItem> addressItemsList = GetAddressItems().ToList();
            List<RelationAddressItem> relationAddressItems = (from ra in GetRelationAddressItems()
                                                              where ra.RelationId.Equals(relationId)
                                                              select ra).ToList();

            foreach (RelationAddressItem relationAddressItem in relationAddressItems)
            {
                var item = relationAddressItem;
                AddressItem addressItem = (from a in addressItemsList
                                           where a.Id.Equals(item.RelationId)
                                           select a).FirstOrDefault();
                if (addressItem != null) result.Add(addressItem);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Gets the document item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DocumentItem.</returns>
        public DocumentItem GetDocumentItem(string id)
        {
            var result = (from i in GetDocumentItems()
                          where i.Id.Equals(id)
                          select i).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentOutOfRangeException( "id", id, GetExceptionMessage(Keys.Document));
            }
            return result;
        }

        /// <summary>
        /// Gets the document items.
        /// </summary>
        /// <returns>DocumentItem[].</returns>
        public DocumentItem[] GetDocumentItems()
        {
            return new[] { new DocumentItem { Id = Keys.Document[1], TypeId = Keys.DocumentType[1], IdentificationNumber = "1", IssueDate = DateTimeMinValue.AddDays(1),  ExpiryDate = DateTimeMinValue.AddDays(20) },
                           new DocumentItem { Id = Keys.Document[2], TypeId = Keys.DocumentType[1], IdentificationNumber = "2", IssueDate = DateTimeMinValue.AddDays(3),  ExpiryDate = DateTimeMinValue.AddDays(40) },
                           new DocumentItem { Id = Keys.Document[3], TypeId = Keys.DocumentType[2], IdentificationNumber = "3", IssueDate = DateTimeMinValue.AddDays(5),  ExpiryDate = DateTimeMinValue.AddDays(60) },
                           new DocumentItem { Id = Keys.Document[4], TypeId = Keys.DocumentType[2], IdentificationNumber = "4", IssueDate = DateTimeMinValue.AddDays(7),  ExpiryDate = DateTimeMinValue.AddDays(80) },
                           new DocumentItem { Id = Keys.Document[5], TypeId = Keys.DocumentType[3], IdentificationNumber = "5", IssueDate = DateTimeMinValue.AddDays(9),  ExpiryDate = DateTimeMinValue.AddDays(10) },
                           new DocumentItem { Id = Keys.Document[6], TypeId = Keys.DocumentType[3], IdentificationNumber = "6", IssueDate = DateTimeMinValue.AddDays(11), ExpiryDate = DateTimeMinValue.AddDays(15) }
                       };
        }

        /// <summary>
        /// Gets the document items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>DocumentItem[].</returns>
        public DocumentItem[] GetDocumentItems(int count, bool includeNullGuid = false)
        {
            if (count > Keys.Document.Count || count < 1)
                throw new ArgumentOutOfRangeException(GetExceptionMessage(Keys.Document));
            var list = new List<DocumentItem>();
            if (includeNullGuid)
                list.Add(GetDocumentItem(Keys.Country[0]));
            for (int i = 0, key = 1; i < count; i++)
            {
                list.Add(GetDocumentItem(Keys.Document[key++]));
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the relation address item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelationAddressItem.</returns>
        public RelationAddressItem GetRelationAddressItem(string id)
        {
            var result = (from i in GetRelationAddressItems()
                          where i.Id.Equals(id)
                          select i).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentOutOfRangeException("id", id, GetExceptionMessage(Keys.RelationAddress));
            }
            return result;
        }

        /// <summary>
        /// Gets the relation address items.
        /// </summary>
        /// <returns>RelationAddressItem[].</returns>
        public RelationAddressItem[] GetRelationAddressItems()
        {
            return new[] { new RelationAddressItem { Id = Keys.RelationAddress[1], AddressId = Keys.Address[1], RelationId = Keys.Relation[1], TypeId = Keys.RelationAddressType[1] },
                           new RelationAddressItem { Id = Keys.RelationAddress[2], AddressId = Keys.Address[2], RelationId = Keys.Relation[1], TypeId = Keys.RelationAddressType[1] }, 
                           new RelationAddressItem { Id = Keys.RelationAddress[3], AddressId = Keys.Address[3], RelationId = Keys.Relation[1], TypeId = Keys.RelationAddressType[2] }, 
                           new RelationAddressItem { Id = Keys.RelationAddress[4], AddressId = Keys.Address[4], RelationId = Keys.Relation[2], TypeId = Keys.RelationAddressType[2] },
                           new RelationAddressItem { Id = Keys.RelationAddress[5], AddressId = Keys.Address[5], RelationId = Keys.Relation[2], TypeId = Keys.RelationAddressType[3] }, 
                           new RelationAddressItem { Id = Keys.RelationAddress[6], AddressId = Keys.Address[6], RelationId = Keys.Relation[3], TypeId = Keys.RelationAddressType[3] },
                           new RelationAddressItem { Id = Keys.RelationAddress[6], AddressId = Keys.Address[7], RelationId = Keys.Relation[4], TypeId = Keys.RelationAddressType[3] }, 
                           new RelationAddressItem { Id = Keys.RelationAddress[7], AddressId = Keys.Address[8], RelationId = Keys.Relation[5], TypeId = Keys.RelationAddressType[3] }};
        }

        /// <summary>
        /// Gets the relation address items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>RelationAddressItem[].</returns>
        public RelationAddressItem[] GetRelationAddressItems(int count, bool includeNullGuid)
        {
            if (count > Keys.RelationAddress.Count || count < 1) 
                throw new ArgumentOutOfRangeException(GetExceptionMessage(Keys.RelationAddress));
            var list = new List<RelationAddressItem>();
            if (includeNullGuid)
                list.Add(GetRelationAddressItem(Keys.RelationAddress[0]));
            for (int i = 0, key = 1; i < count; i++)
            {
                list.Add(GetRelationAddressItem(Keys.RelationAddress[key++]));
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the relation item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelationItem.</returns>
        public RelationItem GetRelationItem(string id)
        {
            var result = (from i in GetRelationItems()
                          where i.Id.Equals(id)
                          select i).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentOutOfRangeException("id", id, GetExceptionMessage(Keys.Relation));
            }
            return result;
        }

        /// <summary>
        /// Gets the relation items.
        /// </summary>
        /// <returns>RelationItem[].</returns>
        public RelationItem[] GetRelationItems()
        {
            return new[] { new RelationItem{Id = Keys.Relation[1], DateOfBirth = DateTimeMinValue.AddDays(10), FirstName = "Tom"       , GenderId = Keys.Gender[1], DocumentId = Keys.Document[1], LastName = "Yorke"      , MiddleName = "M1", PlaceOfBirth = "A", TypeId = Keys.RelationType[1]},
                           new RelationItem{Id = Keys.Relation[2], DateOfBirth = DateTimeMinValue.AddDays(15), FirstName = "Eddie"     , GenderId = Keys.Gender[1], DocumentId = Keys.Document[2], LastName = "Vedder"     , MiddleName = "M2", PlaceOfBirth = "X", TypeId = Keys.RelationType[1]},
                           new RelationItem{Id = Keys.Relation[3], DateOfBirth = DateTimeMinValue.AddDays(20), FirstName = "Nora"      , GenderId = Keys.Gender[1], DocumentId = Keys.Document[3], LastName = "Jones"      , MiddleName = "M3", PlaceOfBirth = "Y", TypeId = Keys.RelationType[2]},
                           new RelationItem{Id = Keys.Relation[4], DateOfBirth = DateTimeMinValue.AddDays(25), FirstName = "Sabine"    , GenderId = Keys.Gender[2], DocumentId = Keys.Document[4], LastName = "Appelmans"  , MiddleName = "M4", PlaceOfBirth = "Z", TypeId = Keys.RelationType[2]},
                           new RelationItem{Id = Keys.Relation[5], DateOfBirth = DateTimeMinValue.AddDays(30), FirstName = "Maria"     , GenderId = Keys.Gender[2], DocumentId = Keys.Document[5], LastName = "Sharapova"  , MiddleName = "M5", PlaceOfBirth = "Q", TypeId = Keys.RelationType[3]},
                           new RelationItem{Id = Keys.Relation[6], DateOfBirth = DateTimeMinValue.AddDays(35), FirstName = "Kim"       , GenderId = Keys.Gender[2], DocumentId = Keys.Document[6], LastName = "Clijsters"  , MiddleName = "M6", PlaceOfBirth = "S", TypeId = Keys.RelationType[3]}
                       };
        }

        /// <summary>
        /// Gets the relation document item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelationDocumentItem.</returns>
        public RelationDocumentItem GetRelationDocumentItem(string id)
        {
            var result = (from i in GetRelationDocumentItems()
                          where i.Id.Equals(id)
                          select i).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentOutOfRangeException("id", id, GetExceptionMessage(Keys.RelationDocument));
            }
            return result;
        }

        /// <summary>
        /// Gets the relation document items.
        /// </summary>
        /// <returns>RelationDocumentItem[].</returns>
        public RelationDocumentItem[] GetRelationDocumentItems()
        {
            return new[] { new RelationDocumentItem { Id = Keys.RelationDocument[1], RelationId = Keys.Relation[1], DocumentId = Keys.Document[1], TypeId = Keys.RelationDocumentType[1]},
                           new RelationDocumentItem { Id = Keys.RelationDocument[2], RelationId = Keys.Relation[1], DocumentId = Keys.Document[2], TypeId = Keys.RelationDocumentType[1]}, 
                           new RelationDocumentItem { Id = Keys.RelationDocument[3], RelationId = Keys.Relation[1], DocumentId = Keys.Document[3], TypeId = Keys.RelationDocumentType[2]},
                           new RelationDocumentItem { Id = Keys.RelationDocument[4], RelationId = Keys.Relation[2], DocumentId = Keys.Document[4], TypeId = Keys.RelationDocumentType[1]}, 
                           new RelationDocumentItem { Id = Keys.RelationDocument[5], RelationId = Keys.Relation[2], DocumentId = Keys.Document[5], TypeId = Keys.RelationDocumentType[2]}, 
                           new RelationDocumentItem { Id = Keys.RelationDocument[6], RelationId = Keys.Relation[3], DocumentId = Keys.Document[6], TypeId = Keys.RelationDocumentType[3]}};
        }

        /// <summary>
        /// Gets the relation document items.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="includeNullGuid">The include null unique identifier.</param>
        /// <returns>RelationDocumentItem[].</returns>
        public RelationDocumentItem[] GetRelationDocumentItems(int count, bool includeNullGuid)
        {
            if (count > Keys.RelationDocument.Count || count < 1)
                throw new ArgumentOutOfRangeException(GetExceptionMessage(Keys.RelationDocument));
            var list = new List<RelationDocumentItem>();
            if (includeNullGuid)
                list.Add(GetRelationDocumentItem(Keys.RelationDocument[0]));
            for (int i = 0, key = 1; i < count; i++)
            {
                list.Add(GetRelationDocumentItem(Keys.RelationDocument[key++]));
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the exception message.
        /// </summary>
        /// <param name="dic">The dic.</param>
        /// <returns>System.String.</returns>
        private static string GetExceptionMessage(Dictionary<int, string> dic)
        {
            string output = dic.Aggregate(String.Empty, (current, pair) => current + (", '" + pair.Value + "'"));
            output = "Could not find the id in the dictionary { " + output.Substring(2) + " }";
            return output;
        }

    }
}
