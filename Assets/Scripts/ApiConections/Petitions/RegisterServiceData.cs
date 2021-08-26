using SnowKore.Services;
using System.Collections.Generic;

public class RegisterServiceData : NewServiceData
{
    private string name, lastname, phone, postalcode, age,email, device;
    
    public RegisterServiceData(string name, string lastname,  string phone, string age, string postalcode, string email, string device)
    {
        this.email = email;
        this.name = name;
        this.lastname = lastname;
        this.phone = phone;
        this.postalcode = postalcode;
        this.device = device;
        this.age = age;


    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("email", email);
            body.Add("phone", phone);
            body.Add("name", name);
            body.Add("age", age);
            body.Add("lastname", lastname);
            body.Add("postal_code", postalcode);
            body.Add("device", device);

            return body;
        }
    }

    protected override string ServiceURL => "user/register";

    protected override Dictionary<string, object> Params
    {
        get
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            return parameters;
        }
    }

    protected override Dictionary<string, string> Headers
    {
        get
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            return headers;
        }
    }
protected override ServiceType ServiceType => ServiceType.POST;
}
