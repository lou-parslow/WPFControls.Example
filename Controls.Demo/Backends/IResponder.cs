using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls.Demo.Backends;

internal interface IResponder
{
    string Respond(string request);
}

internal static class ResponderRequests
{
    public static string NameQuery
    {
        get { return "name"; }
    }

    public static string DescriptionQuery
    {
        get { return "description"; }
    }

    public static string ContactsQuery
    {
        get
        {
            return "contacts";
        }
    }
    public static string GetDeleteContactMutation(string name) { return $"deleteContact: {name}"; }
}
