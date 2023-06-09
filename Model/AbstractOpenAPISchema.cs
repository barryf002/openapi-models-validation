/*
 * IX-API
 *
 *  This API allows to configure/change/delete Internet Exchange services.  # Filters When querying collections, the provided query parameters are validated. Unknown query parameters are ignored. Providing invalid filter values should yield a validation error.  # State A lot of resources are stateful, indicated by the presence of a `state` property, to support the inherently asynchronous nature of provisioning, deployment and on-boarding processes.  The following table describes the meaning of each state:  | State | Meaning | | - -- -- - | - -- -- - | | requested | Resource has been requested by the customer but not yet fully reserved (sub-resources required) | | allocated | All resources required for service are reserved | | testing | The resource is provisioned and is currently being tested | | production | The resource is active and can be used by the customer | | production_change_pending | The resource is active but the customer has requested a change that is awaiting completion | | decommission_requested | The resource is active but the customer has requested disconnection that is awaiting completion | | decommissioned | The resource has been de-provisioned and billing is terminated or scheduled for termination | | archived | The resource was \"deleted/purged\" and is not listed unless explicitly requested in the filter (i.e. `?state=archived`). | | error | The resource has experienced error during provisioning or after is has been activated | | cancelled | The request for a service was cancelled before provisioning was completed | | operator | Human intervention is needed | | scheduled | The service has been scheduled for provisioning |  Please note, that not all implementers _HAVE_ to implement all the listed states.  *Sidenote:* If the deleted operation is applied to an object in state `decommissioned` the object will move to state archived.  # Sensitive Properties  Some properties contain sensitive information and should be redacted when the resource is made available users outside the authorized scope.  This is for example the case when an `Account` is flagged as `discoverable`, it becomes available to other API users. In this case only: `id`, `name` and `metro_area_network_presence` should be exposed.  If a property is `required` and needs to be redacted, a zero value should be used. For strings this would be an empty string `\"\"`, for numeric values `0` and booleans `false`.  Shared resources with sensitive properties: `Account`, `NetworkService` 
 *
 * The version of the OpenAPI document: 2.4.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    ///  Abstract base class for oneOf, anyOf schemas in the OpenAPI specification
    /// </summary>
    public abstract partial class AbstractOpenAPISchema
    {
        /// <summary>
        ///  Custom JSON serializer
        /// </summary>
        static public readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            MissingMemberHandling = MissingMemberHandling.Error,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        /// <summary>
        ///  Custom JSON serializer for objects with additional properties
        /// </summary>
        static public readonly JsonSerializerSettings AdditionalPropertiesSerializerSettings = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        /// <summary>
        /// Gets or Sets the actual instance
        /// </summary>
        public abstract Object ActualInstance { get; set; }

        /// <summary>
        /// Gets or Sets IsNullable to indicate whether the instance is nullable
        /// </summary>
        public bool IsNullable { get; protected set; }

        /// <summary>
        /// Gets or Sets the schema type, which can be either `oneOf` or `anyOf`
        /// </summary>
        public string SchemaType { get; protected set; }

        /// <summary>
        /// Converts the instance into JSON string.
        /// </summary>
        public abstract string ToJson();
    }
}
