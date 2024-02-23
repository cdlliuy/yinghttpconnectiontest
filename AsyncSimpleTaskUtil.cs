namespace yinghttpconnectiontest
{
    public static class AsyncSimpleTaskUtil
    {
        static HttpClient client = new HttpClient();

        public static Task<Task> RunTasks()
        {
            return Task.Factory.StartNew(async () =>
            {
                Console.WriteLine($"{DateTime.UtcNow} RunTasks: Start RunTasks");
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                client.Timeout = TimeSpan.FromMilliseconds(5000);
                try
                {
                    var url = "https://data.ad-score.com/img?pid=1000943&tt=g&tid=27152&l1=229666&l2=3090&l3=8070911";
                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                    var statusCode = (int)response.StatusCode;
                    var statusCodeString = response.StatusCode.ToString();
                    Console.WriteLine($"{DateTime.UtcNow} RunTasks: Status code of Impression Tracking Url is {statusCode} {statusCodeString}");
                }
                catch ( Exception ex )
                {
                    Console.WriteLine($"{DateTime.UtcNow} RunTasks: thrown exception {ex}");
                }
            });

        }
    }
}
