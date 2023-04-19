/*
 * IX-API
 *
 *  This API allows to configure/change/delete Internet Exchange services.  # Filters When querying collections, the provided query parameters are validated. Unknown query parameters are ignored. Providing invalid filter values should yield a validation error.  # State A lot of resources are stateful, indicated by the presence of a `state` property, to support the inherently asynchronous nature of provisioning, deployment and on-boarding processes.  The following table describes the meaning of each state:  | State | Meaning | | - -- -- - | - -- -- - | | requested | Resource has been requested by the customer but not yet fully reserved (sub-resources required) | | allocated | All resources required for service are reserved | | testing | The resource is provisioned and is currently being tested | | production | The resource is active and can be used by the customer | | production_change_pending | The resource is active but the customer has requested a change that is awaiting completion | | decommission_requested | The resource is active but the customer has requested disconnection that is awaiting completion | | decommissioned | The resource has been de-provisioned and billing is terminated or scheduled for termination | | archived | The resource was \"deleted/purged\" and is not listed unless explicitly requested in the filter (i.e. `?state=archived`). | | error | The resource has experienced error during provisioning or after is has been activated | | cancelled | The request for a service was cancelled before provisioning was completed | | operator | Human intervention is needed | | scheduled | The service has been scheduled for provisioning |  Please note, that not all implementers _HAVE_ to implement all the listed states.  *Sidenote:* If the deleted operation is applied to an object in state `decommissioned` the object will move to state archived.  # Sensitive Properties  Some properties contain sensitive information and should be redacted when the resource is made available users outside the authorized scope.  This is for example the case when an `Account` is flagged as `discoverable`, it becomes available to other API users. In this case only: `id`, `name` and `metro_area_network_presence` should be exposed.  If a property is `required` and needs to be redacted, a zero value should be used. For strings this would be an empty string `\"\"`, for numeric values `0` and booleans `false`.  Shared resources with sensitive properties: `Account`, `NetworkService` 
 *
 * The version of the OpenAPI document: 2.4.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// Cloud Network Service
    /// </summary>
    [DataContract(Name = "CloudNetworkService")]
    public partial class CloudNetworkService : NetworkService, IEquatable<CloudNetworkService>, IValidatableObject
    {
        /// <summary>
        /// Defines State
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StateEnum
        {
            /// <summary>
            /// Enum Requested for value: requested
            /// </summary>
            [EnumMember(Value = "requested")]
            Requested = 1,

            /// <summary>
            /// Enum Allocated for value: allocated
            /// </summary>
            [EnumMember(Value = "allocated")]
            Allocated = 2,

            /// <summary>
            /// Enum Testing for value: testing
            /// </summary>
            [EnumMember(Value = "testing")]
            Testing = 3,

            /// <summary>
            /// Enum Production for value: production
            /// </summary>
            [EnumMember(Value = "production")]
            Production = 4,

            /// <summary>
            /// Enum ProductionChangePending for value: production_change_pending
            /// </summary>
            [EnumMember(Value = "production_change_pending")]
            ProductionChangePending = 5,

            /// <summary>
            /// Enum DecommissionRequested for value: decommission_requested
            /// </summary>
            [EnumMember(Value = "decommission_requested")]
            DecommissionRequested = 6,

            /// <summary>
            /// Enum Decommissioned for value: decommissioned
            /// </summary>
            [EnumMember(Value = "decommissioned")]
            Decommissioned = 7,

            /// <summary>
            /// Enum Archived for value: archived
            /// </summary>
            [EnumMember(Value = "archived")]
            Archived = 8,

            /// <summary>
            /// Enum Error for value: error
            /// </summary>
            [EnumMember(Value = "error")]
            Error = 9,

            /// <summary>
            /// Enum Operator for value: operator
            /// </summary>
            [EnumMember(Value = "operator")]
            Operator = 10,

            /// <summary>
            /// Enum Scheduled for value: scheduled
            /// </summary>
            [EnumMember(Value = "scheduled")]
            Scheduled = 11,

            /// <summary>
            /// Enum Cancelled for value: cancelled
            /// </summary>
            [EnumMember(Value = "cancelled")]
            Cancelled = 12

        }


        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", IsRequired = true, EmitDefaultValue = true)]
        public StateEnum State { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworkService" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CloudNetworkService() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworkService" /> class.
        /// </summary>
        /// <param name="billingAccount">An account requires billing_information to be used as a &#x60;billing_account&#x60;. *(Sensitive Property)* (required).</param>
        /// <param name="capacity">The capacity of the service in Mbps. When null, the maximum capacity will be used..</param>
        /// <param name="chargedUntil">The service continues incurring charges until this date. Typically &#x60;≥ decommission_at&#x60;.  This field is only used when the state is &#x60;DECOMMISSION_REQUESTED&#x60; or &#x60;DECOMMISSIONED&#x60;.  *(Sensitive Property)*.</param>
        /// <param name="cloudKey">The cloud key is used to specify to which user or existing circuit of a cloud provider this &#x60;network-service&#x60; should be provisioned.  For example, for a provider like *AWS*, this would be the *account number* (Example: &#x60;123456789876&#x60;), or for a provider like Azure, this would be the service key (Example: &#x60;acl9edcf-f11c-4681-9c7b-6d16b2973997&#x60;) (required).</param>
        /// <param name="consumingAccount">The &#x60;id&#x60; of the account consuming a service.  Used to be &#x60;owning_customer&#x60;.  (required).</param>
        /// <param name="contractRef">A reference to a contract. If no specific contract is used, a default MAY be chosen by the implementer. *(Sensitive Property)* .</param>
        /// <param name="currentBillingStartDate">Your obligation to pay for the service will start on this date.  However, this date may change after an upgrade and not reflect the inital start date of the service.  *(Sensitive Property)*.</param>
        /// <param name="decommissionAt">The service will be decommissioned on this date.  This field is only used when the state is &#x60;DECOMMISSION_REQUESTED&#x60; or &#x60;DECOMMISSIONED&#x60;..</param>
        /// <param name="diversity">Same value as the corresponding &#x60;ProductOffering&#x60;.  The service can be delivered over multiple handovers from the exchange to the &#x60;service_provider&#x60;.  The &#x60;diversity&#x60; denotes the number of handovers between the exchange and the service provider. A value of two signals a redundant service.  Only one network service configuration for each &#x60;handover&#x60; and &#x60;cloud_vlan&#x60; can be created. (required).</param>
        /// <param name="externalRef">Reference field, free to use for the API user. *(Sensitive Property)* .</param>
        /// <param name="id">id (required).</param>
        /// <param name="managingAccount">The &#x60;id&#x60; of the account responsible for managing the service via the API. A manager can read and update the state of entities.  (required).</param>
        /// <param name="providerRef">For a cloud network service with the exchange first workflow, the &#x60;provider_ref&#x60; will be a reference to a resource of the cloud provider. (E.g. the UUID of a virtual circuit.)  The &#x60;provider_ref&#x60; is managed by the exchange and its meaning may vary between different cloud services.  (required).</param>
        /// <param name="purchaseOrder">Purchase Order ID which will be displayed on the invoice. *(Sensitive Property)*  (default to &quot;&quot;).</param>
        /// <param name="state">state (required).</param>
        /// <param name="status">status.</param>
        /// <param name="type">type (default to &quot;CloudNetworkService&quot;).</param>
        public CloudNetworkService(string billingAccount = default(string), int? capacity = default(int?), DateTime chargedUntil = default(DateTime), string cloudKey = default(string), string consumingAccount = default(string), string contractRef = default(string), DateTime currentBillingStartDate = default(DateTime), DateTime decommissionAt = default(DateTime), int diversity = default(int), string externalRef = default(string), string id = default(string), string managingAccount = default(string), string providerRef = default(string), string purchaseOrder = @"", StateEnum state = default(StateEnum), List<Status> status = default(List<Status>), string type = @"CloudNetworkService") : base(type)
        {
            // to ensure "billingAccount" is required (not null)
            if (billingAccount == null)
            {
                throw new ArgumentNullException("billingAccount is a required property for CloudNetworkService and cannot be null");
            }
            this.BillingAccount = billingAccount;
            // to ensure "cloudKey" is required (not null)
            if (cloudKey == null)
            {
                throw new ArgumentNullException("cloudKey is a required property for CloudNetworkService and cannot be null");
            }
            this.CloudKey = cloudKey;
            // to ensure "consumingAccount" is required (not null)
            if (consumingAccount == null)
            {
                throw new ArgumentNullException("consumingAccount is a required property for CloudNetworkService and cannot be null");
            }
            this.ConsumingAccount = consumingAccount;
            this.Diversity = diversity;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for CloudNetworkService and cannot be null");
            }
            this.Id = id;
            // to ensure "managingAccount" is required (not null)
            if (managingAccount == null)
            {
                throw new ArgumentNullException("managingAccount is a required property for CloudNetworkService and cannot be null");
            }
            this.ManagingAccount = managingAccount;
            // to ensure "providerRef" is required (not null)
            if (providerRef == null)
            {
                throw new ArgumentNullException("providerRef is a required property for CloudNetworkService and cannot be null");
            }
            this.ProviderRef = providerRef;
            this.State = state;
            this.Capacity = capacity;
            this.ChargedUntil = chargedUntil;
            this.ContractRef = contractRef;
            this.CurrentBillingStartDate = currentBillingStartDate;
            this.DecommissionAt = decommissionAt;
            this.ExternalRef = externalRef;
            // use default value if no "purchaseOrder" provided
            this.PurchaseOrder = purchaseOrder ?? @"";
            this.Status = status;
        }

        /// <summary>
        /// An account requires billing_information to be used as a &#x60;billing_account&#x60;. *(Sensitive Property)*
        /// </summary>
        /// <value>An account requires billing_information to be used as a &#x60;billing_account&#x60;. *(Sensitive Property)*</value>
        [DataMember(Name = "billing_account", IsRequired = true, EmitDefaultValue = true)]
        public string BillingAccount { get; set; }

        /// <summary>
        /// The capacity of the service in Mbps. When null, the maximum capacity will be used.
        /// </summary>
        /// <value>The capacity of the service in Mbps. When null, the maximum capacity will be used.</value>
        [DataMember(Name = "capacity", EmitDefaultValue = true)]
        public int? Capacity { get; set; }

        /// <summary>
        /// The service continues incurring charges until this date. Typically &#x60;≥ decommission_at&#x60;.  This field is only used when the state is &#x60;DECOMMISSION_REQUESTED&#x60; or &#x60;DECOMMISSIONED&#x60;.  *(Sensitive Property)*
        /// </summary>
        /// <value>The service continues incurring charges until this date. Typically &#x60;≥ decommission_at&#x60;.  This field is only used when the state is &#x60;DECOMMISSION_REQUESTED&#x60; or &#x60;DECOMMISSIONED&#x60;.  *(Sensitive Property)*</value>
        [DataMember(Name = "charged_until", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime ChargedUntil { get; set; }

        /// <summary>
        /// The cloud key is used to specify to which user or existing circuit of a cloud provider this &#x60;network-service&#x60; should be provisioned.  For example, for a provider like *AWS*, this would be the *account number* (Example: &#x60;123456789876&#x60;), or for a provider like Azure, this would be the service key (Example: &#x60;acl9edcf-f11c-4681-9c7b-6d16b2973997&#x60;)
        /// </summary>
        /// <value>The cloud key is used to specify to which user or existing circuit of a cloud provider this &#x60;network-service&#x60; should be provisioned.  For example, for a provider like *AWS*, this would be the *account number* (Example: &#x60;123456789876&#x60;), or for a provider like Azure, this would be the service key (Example: &#x60;acl9edcf-f11c-4681-9c7b-6d16b2973997&#x60;)</value>
        [DataMember(Name = "cloud_key", IsRequired = true, EmitDefaultValue = true)]
        public string CloudKey { get; set; }

        /// <summary>
        /// The &#x60;id&#x60; of the account consuming a service.  Used to be &#x60;owning_customer&#x60;. 
        /// </summary>
        /// <value>The &#x60;id&#x60; of the account consuming a service.  Used to be &#x60;owning_customer&#x60;. </value>
        /// <example>&quot;2381982&quot;</example>
        [DataMember(Name = "consuming_account", IsRequired = true, EmitDefaultValue = true)]
        public string ConsumingAccount { get; set; }

        /// <summary>
        /// A reference to a contract. If no specific contract is used, a default MAY be chosen by the implementer. *(Sensitive Property)* 
        /// </summary>
        /// <value>A reference to a contract. If no specific contract is used, a default MAY be chosen by the implementer. *(Sensitive Property)* </value>
        /// <example>&quot;contract:31824&quot;</example>
        [DataMember(Name = "contract_ref", EmitDefaultValue = true)]
        public string ContractRef { get; set; }

        /// <summary>
        /// Your obligation to pay for the service will start on this date.  However, this date may change after an upgrade and not reflect the inital start date of the service.  *(Sensitive Property)*
        /// </summary>
        /// <value>Your obligation to pay for the service will start on this date.  However, this date may change after an upgrade and not reflect the inital start date of the service.  *(Sensitive Property)*</value>
        [DataMember(Name = "current_billing_start_date", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime CurrentBillingStartDate { get; set; }

        /// <summary>
        /// The service will be decommissioned on this date.  This field is only used when the state is &#x60;DECOMMISSION_REQUESTED&#x60; or &#x60;DECOMMISSIONED&#x60;.
        /// </summary>
        /// <value>The service will be decommissioned on this date.  This field is only used when the state is &#x60;DECOMMISSION_REQUESTED&#x60; or &#x60;DECOMMISSIONED&#x60;.</value>
        [DataMember(Name = "decommission_at", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime DecommissionAt { get; set; }

        /// <summary>
        /// Same value as the corresponding &#x60;ProductOffering&#x60;.  The service can be delivered over multiple handovers from the exchange to the &#x60;service_provider&#x60;.  The &#x60;diversity&#x60; denotes the number of handovers between the exchange and the service provider. A value of two signals a redundant service.  Only one network service configuration for each &#x60;handover&#x60; and &#x60;cloud_vlan&#x60; can be created.
        /// </summary>
        /// <value>Same value as the corresponding &#x60;ProductOffering&#x60;.  The service can be delivered over multiple handovers from the exchange to the &#x60;service_provider&#x60;.  The &#x60;diversity&#x60; denotes the number of handovers between the exchange and the service provider. A value of two signals a redundant service.  Only one network service configuration for each &#x60;handover&#x60; and &#x60;cloud_vlan&#x60; can be created.</value>
        [DataMember(Name = "diversity", IsRequired = true, EmitDefaultValue = true)]
        public int Diversity { get; set; }

        /// <summary>
        /// Reference field, free to use for the API user. *(Sensitive Property)* 
        /// </summary>
        /// <value>Reference field, free to use for the API user. *(Sensitive Property)* </value>
        /// <example>&quot;IX:Service:23042&quot;</example>
        [DataMember(Name = "external_ref", EmitDefaultValue = true)]
        public string ExternalRef { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The &#x60;id&#x60; of the account responsible for managing the service via the API. A manager can read and update the state of entities. 
        /// </summary>
        /// <value>The &#x60;id&#x60; of the account responsible for managing the service via the API. A manager can read and update the state of entities. </value>
        /// <example>&quot;238189294&quot;</example>
        [DataMember(Name = "managing_account", IsRequired = true, EmitDefaultValue = true)]
        public string ManagingAccount { get; set; }

        /// <summary>
        /// The configuration will require at least one of each of the specified roles assigned to contacts.  The &#x60;RoleAssignment&#x60; is associated through the &#x60;role_assignments&#x60; list property of the network service configuration.
        /// </summary>
        /// <value>The configuration will require at least one of each of the specified roles assigned to contacts.  The &#x60;RoleAssignment&#x60; is associated through the &#x60;role_assignments&#x60; list property of the network service configuration.</value>
        [DataMember(Name = "nsc_required_contact_roles", EmitDefaultValue = false)]
        public List<string> NscRequiredContactRoles { get; private set; }

        /// <summary>
        /// Returns false as NscRequiredContactRoles should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeNscRequiredContactRoles()
        {
            return false;
        }
        /// <summary>
        /// For a cloud network service with the exchange first workflow, the &#x60;provider_ref&#x60; will be a reference to a resource of the cloud provider. (E.g. the UUID of a virtual circuit.)  The &#x60;provider_ref&#x60; is managed by the exchange and its meaning may vary between different cloud services. 
        /// </summary>
        /// <value>For a cloud network service with the exchange first workflow, the &#x60;provider_ref&#x60; will be a reference to a resource of the cloud provider. (E.g. the UUID of a virtual circuit.)  The &#x60;provider_ref&#x60; is managed by the exchange and its meaning may vary between different cloud services. </value>
        /// <example>&quot;331050d5-76fb-498b-b72a-248520278fbd&quot;</example>
        [DataMember(Name = "provider_ref", IsRequired = true, EmitDefaultValue = true)]
        public string ProviderRef { get; set; }

        /// <summary>
        /// Purchase Order ID which will be displayed on the invoice. *(Sensitive Property)* 
        /// </summary>
        /// <value>Purchase Order ID which will be displayed on the invoice. *(Sensitive Property)* </value>
        /// <example>&quot;Project: DC Moon&quot;</example>
        [DataMember(Name = "purchase_order", EmitDefaultValue = false)]
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public List<Status> Status { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CloudNetworkService {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  BillingAccount: ").Append(BillingAccount).Append("\n");
            sb.Append("  Capacity: ").Append(Capacity).Append("\n");
            sb.Append("  ChargedUntil: ").Append(ChargedUntil).Append("\n");
            sb.Append("  CloudKey: ").Append(CloudKey).Append("\n");
            sb.Append("  ConsumingAccount: ").Append(ConsumingAccount).Append("\n");
            sb.Append("  ContractRef: ").Append(ContractRef).Append("\n");
            sb.Append("  CurrentBillingStartDate: ").Append(CurrentBillingStartDate).Append("\n");
            sb.Append("  DecommissionAt: ").Append(DecommissionAt).Append("\n");
            sb.Append("  Diversity: ").Append(Diversity).Append("\n");
            sb.Append("  ExternalRef: ").Append(ExternalRef).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ManagingAccount: ").Append(ManagingAccount).Append("\n");
            sb.Append("  NscRequiredContactRoles: ").Append(NscRequiredContactRoles).Append("\n");
            sb.Append("  ProviderRef: ").Append(ProviderRef).Append("\n");
            sb.Append("  PurchaseOrder: ").Append(PurchaseOrder).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CloudNetworkService);
        }

        /// <summary>
        /// Returns true if CloudNetworkService instances are equal
        /// </summary>
        /// <param name="input">Instance of CloudNetworkService to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CloudNetworkService input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.BillingAccount == input.BillingAccount ||
                    (this.BillingAccount != null &&
                    this.BillingAccount.Equals(input.BillingAccount))
                ) && base.Equals(input) && 
                (
                    this.Capacity == input.Capacity ||
                    (this.Capacity != null &&
                    this.Capacity.Equals(input.Capacity))
                ) && base.Equals(input) && 
                (
                    this.ChargedUntil == input.ChargedUntil ||
                    (this.ChargedUntil != null &&
                    this.ChargedUntil.Equals(input.ChargedUntil))
                ) && base.Equals(input) && 
                (
                    this.CloudKey == input.CloudKey ||
                    (this.CloudKey != null &&
                    this.CloudKey.Equals(input.CloudKey))
                ) && base.Equals(input) && 
                (
                    this.ConsumingAccount == input.ConsumingAccount ||
                    (this.ConsumingAccount != null &&
                    this.ConsumingAccount.Equals(input.ConsumingAccount))
                ) && base.Equals(input) && 
                (
                    this.ContractRef == input.ContractRef ||
                    (this.ContractRef != null &&
                    this.ContractRef.Equals(input.ContractRef))
                ) && base.Equals(input) && 
                (
                    this.CurrentBillingStartDate == input.CurrentBillingStartDate ||
                    (this.CurrentBillingStartDate != null &&
                    this.CurrentBillingStartDate.Equals(input.CurrentBillingStartDate))
                ) && base.Equals(input) && 
                (
                    this.DecommissionAt == input.DecommissionAt ||
                    (this.DecommissionAt != null &&
                    this.DecommissionAt.Equals(input.DecommissionAt))
                ) && base.Equals(input) && 
                (
                    this.Diversity == input.Diversity ||
                    this.Diversity.Equals(input.Diversity)
                ) && base.Equals(input) && 
                (
                    this.ExternalRef == input.ExternalRef ||
                    (this.ExternalRef != null &&
                    this.ExternalRef.Equals(input.ExternalRef))
                ) && base.Equals(input) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && base.Equals(input) && 
                (
                    this.ManagingAccount == input.ManagingAccount ||
                    (this.ManagingAccount != null &&
                    this.ManagingAccount.Equals(input.ManagingAccount))
                ) && base.Equals(input) && 
                (
                    this.NscRequiredContactRoles == input.NscRequiredContactRoles ||
                    this.NscRequiredContactRoles != null &&
                    input.NscRequiredContactRoles != null &&
                    this.NscRequiredContactRoles.SequenceEqual(input.NscRequiredContactRoles)
                ) && base.Equals(input) && 
                (
                    this.ProviderRef == input.ProviderRef ||
                    (this.ProviderRef != null &&
                    this.ProviderRef.Equals(input.ProviderRef))
                ) && base.Equals(input) && 
                (
                    this.PurchaseOrder == input.PurchaseOrder ||
                    (this.PurchaseOrder != null &&
                    this.PurchaseOrder.Equals(input.PurchaseOrder))
                ) && base.Equals(input) && 
                (
                    this.State == input.State ||
                    this.State.Equals(input.State)
                ) && base.Equals(input) && 
                (
                    this.Status == input.Status ||
                    this.Status != null &&
                    input.Status != null &&
                    this.Status.SequenceEqual(input.Status)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.BillingAccount != null)
                {
                    hashCode = (hashCode * 59) + this.BillingAccount.GetHashCode();
                }
                if (this.Capacity != null)
                {
                    hashCode = (hashCode * 59) + this.Capacity.GetHashCode();
                }
                if (this.ChargedUntil != null)
                {
                    hashCode = (hashCode * 59) + this.ChargedUntil.GetHashCode();
                }
                if (this.CloudKey != null)
                {
                    hashCode = (hashCode * 59) + this.CloudKey.GetHashCode();
                }
                if (this.ConsumingAccount != null)
                {
                    hashCode = (hashCode * 59) + this.ConsumingAccount.GetHashCode();
                }
                if (this.ContractRef != null)
                {
                    hashCode = (hashCode * 59) + this.ContractRef.GetHashCode();
                }
                if (this.CurrentBillingStartDate != null)
                {
                    hashCode = (hashCode * 59) + this.CurrentBillingStartDate.GetHashCode();
                }
                if (this.DecommissionAt != null)
                {
                    hashCode = (hashCode * 59) + this.DecommissionAt.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Diversity.GetHashCode();
                if (this.ExternalRef != null)
                {
                    hashCode = (hashCode * 59) + this.ExternalRef.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.ManagingAccount != null)
                {
                    hashCode = (hashCode * 59) + this.ManagingAccount.GetHashCode();
                }
                if (this.NscRequiredContactRoles != null)
                {
                    hashCode = (hashCode * 59) + this.NscRequiredContactRoles.GetHashCode();
                }
                if (this.ProviderRef != null)
                {
                    hashCode = (hashCode * 59) + this.ProviderRef.GetHashCode();
                }
                if (this.PurchaseOrder != null)
                {
                    hashCode = (hashCode * 59) + this.PurchaseOrder.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.State.GetHashCode();
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            // Capacity (int?) minimum
            if (this.Capacity < (int?)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Capacity, must be a value greater than or equal to 1.", new [] { "Capacity" });
            }

            // ContractRef (string) maxLength
            if (this.ContractRef != null && this.ContractRef.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractRef, length must be less than 128.", new [] { "ContractRef" });
            }

            // Diversity (int) minimum
            if (this.Diversity < (int)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Diversity, must be a value greater than or equal to 1.", new [] { "Diversity" });
            }

            // ExternalRef (string) maxLength
            if (this.ExternalRef != null && this.ExternalRef.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ExternalRef, length must be less than 128.", new [] { "ExternalRef" });
            }

            // PurchaseOrder (string) maxLength
            if (this.PurchaseOrder != null && this.PurchaseOrder.Length > 80)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PurchaseOrder, length must be less than 80.", new [] { "PurchaseOrder" });
            }

            yield break;
        }
    }

}