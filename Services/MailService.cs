using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class MailService
{
    public async Task<bool> sendmail(string from, string to, string subject, string message, string domain, string apiKey)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes("api" + ":" + apiKey)));

            var form = new Dictionary<string, string>();
            form["from"] = from;
            form["to"] = to;
            form["subject"] = subject;
            form["html"] = message;

            var response = await client.PostAsync("https://api.mailgun.net/v3/" + domain + "/messages", new FormUrlEncodedContent(form));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}