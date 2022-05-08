using System;

namespace Linq_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ex4
            List<int> numbersList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            List<string> newNumbersList = numbersList.Select(num => "," + num + ",").ToList();
            newNumbersList.ForEach(num => Console.WriteLine(num));

            List<string> newNumberList2 = (from number in numbersList
                                           select "," + number + ",").ToList();

            //Ex5
            List<string> names = new List<string>() { GetRandomNameString(), GetRandomNameString(), GetRandomNameString(), GetRandomNameString(),
            GetRandomNameString(),GetRandomNameString(),GetRandomNameString(),GetRandomNameString(),};

            

            List<string> names2 = names.Where(name => name.Length > 4).ToList();
            names2.ForEach(name => Console.WriteLine(name));

            List<string> names3 = (from name in names
                     where name.Length > 4
                     select name).ToList();
            //Ex6
            List<int> numberList3 = numbersList.Where(number => number % 2 == 0).OrderBy(number => number).ToList();
            List<int> numberList4 = numbersList.OrderByDescending(number => number).ToList();

            List<int> numbersQ1 = (from number in numbersList
                     where number % 2 == 0
                     orderby number
                     select number).ToList();
            List<int> numbersQ2 = (from number in numbersList
                    orderby number descending
                    select number).ToList();

            //Ex7
            List<int> numbers1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> numbers2 = new List<int>() { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                   


            List<int> numbers4 = numbers1.Except(numbers2).ToList();

            List<int> numbers5 = numbers1.Union(numbers2).ToList();
            var a = numbers1.FirstOrDefault(number => number > 12);
            var b = numbers2.FirstOrDefault(number => number > 12);

            //Ex8
          
            List<Agent> agents = new List<Agent>()
            {
                new Agent(){AgentName = "Yossi"},
                new Agent(){AgentName = "Moshe"},
                new Agent(){AgentName = "Yarin"},
                new Agent(){AgentName = "Dan"},

            };

            List<Client> clients = new List<Client>()
            {
                new Client(agents[0]){ClientName = "Tomer",Orders = 2},
                new Client(agents[1]){ClientName = "Yoav", Orders = 1},
                new Client(agents[1]){ClientName = "Almog", Orders = 3},
                new Client(agents[3]){ClientName = "Noam", Orders = 5},
            };

            var joinList  = clients.Join(agents,
                client => client.agent.AgentName,
                agent => agent.AgentName,
                (client, agent) => new
                {
                    agentJoinName = agent.AgentName,
                    clientJoinName = client.ClientName

                }).ToList();

            var joinListQ = (from client in clients
                            join agent in agents
                            on client.agent.AgentName equals agent.AgentName
                            select new
                            {
                                agentJoinQName = agent.AgentName,
                                clientJoinQName = client.ClientName
                            }).ToList();


            var x = clients.GroupJoin(agents, client => client.agent.AgentName, agent => agent.AgentName
            , (client, agent) => new
            {
                agentName = client.agent.AgentName,
                clientName = client.ClientName,
                clientOrders = client.Orders

            }).ToList(); 

        }

       

        public static string GetRandomNameString()
        {
            Random r = new Random();

            string[] names = { "David","Rotem", "Yoni","Adi", "Dani",
                "Shir", "Moshe","Yael", "Nir",
                "Anat","Reuven","Galit", "Shimi","Dana",
                "Yogev","Osnat", "Gad","Tali", "Natan",
                "Liat","Eyal","Rona" };
            int index = r.Next(0, names.Length);
            return names[index];

        }

    }
}
