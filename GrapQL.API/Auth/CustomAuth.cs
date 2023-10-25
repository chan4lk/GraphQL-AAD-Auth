using System;
using System.Reflection;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace GrapQL.API.Auth
{
    [AttributeUsage(
        AttributeTargets.Class
        | AttributeTargets.Struct
        | AttributeTargets.Property
        | AttributeTargets.Method,
        Inherited = true,
        AllowMultiple = true)]
    public class CustomAuth: AuthorizeAttribute
    {
        protected override void TryConfigure(
            IDescriptorContext context,
            IDescriptor descriptor,
            ICustomAttributeProvider element)
        {
            if (descriptor is IObjectTypeDescriptor type)
            {
                type.Directive(CreateDirective());
            }
            else if (descriptor is IObjectFieldDescriptor field)
            {
                field.Directive(CreateDirective());
            }
        }

        private AuthorizeDirective CreateDirective()
        {
            if (Policy != null)
            {
                return new AuthorizeDirective(
                    Policy,
                    apply: Apply);
            }
            else if (Roles != null)
            {
                return new AuthorizeDirective(
                    Roles,
                    apply: Apply);
            }
            else
            {
                return new AuthorizeDirective(
                    apply: Apply);
            }
        }
    }
}