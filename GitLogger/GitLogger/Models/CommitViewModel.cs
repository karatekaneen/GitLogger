using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace GitLogger.Models
{
    public class CommitViewModel
    {
        private ObservableCollection<EnrichedCommit> _commits = new ObservableCollection<EnrichedCommit>();

        public ObservableCollection<EnrichedCommit> Commits
        {
            get
            {
                return this._commits;
            }
        }

        public async void LoadData()
        {
            try
            {
                string URL = @"https://www.graphqlhub.com/graphql";

                // GraphQL Query:
                StringContent query = new StringContent("{\"query\":\"{graphQLHub github {user(username:\\\"karatekaneen\\\") {login id avatar_url repos {name commits(limit: 30) {message date}}}}}\\n\",\"variables\":null,\"operationName\":null}", Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage resp = await httpClient.PostAsync(URL, query);

                if (resp.IsSuccessStatusCode)
                {
                    var content = await resp.Content.ReadAsStringAsync();
                    var temp = JsonConvert.DeserializeObject<RootObject>(content);

                    // Extract all the commits
                    List<EnrichedCommit> enrichedCommits = new List<EnrichedCommit>();
                    temp.data.github.user.repos.ForEach(repo => {
                        repo.commits.ForEach(commit => enrichedCommits.Add(new EnrichedCommit(commit, repo)));
                    });

                    // Sort by date and add to collection:
                   enrichedCommits.OrderByDescending(c => c.date).ToList().ForEach(c => this._commits.Add(c));
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
    }
}
