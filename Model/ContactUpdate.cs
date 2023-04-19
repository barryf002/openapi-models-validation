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
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// Contact Update
    /// </summary>
    [DataContract(Name = "ContactUpdate")]
    public partial class ContactUpdate : IEquatable<ContactUpdate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUpdate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ContactUpdate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUpdate" /> class.
        /// </summary>
        /// <param name="consumingAccount">The &#x60;id&#x60; of the account consuming a service.  Used to be &#x60;owning_customer&#x60;.  (required).</param>
        /// <param name="email">The email of the legal company entity. .</param>
        /// <param name="externalRef">Reference field, free to use for the API user. *(Sensitive Property)* .</param>
        /// <param name="managingAccount">The &#x60;id&#x60; of the account responsible for managing the service via the API. A manager can read and update the state of entities.  (required).</param>
        /// <param name="name">A name of a person or an organisation.</param>
        /// <param name="telephone">The telephone number in E.164 Phone Number Formatting.</param>
        public ContactUpdate(string consumingAccount = default(string), string email = default(string), string externalRef = default(string), string managingAccount = default(string), string name = default(string), string telephone = default(string))
        {
            // to ensure "consumingAccount" is required (not null)
            if (consumingAccount == null)
            {
                throw new ArgumentNullException("consumingAccount is a required property for ContactUpdate and cannot be null");
            }
            this.ConsumingAccount = consumingAccount;
            // to ensure "managingAccount" is required (not null)
            if (managingAccount == null)
            {
                throw new ArgumentNullException("managingAccount is a required property for ContactUpdate and cannot be null");
            }
            this.ManagingAccount = managingAccount;
            this.Email = email;
            this.ExternalRef = externalRef;
            this.Name = name;
            this.Telephone = telephone;
        }

        /// <summary>
        /// The &#x60;id&#x60; of the account consuming a service.  Used to be &#x60;owning_customer&#x60;. 
        /// </summary>
        /// <value>The &#x60;id&#x60; of the account consuming a service.  Used to be &#x60;owning_customer&#x60;. </value>
        /// <example>&quot;2381982&quot;</example>
        [DataMember(Name = "consuming_account", IsRequired = true, EmitDefaultValue = true)]
        public string ConsumingAccount { get; set; }

        /// <summary>
        /// The email of the legal company entity. 
        /// </summary>
        /// <value>The email of the legal company entity. </value>
        /// <example>&quot;info@moon-peer.net&quot;</example>
        [DataMember(Name = "email", EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// Reference field, free to use for the API user. *(Sensitive Property)* 
        /// </summary>
        /// <value>Reference field, free to use for the API user. *(Sensitive Property)* </value>
        /// <example>&quot;IX:Service:23042&quot;</example>
        [DataMember(Name = "external_ref", EmitDefaultValue = true)]
        public string ExternalRef { get; set; }

        /// <summary>
        /// The &#x60;id&#x60; of the account responsible for managing the service via the API. A manager can read and update the state of entities. 
        /// </summary>
        /// <value>The &#x60;id&#x60; of the account responsible for managing the service via the API. A manager can read and update the state of entities. </value>
        /// <example>&quot;238189294&quot;</example>
        [DataMember(Name = "managing_account", IsRequired = true, EmitDefaultValue = true)]
        public string ManagingAccount { get; set; }

        /// <summary>
        /// A name of a person or an organisation
        /// </summary>
        /// <value>A name of a person or an organisation</value>
        /// <example>&quot;Some A. Name&quot;</example>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The telephone number in E.164 Phone Number Formatting
        /// </summary>
        /// <value>The telephone number in E.164 Phone Number Formatting</value>
        /// <example>&quot;+442071838750&quot;</example>
        [DataMember(Name = "telephone", EmitDefaultValue = true)]
        public string Telephone { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContactUpdate {\n");
            sb.Append("  ConsumingAccount: ").Append(ConsumingAccount).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  ExternalRef: ").Append(ExternalRef).Append("\n");
            sb.Append("  ManagingAccount: ").Append(ManagingAccount).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Telephone: ").Append(Telephone).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
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
            return this.Equals(input as ContactUpdate);
        }

        /// <summary>
        /// Returns true if ContactUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of ContactUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContactUpdate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ConsumingAccount == input.ConsumingAccount ||
                    (this.ConsumingAccount != null &&
                    this.ConsumingAccount.Equals(input.ConsumingAccount))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.ExternalRef == input.ExternalRef ||
                    (this.ExternalRef != null &&
                    this.ExternalRef.Equals(input.ExternalRef))
                ) && 
                (
                    this.ManagingAccount == input.ManagingAccount ||
                    (this.ManagingAccount != null &&
                    this.ManagingAccount.Equals(input.ManagingAccount))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Telephone == input.Telephone ||
                    (this.Telephone != null &&
                    this.Telephone.Equals(input.Telephone))
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
                int hashCode = 41;
                if (this.ConsumingAccount != null)
                {
                    hashCode = (hashCode * 59) + this.ConsumingAccount.GetHashCode();
                }
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.ExternalRef != null)
                {
                    hashCode = (hashCode * 59) + this.ExternalRef.GetHashCode();
                }
                if (this.ManagingAccount != null)
                {
                    hashCode = (hashCode * 59) + this.ManagingAccount.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Telephone != null)
                {
                    hashCode = (hashCode * 59) + this.Telephone.GetHashCode();
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
            // Email (string) maxLength
            if (this.Email != null && this.Email.Length > 80)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Email, length must be less than 80.", new [] { "Email" });
            }

            // ExternalRef (string) maxLength
            if (this.ExternalRef != null && this.ExternalRef.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ExternalRef, length must be less than 128.", new [] { "ExternalRef" });
            }

            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 128.", new [] { "Name" });
            }

            // Telephone (string) maxLength
            if (this.Telephone != null && this.Telephone.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Telephone, length must be less than 40.", new [] { "Telephone" });
            }

            yield break;
        }
    }

}