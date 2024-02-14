using RandomTestValues;
using System;

namespace InterviewTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var temp = RandomValue.Collection<Observation>(2);
            temp[0].NumberOfNights = 1;
            temp[1].NumberOfNights = 2;

            //a
            var invoiceGroups = new List<InvoiceGroup>();
            var invoices = new List<Invoice>();
            invoices.Add(new Invoice() { Observations = temp.ToList() });
            

            invoiceGroups.Add(new InvoiceGroup { Invoices = invoices });
            invoiceGroups.Add(new InvoiceGroup { Invoices = invoices });
            invoiceGroups[0].IssueDate = new DateTime(2015, 5, 6);
            IEnumerable<string> repeatedGuestNames = invoiceGroups.SelectMany(i => i.Invoices)
                                                      .SelectMany(i => i.Observations)
                                                      .GroupBy(i => i.GuestName)
                                                      .Where(i => i.Count() > 1)
                                                      .Select(i => i.Key)
                                                      .Distinct()
                                                      .ToList();

            // b)
            IEnumerable<TravelAgentInfo> numberOfNightsByTravelAgent = invoiceGroups.Where(i => i.IssueDate.Year == 2015)
                                                                        .SelectMany(i => i.Invoices)
                                                                        .SelectMany(i => i.Observations)
                                                                        .GroupBy(i => i.TravelAgent)
                                                                        .Select(i => new TravelAgentInfo { TravelAgent = i.Key, TotalNumberOfNights = i.Sum(c => c.NumberOfNights) })
                                                                        .ToList();

        }
    }
}
