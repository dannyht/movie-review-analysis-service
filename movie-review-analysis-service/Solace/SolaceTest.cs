using System.Net.Http.Headers;
using System.Text;

public class SolaceTest
{
    public async Task Send(string message)
    {
        // Set the Solace broker details
        string solaceHost = "<solace-host>"; // Replace with the Solace broker host
        string solaceUsername = "<solace-username>"; // Replace with your Solace username
        string solacePassword = "<solace-password>"; // Replace with your Solace password
        string vpnName = "<vpn-name>"; // Replace with the VPN name
        string queueName = "<queue-name>"; // Replace with the existing Solace queue name

        // Create an HttpClient instance
        using (var httpClient = new HttpClient())
        {
            // Set the Solace broker URL
            string solaceUrl = $"http://{solaceHost}:9000/SEMP/v2/config/msgVpns/{vpnName}/queues/{queueName}/messages";

            // Set the request content
            var requestContent = new StringContent(message, Encoding.UTF8, "text/plain");

            // Set the Solace authentication credentials
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{solaceUsername}:{solacePassword}")));

            // Send the request
            var response = await httpClient.PostAsync(solaceUrl, requestContent);

            // Check the response status
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Message sent successfully");
            }
            else
            {
                Console.WriteLine("Failed to send the message. Status code: " + response.StatusCode);
            }
        }
    }

    public async Task<string> Read()
    {
        // Set the Solace broker details
        string solaceHost = "<solace-host>"; // Replace with the Solace broker host
        string solaceUsername = "<solace-username>"; // Replace with your Solace username
        string solacePassword = "<solace-password>"; // Replace with your Solace password
        string vpnName = "<vpn-name>"; // Replace with the VPN name
        string queueName = "<queue-name>"; // Replace with the existing Solace queue name

        // Create the HttpClient
        using (HttpClient client = new HttpClient())
        {
            // Set the Solace API URL
            string solaceApiUrl = $"http://{solaceHost}:8080/SEMP/v2/action/msgVpns/{vpnName}/queues/{queueName}/clearMessages";

            // Set the Solace API credentials
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{solaceUsername}:{solacePassword}")));

            // Send the HTTP POST request to clear the messages in the queue
            HttpResponseMessage clearResponse = await client.PostAsync(solaceApiUrl, null);

            if (clearResponse.IsSuccessStatusCode)
            {
                // Set the Solace API URL to retrieve messages from the queue
                solaceApiUrl = $"http://{solaceHost}:8080/SEMP/v2/monitor/msgVpns/{vpnName}/queues/{queueName}/messages";

                // Send the HTTP GET request to retrieve the messages
                HttpResponseMessage retrieveResponse = await client.GetAsync(solaceApiUrl);

                if (retrieveResponse.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseContent = await retrieveResponse.Content.ReadAsStringAsync();

                    Console.WriteLine("Messages retrieved successfully:");
                    Console.WriteLine(responseContent);
                    return responseContent;
                }
                else
                {
                    Console.WriteLine("Failed to retrieve messages. Status code: " + retrieveResponse.StatusCode);
                    return retrieveResponse.StatusCode.ToString();
                }
            }
            else
            {
                Console.WriteLine("Failed to clear messages. Status code: " + clearResponse.StatusCode);
                return clearResponse.StatusCode.ToString();
            }
        }
    }
}
